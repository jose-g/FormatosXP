using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Entidades;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MoralesLarios.Linq;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class UsuarioViewModel
    {

        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        //public int UsuarioLogueadoId { get; set; }
        //public string UsuarioLogueadoNombre{ get; set; }
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; } // Civil, Naval, Extranjero

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Clave")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Ape. Paterno")]
        public string ApePaterno { get; set; } = "";

        [Display(Name = "Ape. Materno")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string ApeMaterno { get; set; } = "";

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = "";
        public int? DocumentoIdentidadId { get; set; }
        [Display(Name = "Núm. Doc. Identidad")]
        public string NumeroDoc { get; set; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Solo se Aceptan Numeros")]
        [Display(Name = "CIP del Colaborador")]
        public int CIP { get; set; }
        [Display(Name = "Fecha nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; } = "";
        [Display(Name = "Celular")]
        public string Celular { get; set; } = "";
        //[Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Doc. Referencia")]
        public string DocReferencia { get; set; } = "";
        [Display(Name = "Fin vigencia")]
        public DateTime? FinVigencia { get; set; }
        public DateTime? FechaUltimoLogueo { get; set; }
        [Display(Name = "EstadoId")]
        public int? EstadoId { get; set; } = 1;
        public int? UbigeoNavalId { get; set; }
        public bool ResetPassword { get; set; }
        public String AvatarPath { get; set; } = "";
        [Display(Name = "Usuario Registro")]
        public string UsuarioRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public string UsuarioModificacionRegistro { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime? FechaModificacionRegistro { get; set; }
        [Display(Name = "IP de Registro")]
        public string NroIpRegistro { get; set; }
        #endregion
        #region PropiedadesGUI
        [Display(Name = "Confirmar clave")]
        public string ConfirmarPassword { get; set; }
        public bool EliminarFoto { get; set; }
        [Display(Name = "Nombres Completos")]
        public string NombresCompletos { get { return ApePaterno + " " + ApeMaterno + ", " + Nombres; } }
        public String ImagenBase64 { get; set; } = "";
        #endregion
        #region PropiedadesComplementarias

        [Display(Name = "Tipo Usuario")]
        public string TipoUsuario { get; set; }

        [Display(Name = "Tipo Doc. Identidad")]
        public string DocumentoIdentidad { get; set; }


        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        public String FechaModificacionRegistroStr
        {
            get
            {
                return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
            }
        }
        [Display(Name = "Estado Nombre")]
        public string EstadoNombre { get; set; }

        [Display(Name = "Zona Naval")]
        public string ZonaNaval { get; set; } = "";

        [Display(Name = "Dependencia")]
        public string Dependencia { get; set; } = "";
        public Int32 ZonaNavalId { get; set; }
        public Int32 DependenciaId { get; set; }
        #endregion

        public List<UbigeoNavalBE> LstUbigeoNavalBE;
        public List<UbigeoNavalBE> LstZonasNavales;
        public List<UbigeoNavalBE> LstDependencias;
        public List<DocumentoIdentidadTiposBE> LstDocumentosIdentidad;
        public List<TiposUsuariosBE> LstTiposUsuariosBE;
        public List<UsuariosBE> LstUsuariosBE;
        public List<PermisosBE> LstPermisosBE;

        
        #region "Constructores"        

        public UsuarioViewModel() {
            LstDocumentosIdentidad = new List<DocumentoIdentidadTiposBE>();
            LstUbigeoNavalBE = new List<UbigeoNavalBE>();
            LstZonasNavales = new List<UbigeoNavalBE>();
            LstDependencias = new List<UbigeoNavalBE>();
            LstTiposUsuariosBE = new List<TiposUsuariosBE>();
            LstUsuariosBE = new List<UsuariosBE>();
        }
        #endregion

        #region "Operaciones"        

        public List<UsuarioViewModel> Consultar_listaToDatatable(int UsuarioSesionId)
        {
            List<UsuarioViewModel> LstUsuariosVM = new List<UsuarioViewModel>();
            int perfilUsuarioLogueado = new UsuarioPerfilesBL().Consultar_Lista().Where(x => x.UsuarioId == UsuarioSesionId).OrderBy(x => x.PerfilId).FirstOrDefault().PerfilId;


            List<UsuariosBE> LstUsuariosBE = new UsuarioPerfilesBL().Consultar_Lista().Where(x => x.PerfilId > perfilUsuarioLogueado)
                .Join(new UsuariosBL().Consultar_Lista(), a => a.UsuarioId, p => p.UsuarioId, (p, a) => new { UsuarioPerfiles = p, Usuarios = a })
                .DistinctBy(x => x.UsuarioPerfiles.UsuarioId)
                .Select(p => new { p.Usuarios }).Select(x => x.Usuarios).OrderBy(x => x.Nombres).ToList();

            LstUsuariosBE = LstUsuariosBE.DistinctBy(x => x.UsuarioId).ToList();
            foreach (UsuariosBE usuarioBE in LstUsuariosBE)
            {

                int m_perfil = new UsuarioPerfilesBL().Consultar_Lista().OrderBy(x => x.PerfilId).ToList().Find(x => x.UsuarioId == usuarioBE.UsuarioId).PerfilId;
                int m_nroperfiles = new UsuarioPerfilesBL().Consultar_Lista().OrderBy(x => x.PerfilId).ToList().FindAll(x => x.UsuarioId == usuarioBE.UsuarioId).Count();
                if (m_perfil <= perfilUsuarioLogueado && m_nroperfiles == 2)
                    continue;
                LstUsuariosVM.Add(BEToViewModel(usuarioBE));
            }

            return LstUsuariosVM;
        }
        public void CargarTablasMaestras()
        {
            CargarListaDocumentosIdentidad();
            CargarListaTiposUsuarios();
            CargarListaUbigeosNavalesxGrupo();
        }
        public List<UsuarioViewModel> Consultar_lista()
        {
            List<UsuarioViewModel> LstUsuariosVM = new List<UsuarioViewModel>();
            List<UsuariosBE> LstUsuariosBE = (new UsuariosBL()).Consultar_Lista();

            foreach (UsuariosBE usuarioBE in LstUsuariosBE)
                LstUsuariosVM.Add(BEToViewModel(usuarioBE));

            return LstUsuariosVM;
        }
        public UsuarioViewModel BuscarxId(int UsuarioId)
        {
            UsuariosBE usuarioBE = new UsuariosBL().Consultar_PK(UsuarioId).FirstOrDefault();

            if (usuarioBE != null)
                return BEToViewModel(usuarioBE);

            return null;
        }
        public UsuarioViewModel BuscarxLogin(string m_login)
        {
            UsuariosBE usuarioBE = (new UsuariosBL()).Consultar_Lista().Where(x => x.Login.Equals(m_login)).FirstOrDefault();
            if (usuarioBE != null)
                return BEToViewModel(usuarioBE);

            return null;
        }
        public void CargarListaDocumentosIdentidad()
        {
            LstDocumentosIdentidad = new DocumentoIdentidadTiposBL().Consultar_Lista().OrderBy(x => x.Descripcion).ToList();
        }
        public void CargarListaTiposUsuarios()
        {
            LstTiposUsuariosBE = new TiposUsuariosBL().Consultar_Lista().OrderBy(x => x.DescCorta).ToList();
        }
        public void CargarListaUsuarios()
        {
            LstUsuariosBE = new UsuariosBL().Consultar_Lista().OrderBy(x => x.Login).ToList();
        }
        public void CargarListaUbigeosNavales()
        {
            LstUbigeoNavalBE = new UbigeoNavalBL().Consultar_Lista().OrderBy(x => x.ZonaNavalDescCorta).ToList();
        }
        public void CargarListaUbigeosNavalesxGrupo()
        {
            LstUbigeoNavalBE = new UbigeoNavalBL().Consultar_Lista().ToList().DistinctBy(x => x.ZonaNavalId).OrderBy(x => x.ZonaNavalDescCorta).ToList();
        }
        public void CargarDependenciasxZona(int m_zonnNavalId)
        {
            LstDependencias = new UbigeoNavalBL().Consultar_Lista().Where(x => x.ZonaNavalId == m_zonnNavalId).ToList();
        }
        private UsuarioViewModel BEToViewModel(UsuariosBE m_usuarioBE)
        {
            UsuarioViewModel m_usuarioVM = new UsuarioViewModel();

            m_usuarioVM.UsuarioId = m_usuarioBE.UsuarioId;
            m_usuarioVM.TipoUsuarioId = m_usuarioBE.TipoUsuarioId;
            m_usuarioVM.Login = m_usuarioBE.Login;
            m_usuarioVM.Password = m_usuarioBE.Password;
            m_usuarioVM.ApePaterno = m_usuarioBE.ApePaterno;
            m_usuarioVM.ApeMaterno = m_usuarioBE.ApeMaterno;
            m_usuarioVM.Nombres = m_usuarioBE.Nombres;
            m_usuarioVM.DocumentoIdentidadId = m_usuarioBE.DocumentoIdentidadId;
            m_usuarioVM.NumeroDoc = m_usuarioBE.NumeroDoc;
            if (m_usuarioBE.CIP.HasValue)
                m_usuarioVM.CIP = m_usuarioBE.CIP.Value;
            m_usuarioVM.FechaNacimiento = m_usuarioBE.FechaNacimiento;
            m_usuarioVM.Email = m_usuarioBE.Email;
            m_usuarioVM.Celular = m_usuarioBE.Celular;
            m_usuarioVM.DocReferencia = m_usuarioBE.DocReferencia;
            m_usuarioVM.FinVigencia = m_usuarioBE.FinVigencia;
            m_usuarioVM.FechaUltimoLogueo = m_usuarioBE.FechaUltimoLogueo;
            m_usuarioVM.EstadoId = m_usuarioBE.EstadoId;
            m_usuarioVM.UbigeoNavalId= m_usuarioBE.UbigeoNavalId;
            m_usuarioVM.ResetPassword= m_usuarioBE.ResetPassword;
            m_usuarioVM.AvatarPath = m_usuarioBE.AvatarPath;
            m_usuarioVM.UsuarioRegistro = m_usuarioBE.UsuarioRegistro;
            m_usuarioVM.FechaRegistro = m_usuarioBE.FechaRegistro;
            m_usuarioVM.UsuarioModificacionRegistro = m_usuarioBE.UsuarioModificacionRegistro;
            m_usuarioVM.FechaModificacionRegistro = m_usuarioBE.FechaModificacionRegistro;
            m_usuarioVM.NroIpRegistro = m_usuarioBE.NroIpRegistro;
            m_usuarioVM.ImagenBase64 = m_usuarioBE.ApePaterno + " " + m_usuarioBE.ApeMaterno + ", " + m_usuarioBE.Nombres;
            //m_usuarioVM.TipoUsuario = new TiposUsuariosBL().Consultar_PK(m_usuarioBE.TipoUsuarioId).FirstOrDefault().DescCorta;
            m_usuarioVM.DocumentoIdentidad = new DocumentoIdentidadTiposBL().Consultar_PK(m_usuarioBE.DocumentoIdentidadId.Value).FirstOrDefault().Descripcion;
            m_usuarioVM.EstadoNombre = new EstadosBL().Consultar_PK(m_usuarioBE.EstadoId.Value).FirstOrDefault().Nombre;

            var ubigeo = new UbigeoNavalBL().Consultar_PK(m_usuarioBE.UbigeoNavalId.Value).FirstOrDefault();
            m_usuarioVM.ZonaNaval = ubigeo.ZonaNavalDescCorta;
            m_usuarioVM.Dependencia = ubigeo.DependenciaDescCorta;
            m_usuarioVM.ZonaNavalId = ubigeo.ZonaNavalId.Value;
            m_usuarioVM.DependenciaId = ubigeo.DependenciaId.Value;

            m_usuarioVM.LstUbigeoNavalBE = new UbigeoNavalBL().Consultar_Lista();
            m_usuarioVM.LstDocumentosIdentidad = new DocumentoIdentidadTiposBL().Consultar_Lista();
            m_usuarioVM.LstTiposUsuariosBE = new TiposUsuariosBL().Consultar_Lista();
            m_usuarioVM.LstUsuariosBE = new UsuariosBL().Consultar_Lista();

            return m_usuarioVM;
        }
        private UsuariosBE ViewModelToBE(UsuarioViewModel m_usuarioVM)
        {
            UsuariosBE m_UsuariosBE = new UsuariosBE();

            m_UsuariosBE.UsuarioId = m_usuarioVM.UsuarioId;
            m_UsuariosBE.Login = m_usuarioVM.Login;
            m_UsuariosBE.Password = m_usuarioVM.Password;
            m_UsuariosBE.ApePaterno = m_usuarioVM.ApePaterno;
            m_UsuariosBE.ApeMaterno = m_usuarioVM.ApeMaterno;
            m_UsuariosBE.Nombres = m_usuarioVM.Nombres;
            m_UsuariosBE.DocumentoIdentidadId = m_usuarioVM.DocumentoIdentidadId;
            m_UsuariosBE.NumeroDoc = m_usuarioVM.NumeroDoc;
            m_UsuariosBE.CIP = m_usuarioVM.CIP;
            m_UsuariosBE.FechaNacimiento = m_usuarioVM.FechaNacimiento;
            m_UsuariosBE.Email = m_usuarioVM.Email;
            m_UsuariosBE.Celular = m_usuarioVM.Celular;
            m_UsuariosBE.DocReferencia = m_usuarioVM.DocReferencia;
            m_UsuariosBE.FinVigencia = m_usuarioVM.FinVigencia;
            m_UsuariosBE.FechaUltimoLogueo = m_usuarioVM.FechaUltimoLogueo;
            m_UsuariosBE.EstadoId = m_usuarioVM.EstadoId;
            m_UsuariosBE.UbigeoNavalId = new UbigeoNavalBL().Consultar_Lista().Where(x => x.DependenciaId == m_usuarioVM.DependenciaId && x.ZonaNavalId == m_usuarioVM.ZonaNavalId).FirstOrDefault().UbigeoNavalId;
            m_UsuariosBE.ResetPassword = m_usuarioVM.ResetPassword;
            m_UsuariosBE.AvatarPath = m_usuarioVM.AvatarPath;
            m_UsuariosBE.UsuarioRegistro = m_usuarioVM.UsuarioRegistro;
            m_UsuariosBE.FechaRegistro = m_usuarioVM.FechaRegistro;
            m_UsuariosBE.UsuarioModificacionRegistro = m_usuarioVM.UsuarioModificacionRegistro;
            m_UsuariosBE.FechaModificacionRegistro = m_usuarioVM.FechaModificacionRegistro;
            m_UsuariosBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return m_UsuariosBE;
        }
        public  List<UsuarioPerfilesBE> ObtenerPerfilesxUsuario()
        {
            List<UsuarioPerfilesBE> LstusuarioPerfilesBE = new List<UsuarioPerfilesBE>();
            return new UsuarioPerfilesBL().Consultar_Lista().Where(x => x.UsuarioId == this.UsuarioId).ToList();
            
//            return LstusuarioPerfilesBE;
        }
        public List<PerfilModulosBE> ObtenerModulosxPerfilId(int m_perfilId)
        {
            
            return new PerfilModulosBL().Consultar_Lista().Where(x => x.PerfilId == m_perfilId).ToList();

            //return LstperfilModulosBE;
        }
        public List<PermisoPerfilModulosBE> ObtenerPermisosxPerfilModuloId(int m_PerfilModuloId)
        {
            return new PermisoPerfilModulosBL().Consultar_Lista().Where(x => x.PerfilModuloId == m_PerfilModuloId).ToList();
        }
        public List<PermisosBE> ObtenerPermisosxPerfil(int m_perfilId)
        {
            return new PermisosBL().ConsultaxPerfil_PK(m_perfilId);
        }
        public List<PermisoPerfilModulosBE> ObtenerPermisos(int m_perfilmoduloId)
        {
            return new PermisoPerfilModulosBL().Consultar_Lista().Where(x => x.PerfilModuloId == m_perfilmoduloId).ToList();
        }
        public List<UsuarioViewModel> ListarUsuariosFiltrados(UsuarioViewModel m_usuarioVM)
        {
            List<UsuarioViewModel> LstusuarioViewModel = new List<UsuarioViewModel>();

            List<UsuariosDTO> LstsuariosDTO = (new UsuariosBL()).ListarUsuariosFiltrados(ViewModelToDTO(m_usuarioVM));
            foreach (UsuariosDTO usuarioDTO in LstsuariosDTO)
            {
                LstusuarioViewModel.Add(DtoToViewModel(usuarioDTO));
            }

            return LstusuarioViewModel;
        }
        public bool Anular(int UsuarioId, string m_login)
        {
            bool ret = false;
            if (UsuarioId < 0) return false;
            if (UsuarioId == 1 )
            {
                this.ErrorSMS = "No es posible eliminar el registro, es un usuario del sistema, como alternativa inhabilite al usuario.";
                return false;
            }

            UsuariosBE usuarioBE  = new UsuariosBL().Consultar_PK(UsuarioId).FirstOrDefault();
            usuarioBE.NroIpRegistro= HttpContext.Current.Request.UserHostAddress;
            usuarioBE.UsuarioModificacionRegistro = m_login;

            if (usuarioBE != null)
                ret = (new UsuariosBL()).Anular(usuarioBE);

            if (ret == false)
                this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        public int Actualizar(string login)
        {
            string sms = "";
            int v = -1;
            UsuariosBE usuarioBE = new UsuariosBE();
            this.UsuarioModificacionRegistro = login;
            usuarioBE = ViewModelToBE(this);
            v = (new UsuariosBL()).Actualizar(usuarioBE, ref sms);

            if (v == -1)
                this.ErrorSMS = sms;

            return v;
        }
        public int Insertar(string login)
        {
            string out_sms_err = "";
            int v = -1;

            UsuariosBE usuariosBE = new UsuariosBE();
            this.UsuarioRegistro=login;
            this.UsuarioId = GetMaxId() + 1;
            usuariosBE = ViewModelToBE(this);
            v = (new UsuariosBL()).Insertar(usuariosBE, ref out_sms_err);

            if (v == -1)
                this.ErrorSMS = out_sms_err;

            return v; ;
        }
        public int GetMaxId()
        {
            return (new UsuariosBL()).GetMaxId();
        }
        public bool CambiarClave(int UsuarioId, string newpassword, string confirmarClave, string m_ip)
        {
            string sms = "";

            UsuariosBE usuarioBE = new UsuariosBL().Consultar_PK(UsuarioId).FirstOrDefault();
            if (usuarioBE != null)
            {
                if (newpassword != confirmarClave)
                {
                    this.ErrorSMS = "Las contaseñas no coinciden, vuelva a intentarlo.";
                    return false;
                }
                usuarioBE.Password = newpassword;
                usuarioBE.UsuarioModificacionRegistro = "ADMIN";
                usuarioBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                bool ret = (new UsuariosBL()).CambiarClave(usuarioBE, ref sms);

                if (!ret)
                    this.ErrorSMS = sms;

                return ret;
            }

            return false;
        }
        private UsuariosDTO ViewModelToDTO(UsuarioViewModel m_usuarioVM)
        {
            UsuariosDTO m_UsuariosDTO = new UsuariosDTO();

            m_UsuariosDTO.UsuarioId = m_usuarioVM.UsuarioId;
            m_UsuariosDTO.TipoUsuarioId = m_usuarioVM.TipoUsuarioId;
            m_UsuariosDTO.Login = m_usuarioVM.Login;
            m_UsuariosDTO.Password = m_usuarioVM.Password;
            m_UsuariosDTO.ApePaterno = m_usuarioVM.ApePaterno;
            m_UsuariosDTO.ApeMaterno = m_usuarioVM.ApeMaterno;
            m_UsuariosDTO.Nombres = m_usuarioVM.Nombres;
            m_UsuariosDTO.DocumentoIdentidadId = m_usuarioVM.DocumentoIdentidadId;
            m_UsuariosDTO.NumeroDoc = m_usuarioVM.NumeroDoc;
            m_UsuariosDTO.FechaNacimiento = m_usuarioVM.FechaNacimiento;
            m_UsuariosDTO.Email = m_usuarioVM.Email;
            m_UsuariosDTO.Celular = m_usuarioVM.Celular;
            m_UsuariosDTO.DocReferencia = m_usuarioVM.DocReferencia;
            m_UsuariosDTO.FinVigencia = m_usuarioVM.FinVigencia;
            m_UsuariosDTO.FechaUltimoLogueo = m_usuarioVM.FechaUltimoLogueo;
            m_UsuariosDTO.EstadoId = m_usuarioVM.EstadoId;
            m_UsuariosDTO.UsuarioRegistro = m_usuarioVM.UsuarioRegistro;
            m_UsuariosDTO.FechaRegistro = m_usuarioVM.FechaRegistro;
            m_UsuariosDTO.UsuarioModificacionRegistro = m_usuarioVM.UsuarioModificacionRegistro;
            m_UsuariosDTO.FechaModificacionRegistro = m_usuarioVM.FechaModificacionRegistro;
            m_UsuariosDTO.UbigeoNavalId = m_usuarioVM.UbigeoNavalId;
            m_UsuariosDTO.AvatarPath = m_usuarioVM.AvatarPath;
            m_UsuariosDTO.ZonaNaval = m_usuarioVM.ZonaNaval;
            m_UsuariosDTO.Dependencia = m_usuarioVM.Dependencia;

            return m_UsuariosDTO;
        }
        private UsuarioViewModel DtoToViewModel(UsuariosDTO m_usuarioDTO)
        {
            UsuarioViewModel m_usuarioVM = new UsuarioViewModel();

            m_usuarioVM.UsuarioId = m_usuarioDTO.UsuarioId;
            m_usuarioVM.Login = m_usuarioDTO.Login;
            m_usuarioVM.TipoUsuarioId = m_usuarioDTO.TipoUsuarioId;
            m_usuarioVM.Password = m_usuarioDTO.Password;
            m_usuarioVM.ApePaterno = m_usuarioDTO.ApePaterno;
            m_usuarioVM.ApeMaterno = m_usuarioDTO.ApeMaterno;
            m_usuarioVM.Nombres = m_usuarioDTO.Nombres;
            m_usuarioVM.DocumentoIdentidadId = m_usuarioDTO.DocumentoIdentidadId;
            m_usuarioVM.NumeroDoc = m_usuarioDTO.NumeroDoc;
            m_usuarioVM.FechaNacimiento = m_usuarioDTO.FechaNacimiento;
            m_usuarioVM.Email = m_usuarioDTO.Email;
            m_usuarioVM.Celular = m_usuarioDTO.Celular;
            m_usuarioVM.DocReferencia = m_usuarioDTO.DocReferencia;
            m_usuarioVM.FinVigencia = m_usuarioDTO.FinVigencia;
            m_usuarioVM.FechaUltimoLogueo = m_usuarioDTO.FechaUltimoLogueo;
            m_usuarioVM.EstadoId = m_usuarioDTO.EstadoId;
            m_usuarioVM.EstadoNombre = m_usuarioDTO.EstadoNombre;
            m_usuarioVM.UsuarioRegistro = m_usuarioDTO.UsuarioRegistro;
            m_usuarioVM.FechaRegistro = m_usuarioDTO.FechaRegistro;
            m_usuarioVM.UsuarioModificacionRegistro = m_usuarioDTO.UsuarioModificacionRegistro;
            m_usuarioVM.FechaModificacionRegistro = m_usuarioDTO.FechaModificacionRegistro;
            m_usuarioVM.UbigeoNavalId = m_usuarioDTO.UbigeoNavalId;
            m_usuarioVM.ZonaNaval = m_usuarioDTO.ZonaNaval;
            m_usuarioVM.Dependencia = m_usuarioDTO.Dependencia;
            m_usuarioVM.AvatarPath = m_usuarioDTO.AvatarPath;

            return m_usuarioVM;
        }
        public bool CambiarEstado(int UsuarioId, int estadoId, int UsuarioLogueadoId)
        {
            bool v = false;

            v = (new UsuariosBL()).CambiarEstado(UsuarioId, estadoId, UsuarioLogueadoId);
            return v;
        }


























        //public List<UsuarioViewModel> Listar_grilla(UsuarioViewModel mv)
        //{
        //    List<UsuarioViewModel> r = new List<UsuarioViewModel>();

        //    List<UsuariosBE> l = (new UsuariosBL()).ConsultarLogin(ViewModelToBE(mv));
        //    foreach (UsuariosBE m in l)
        //    {
        //        r.Add(BEToViewModel(m));
        //    }

        //    return r;
        //}
        //public List<UsuarioViewModel> Listar_grilla_inicial(UsuarioViewModel mv)
        //{
        //    List<UsuarioViewModel> r = new List<UsuarioViewModel>();

        //    List<UsuariosDTO> l = (new UsuariosBL()).Listar_grilla_inicial(ViewModelToDto(mv));
        //    foreach (UsuariosDTO m in l)
        //    {
        //        r.Add(DtoToViewModel(m));
        //    }

        //    return r;
        //}
        //public List<UsuarioViewModel> ListarUsuarios(UsuarioViewModel mv)
        //{
        //    List<UsuarioViewModel> r = new List<UsuarioViewModel>();

        //    List<UsuariosBE> l = (new UsuariosBL()).Consultar_PK(mv.UsuarioId);
        //    foreach (UsuariosBE m in l)
        //    {
        //        r.Add(BEToViewModel(m));
        //    }

        //    return r;
        //}
        //        public void BuscarPorLogin(int id)
        //        {

        //            if (id < 0) return;

        //            UsuariosBE dto = new UsuariosBE();
        //            dto.UsuarioId = id;
        //            List<UsuariosBE> l = (new UsuariosBL()).ConsultarLogin(dto);
        //            if (l.Count > 0)
        //            {
        //                this.UsuarioId = l[0].UsuarioId;
        //                this.Login = l[0].Login;
        //                this.Password = l[0].Password;
        //                this.ApePaterno = l[0].ApePaterno;
        //                this.ApeMaterno = l[0].ApeMaterno;
        //                this.Nombres = l[0].Nombres;
        //                this.DocumentoIdentidadId = l[0].DocumentoIdentidadId;
        //                this.NumeroDoc = l[0].NumeroDoc;
        //                this.FechaNacimiento = l[0].FechaNacimiento;
        //                this.Email = l[0].Email;
        //                this.Celular = l[0].Celular;
        //                this.DocReferencia = l[0].DocReferencia;
        ////                this.Cargo = l[0].Cargo;
        //                this.FinVigencia = l[0].FinVigencia;
        //                this.FechaUltimoLogueo = l[0].FechaUltimoLogueo;
        //                this.EstadoId = l[0].EstadoId;
        //                this.UsuarioRegistro = l[0].UsuarioRegistro;
        //                this.FechaRegistro = l[0].FechaRegistro;
        //                this.UsuarioModificacionRegistro = l[0].UsuarioModificacionRegistro;
        //                this.FechaModificacionRegistro = l[0].FechaModificacionRegistro;
        //                this.UbigeoNavalId = l[0].UbigeoNavalId;
        //                this.AvatarPath = l[0].AvatarPath;
        //            }
        //        }

        //private void BEToThisViewModel(UsuariosBE m_usuarioBE)
        //{
        //    this.UsuarioId = m_usuarioBE.UsuarioId;
        //    this.Login = m_usuarioBE.Login;
        //    this.TipoUsuarioId = m_usuarioBE.TipoUsuarioId;
        //    this.Password = m_usuarioBE.Password;
        //    this.ApePaterno = m_usuarioBE.ApePaterno;
        //    this.ApeMaterno = m_usuarioBE.ApeMaterno;
        //    this.Nombres = m_usuarioBE.Nombres;
        //    this.DocumentoIdentidadId = m_usuarioBE.DocumentoIdentidadId;
        //    this.NumeroDoc = m_usuarioBE.NumeroDoc;
        //    this.FechaNacimiento = m_usuarioBE.FechaNacimiento;
        //    this.Email = m_usuarioBE.Email;
        //    this.Celular = m_usuarioBE.Celular;
        //    this.DocReferencia = m_usuarioBE.DocReferencia;
        //    //this.Cargo = m_usuarioBE.Cargo;
        //    this.FinVigencia = m_usuarioBE.FinVigencia;
        //    this.FechaUltimoLogueo = m_usuarioBE.FechaUltimoLogueo;
        //    this.EstadoId = m_usuarioBE.EstadoId;
        //    this.UsuarioRegistro = m_usuarioBE.UsuarioRegistro;
        //    this.FechaRegistro = m_usuarioBE.FechaRegistro;
        //    this.UsuarioModificacionRegistro = m_usuarioBE.UsuarioModificacionRegistro;
        //    this.FechaModificacionRegistro = m_usuarioBE.FechaModificacionRegistro;
        //    this.UbigeoNavalId = m_usuarioBE.UbigeoNavalId;
        //    this.AvatarPath = m_usuarioBE.AvatarPath;
        //    //var a1 = new UbigeoNavalBL().Consultar_Lista().ToList();
        //    //var a2 = a1.Where(X => X.UbigeoNavalId == m_usuarioBE.UbigeoNavalId);
        //    //var a3 = a2.Select(p => new { ZonaNavalId = p.ZonaNavalId }).First();
        //    //var a4 = a3.ZonaNavalId;
        //    //var a5 = Convert.ToInt32(a4);
        //    this.ZonaNavalId = Convert.ToInt32(new UbigeoNavalBL().Consultar_Lista().ToList().Where(X => X.UbigeoNavalId == m_usuarioBE.UbigeoNavalId).Select(p => new { ZonaNavalId = p.ZonaNavalId }).First().ZonaNavalId);
        //    this.DependenciaId = Convert.ToInt32(new UbigeoNavalBL().Consultar_Lista().ToList().Where(X => X.UbigeoNavalId == m_usuarioBE.UbigeoNavalId).Select(p => new { DependenciaId = p.DependenciaId }).First().DependenciaId);
        //    this.ZonaNaval = new UbigeoNavalBL().Consultar_Lista().ToList().Where(X => X.UbigeoNavalId == m_usuarioBE.UbigeoNavalId).Select(p => new { ZonaNavalDescCorta = p.ZonaNavalDescCorta }).First().ToString();
        //    this.Dependencia = new UbigeoNavalBL().Consultar_Lista().ToList().Where(X => X.UbigeoNavalId == m_usuarioBE.UbigeoNavalId).Select(p => new { DependenciaDescCorta = p.DependenciaDescCorta }).First().ToString();
        //}



        #endregion
    }
}