using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Presentacion.Helpers;
using System.Configuration;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class LoginViewModel
    {
        public string ErrorSMS { get; set; } = "";
        public int UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public String UsuarioNombre { get; set; } = "";


        [Display(Name = "Login")]
        public String Login { get; set; } = "";


        [Display(Name = "Contraseña anterior")]
        public String PasswordOld { get; set; }


        [Display(Name = "Contraseña")]
        public String Password { get; set; }

        [Display(Name = "Repetir Contraseña")]
        public String PasswordRepeat { get; set; }

        //public int PerfilAdminID { get; set; }
        // public List<UsuarioPerfilesBE> LstPerfilesAsociados { get; set; }
        //public List<PerfilModulosBE> LstModulosAsociados { get; set; }
       // public List<PermisoPerfilModulosBE> LstPermisosAsociados { get; set; }

        public LoginViewModel()
        {
           // LstPermisosAsociados = new List<PermisoPerfilModulosBE>();
        }

        public SesionViewModel ValidarLogin()
        {
            SesionViewModel logSes = new SesionViewModel();
            EventosBE entLog = new EventosBE();


            logSes.GFHInicio = DateTime.Now;
            entLog.UsuarioLogin = this.Login;
            entLog.Accion = "LOGIN";
            entLog.OperacionSatisfactorio = false;
            entLog.SistemaId = 1;
            entLog.UsuarioRegistro = this.Login;
            entLog.FechaRegistro = DateTime.Now;
            //entLog.GFH = DateTime.Now; // comentar todos los GFH
            entLog.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;


            if (this.Login == null || this.Login.Length == 0 || this.Password == null || this.Password.Length == 0)
            {
                this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
                return logSes;
            }



            UsuarioViewModel m_usuarioVM = new UsuarioViewModel().BuscarxLogin(this.Login);

            if (m_usuarioVM == null)
            {
                this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
                entLog.Mensaje = "Login o contraseña incorrecta";
                entLog.UsuarioRegistro = "Invalido";
                (new EventosBL()).Insertar(entLog);
                return logSes;
            }


            if (m_usuarioVM.Login.ToLower() == this.Login.ToLower() && m_usuarioVM.Password == UtilidadBL.EncriptarSHA512(this.Password))
            {
                if (m_usuarioVM.EstadoId == 2)
                {
                    this.ErrorSMS = "El usuario se encuentra en estado inactivo.";
                    entLog.Mensaje = "Usuario inactivo";
                    (new EventosBL()).Insertar(entLog);
                    return logSes;
                }

                if (m_usuarioVM.FinVigencia != null && m_usuarioVM.FinVigencia < DateTime.Now)
                {
                    this.ErrorSMS = "Fecha de vigencia del permiso del usuario caducado.";
                    entLog.Mensaje = "Fecha vigencia usuario caducado";
                    (new EventosBL()).Insertar(entLog);
                    return logSes;
                }

                logSes.UsuarioId = m_usuarioVM.UsuarioId;
                logSes.Login = this.Login;
                logSes.UsuarioNombres = m_usuarioVM.NombresCompletos;

                logSes.LstPerfilesAsociados = m_usuarioVM.ObtenerPerfilesxUsuario();

                if (logSes.LstPerfilesAsociados == null)
                {
                    this.ErrorSMS = "El usuario no tiene asociado ningun perfil";
                    entLog.Mensaje = "Usuario sin perfiles";
                    (new EventosBL()).Insertar(entLog);
                    return logSes;
                }
                else
                {
                    foreach (UsuarioPerfilesBE perfiles in logSes.LstPerfilesAsociados)
                    {
                        List<PerfilModulosBE> LstModulosAsociados = m_usuarioVM.ObtenerModulosxPerfilId(perfiles.PerfilId);

                        if (LstModulosAsociados != null)
                            foreach (PerfilModulosBE moduloasociado  in LstModulosAsociados)
                                logSes.LstModulosAsociados.Add(moduloasociado);




//                        logSes.LstModulosAsociados = m_usuarioVM.ObtenerModulosxPerfilId(perfiles.PerfilId);

                        if (perfiles.PerfilId < 10)
                            logSes.UsuarioPerfilAdmId = perfiles.PerfilId;

                        if (logSes.LstModulosAsociados != null)
                        {
                            foreach (PerfilModulosBE perfilmodulo in logSes.LstModulosAsociados)
                            {
                                List<PermisoPerfilModulosBE> Lstpermisoperfilmodulo = m_usuarioVM.ObtenerPermisosxPerfilModuloId(perfilmodulo.PerfilModuloId);

                                if (Lstpermisoperfilmodulo != null)
                                {
                                    foreach (PermisoPerfilModulosBE permisoperfilmodulo in Lstpermisoperfilmodulo)
                                        logSes.LstPermisosAsociados.Add(permisoperfilmodulo);
                                }


                            }
                        }
                    }
                }

                if (logSes.LstModulosAsociados == null)
                {
                    this.ErrorSMS = "El usuario no tiene asociado ningun modulo";
                    entLog.Mensaje = "Usuario sin modulos";
                    (new EventosBL()).Insertar(entLog);
                    return logSes;
                }

                if (logSes.LstPermisosAsociados == null)
                {
                    this.ErrorSMS = "El usuario no tiene permiso asociado a ningun permiso";
                    entLog.Mensaje = "Usuario sin permiso a modulos";
                    (new EventosBL()).Insertar(entLog);
                    return logSes;
                }


                entLog.OperacionSatisfactorio = true;
                entLog.Mensaje = "Logueado";
                (new EventosBL()).Insertar(entLog);
                return logSes;
            }

            this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
            entLog.Mensaje = "Contraseña incorrecta";
            (new EventosBL()).Insertar(entLog);
            return logSes;
        }

        public bool CambiarClave()
        {
            EventosBE entLog = new EventosBE();

            entLog.UsuarioLogin = this.UsuarioNombre;
            entLog.Accion = "O";//ingreso            
            entLog.SistemaId = 1;
            entLog.UsuarioId = this.UsuarioId;
            entLog.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            bool v = true;

            UsuarioViewModel u = new UsuarioViewModel();
            v = u.CambiarClave(this.UsuarioId, this.Password, this.PasswordRepeat, entLog.NroIpRegistro);

            if (v == false)
            {
                this.ErrorSMS = u.ErrorSMS;
                entLog.OperacionSatisfactorio = false;
                entLog.Mensaje = "No se pudo cambiar la contraseña";
            }
            else
            {
                entLog.Mensaje = "Cambio de contraseña";
                entLog.OperacionSatisfactorio = true;
            }

            (new EventosBL()).Insertar(entLog);

            return v;
        }



        //    List<UsuarioViewModel> l = (new UsuarioViewModel()).Listar_grilla((new UsuarioViewModel() { Login = this.Login.Trim() }));


        //    if (l.Count == 0)
        //    {
        //        this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
        //        entLog.Mensaje = "Login o contraseña incorrecta";
        //        entLog.EstadoId = 1;
        //        (new EventosBL()).Insertar(entLog);
        //        return logSes;
        //    }

        //    entLog.UsuarioId = l[0].UsuarioId;

        //    if (l[0].Login.ToLower() == this.Login.ToLower())
        //        if (l[0].Login.ToLower() == this.Login.ToLower() && l[0].Password == UtilidadBL.EncriptarSHA512(this.Password))
        //        {
        //            entLog.UsuarioRegistro = l[0].Login;
        //            if (l[0].EstadoId == 2)
        //            {
        //                this.ErrorSMS = "El usuario se encuentra en estado inactivo.";
        //                entLog.Mensaje = "Usuario inactivo";
        //                (new EventosBL()).Insertar(entLog);
        //                return logSes;
        //            }

        //            if (l[0].FinVigencia != null && l[0].FinVigencia < DateTime.Now)
        //            {//usuario inactivo
        //                this.ErrorSMS = "Fecha de vigencia del permiso del usuario caducado.";
        //                entLog.Mensaje = "Fecha vigencia usuario caducado";
        //                (new EventosBL()).Insertar(entLog);

        //                return logSes;
        //            }

        //            logSes.UsuarioId = l[0].UsuarioId;
        //            logSes.Login = l[0].Login;
        //            logSes.UsuarioNombres = l[0].NombresCompletos;

        //            int idSis = 1;//sistemaId modulo de seguridad
        //            string key_sistema = "AAFB7F64FD3E4707";

        //            PermisoPerfilModuloViewModel ld = new PermisoPerfilModuloViewModel();

        //            //logSes.LstModulosAutorizados = ld.Listar_permiso_activo_x_perfil(l[0].UsuarioId, key_sistema);//Listar_permiso_activo

        //            if (logSes.LstModulosAutorizados.Count == 0 && logSes.Login.ToUpper() != "ADMIN")
        //            {
        //                this.ErrorSMS = "No está autorizado a ningún módulo del sistema.";
        //                entLog.Mensaje = "Ningún módulo autorizado del sistema IdSistema=" + idSis;
        //            }
        //            else
        //            {
        //                entLog.OperacionSatisfactorio = true;
        //            }

        //            entLog.Mensaje = "Logueado";


        //            (new EventosBL()).Insertar(entLog);

        //            return logSes;
        //        }

        //    this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
        //    entLog.Mensaje = "Contraseña incorrecta";
        //    (new EventosBL()).Insertar(entLog);
        //    return logSes;
        //}
        public bool LogOut(int id_usuario, int id_sistema, string login)
        {
            EventosBE entLog = new EventosBE();
            entLog.UsuarioId = id_usuario;
            entLog.SistemaId = id_sistema;
            entLog.Mensaje = "Logout";
            entLog.OperacionSatisfactorio = true;
            entLog.Accion = "Logout";
            entLog.UsuarioLogin = login;
            entLog.UsuarioRegistro = login;
            entLog.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            (new EventosBL()).Insertar(entLog);

            return true;
        }

        //public bool GrabarCambioClave()
        //{
        //    EventosBE entLog = new EventosBE();

        //    entLog.UsuarioLogin = this.Login;
        //    entLog.Accion = "O";//ingreso            
        //    entLog.SistemaId = 1;
        //    entLog.UsuarioId = this.UsuarioId;
        //    entLog.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

        //    List<UsuarioViewModel> l = (new UsuarioViewModel()).Listar_grilla((new UsuarioViewModel() { Login = this.Login.Trim() }));
        //    if (l.Count == 0)
        //    {
        //        this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
        //        entLog.Mensaje = "Login o contraseña incorrecta";
        //        (new EventosBL()).Insertar(entLog);
        //        return false;
        //    }

        //    if (l[0].Login.ToLower() == this.Login.ToLower() && l[0].Password == UtilidadBL.EncriptarSHA512(this.PasswordOld))
        //    {
        //        bool v = true;

        //        UsuarioViewModel u = new UsuarioViewModel();
        //        v = u.CambioClave(this.UsuarioId, this.Password, this.PasswordRepeat, entLog.NroIpRegistro);

        //        if (v == false)
        //        {
        //            this.ErrorSMS = u.ErrorSMS;
        //            entLog.OperacionSatisfactorio = false;
        //            entLog.Mensaje = "No se pudo cambiar la contraseña";
        //        }
        //        else
        //        {
        //            entLog.Mensaje = "Cambio de contraseña";
        //            entLog.OperacionSatisfactorio = true;
        //        }

        //        (new EventosBL()).Insertar(entLog);

        //        return v;
        //    }

        //    this.ErrorSMS = "Login o contraseña incorrecta, por favor vuelva intentarlo.";
        //    entLog.Mensaje = "Contraseña incorrecta";
        //    (new EventosBL()).Insertar(entLog);

        //    return false;
        //}



    }
}