using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Text.RegularExpressions;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class UsuariosBL : BaseBL
    {
        const string Nombre_Clase = "UsuariosBL";
        private string m_BaseDatos = string.Empty;

        public object SYS_ENUM { get; private set; }

        public UsuariosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuariosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        #region "validacion"
        private bool ValidaActualizar(UsuariosBE e_USUARIO, ref string outSms)
        {
            bool v = true;

            if (e_USUARIO.UsuarioId == 1)
            {
                outSms = outSms + "No es posible completar la operación, el registro pertece a un usuario del sistema";
                v = false;
            }
            if (e_USUARIO.ApePaterno == null || e_USUARIO.ApePaterno == "")
            {
                outSms = outSms + "Ingrese apellido paterno";
                v = false;
            }
            if (e_USUARIO.ApeMaterno == null || e_USUARIO.ApeMaterno == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese apellido materno" : "Ingrese apellido materno";
                v = false;
            }
            if (e_USUARIO.Nombres == null || e_USUARIO.Nombres == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese los nombres" : "Ingrese los nombres";
                v = false;
            }
            if (e_USUARIO.NumeroDoc == null || e_USUARIO.NumeroDoc == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese número de documento de identidad" : "número de documento de identidad";
                v = false;
            }
            //if (e_USUARIO.Cargo == null || e_USUARIO.Cargo == "")
            //{
            //    outSms = (outSms.Length > 0) ? outSms + ", ingrese el cargo" : "ingrese el cargo";
            //    v = false;
            //}
            if (e_USUARIO.Login == null || e_USUARIO.Login == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese el cargo" : "ingrese el cargo";
                v = false;
            }

            UsuariosBE dto = new UsuariosBE();
            dto.ApePaterno = e_USUARIO.ApePaterno;
            dto.ApePaterno = e_USUARIO.ApePaterno;
            dto.Login = e_USUARIO.Login;
            dto.Nombres = e_USUARIO.Nombres;

            List<UsuariosBE> l = (new UsuariosBL()).ConsultarLogin(dto);
            if (l.Count > 0)
            {
                if (l[0].UsuarioId != e_USUARIO.UsuarioId)
                {
                    outSms = (outSms.Length > 0) ? outSms + ", ya existe registro con los mismos datos." : "Ya existe registro con los mismos datos.";
                    v = false;
                }
            }

            dto = new UsuariosBE();
            dto.Login = e_USUARIO.Login;

            l = (new UsuariosBL()).ConsultarLogin(dto);
            if (l.Count > 0)
            {
                if (l[0].UsuarioId != e_USUARIO.UsuarioId)
                {
                    outSms = (outSms.Length > 0) ? outSms + ", El login ya existe asignado a otro usuario." : "El login ya existe asignado a otro usuario.";
                    v = false;
                }
            }

            return v;
        }
        private bool ValidaInsertar(UsuariosBE m_usuarioBE , ref string outSms)
        {
            bool v = true;

            if (m_usuarioBE.ApePaterno == null || m_usuarioBE.ApePaterno == "")
            {
                outSms = outSms + "Ingrese apellido paterno";
                v = false;
            }
            if (m_usuarioBE.ApeMaterno == null || m_usuarioBE.ApeMaterno == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese apellido materno" : "Ingrese apellido materno";
                v = false;
            }
            if (m_usuarioBE.Nombres == null || m_usuarioBE.Nombres == "")
            {
                outSms = (outSms.Length > 0) ? outSms + ", ingrese los nombres" : "Ingrese los nombres";
                v = false;
            }
            //if (m_usuarioBE.NumeroDoc == null || m_usuarioBE.NumeroDoc == "")
            //{
            //    outSms = (outSms.Length > 0) ? outSms + ", ingrese número de documento de identidad" : "Ingrese número de documento de identidad";
            //    v = false;
            //}
            //if (e_USUARIO.Cargo == null || e_USUARIO.Cargo == "")
            //{
            //    outSms = (outSms.Length > 0) ? outSms + ", ingrese el cargo" : "ingrese el cargo";
            //    v = false;
            //}


            if (new UsuariosBL().ConsultarLogin(m_usuarioBE).FirstOrDefault() != null)
                {
                    outSms = (outSms.Length > 0) ? outSms + ", ya existe el login con los mismos datos." : "Ya existe registro con los mismos datos.";
                    v = false;
                }

            return v;
        }
        #endregion
        public int Insertar(UsuariosBE e_Usuarios, ref string outSms)
        {
            if (ValidaInsertar(e_Usuarios, ref outSms) == false) return -1;

            try
            {
                //clave por defecto DNI
                string cad = e_Usuarios.NumeroDoc;
                e_Usuarios.Password = UtilidadBL.EncriptarSHA512(cad.ToUpper());
                e_Usuarios.ResetPassword= true;

                UsuariosDA o_USUARIO = new UsuariosDA();
                int resp = o_USUARIO.Insertar(e_Usuarios);

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public int Actualizar(UsuariosBE e_USUARIO, ref string outSms)
        {
            if (ValidaActualizar(e_USUARIO, ref outSms) == false) return -1;

            try
            {
                UsuariosDA o_USUARIO = new UsuariosDA();
                int resp = o_USUARIO.Actualizar(e_USUARIO);

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Anular(UsuariosBE e_Usuarios)
        {
            try
            {
                UsuariosDA o_Usuarios = new UsuariosDA(m_BaseDatos);
                int resp = o_Usuarios.Anular(e_Usuarios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuariosBE> Consultar_Lista()
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            try
            {
                UsuariosDA o_Usuarios = new UsuariosDA(m_BaseDatos);
                return o_Usuarios.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuariosBE> Consultar_PK(int m_UsuarioId)
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            try
            {
                UsuariosDA o_Usuarios = new UsuariosDA(m_BaseDatos);
                return o_Usuarios.Consultar_PK(m_UsuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuariosBE> ConsultarLogin(string m_UsuarioLogin)
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            try
            {
                UsuariosDA o_Usuarios = new UsuariosDA(m_BaseDatos);
                return o_Usuarios.ConsultarLogin(m_UsuarioLogin);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool CambiarClave(UsuariosBE usuarioBE, ref string outSms)
        {
            if (Regex.Replace(usuarioBE.Password.ToUpper(), "[^A-Z]", "") == string.Empty)
            {
                outSms = "La contraseña debe contener letras";
                return false;
            }

            try
            {
                usuarioBE.Password = UtilidadBL.EncriptarSHA512(usuarioBE.Password);

                UsuariosDA o_USUARIO = new UsuariosDA();
                int resp = o_USUARIO.CambiarClave(usuarioBE);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuariosDTO> ListarUsuariosFiltrados(UsuariosDTO ent)
        {
            List<UsuariosDTO> l = new List<UsuariosDTO>();
            try
            {
                l = (new UsuariosDA()).ListarUsuariosFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool CambiarEstado(int UsuarioId, int estadoId, int UsuarioLogueadoId)
        {
            try
            {
                UsuariosBE usuarioBE = new UsuariosBE();
                usuarioBE = new UsuariosBL().Consultar_PK(UsuarioId).FirstOrDefault();

                if (usuarioBE == null)
                    return false;

                usuarioBE.EstadoId = estadoId;
                usuarioBE.UsuarioModificacionRegistro = new UsuariosDA().Consultar_Lista().Where(x => x.UsuarioId == UsuarioLogueadoId).FirstOrDefault().Login;

                UsuariosDA o_USUARIO = new UsuariosDA();
                int resp = o_USUARIO.CambiarEstado(usuarioBE);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new UsuariosDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public List<UsuariosBE> ConsultarLogin(UsuariosBE usuarioBE)
        {
            List<UsuariosBE> LstUsuarios = new List<UsuariosBE>();
            try
            {
                LstUsuarios = (new UsuariosDA()).ConsultarLogin(usuarioBE.Login);

            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return LstUsuarios;
        }

        public List<UsuariosDTO> Listar_grilla_inicial(UsuariosDTO ent)
        {
            List<UsuariosDTO> l = new List<UsuariosDTO>();
            try
            {
                l = (new UsuariosDA()).Listar_grilla_inicial(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
    }
}
