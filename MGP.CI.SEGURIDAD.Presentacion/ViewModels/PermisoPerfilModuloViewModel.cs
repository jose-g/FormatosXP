using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class PermisoPerfilModuloViewModel
    {

        public string ErrorSMS { get; set; }
        public string InfoSMS { get; set; }

        #region "propiedades"
        public int PermisoPerfilModuloId { get; set; }
        public int? PerfilModuloId { get; set; }
        [Display(Name = "Nombre del Perfil")]
        public int? PerfilId { get; set; }
        public int? ModuloId { get; set; }
        public string PerfilNombre { get; set; }
        [Display(Name = "Nombre del Modulo")]
        public string ModuloNombre { get; set; }
        public int? PermisoId { get; set; }
        public string PermisoNombre { get; set; }
        public int EstadoId { get; set; }
        [Display(Name = "Estado Nombre")]
        public string EstadoNombre { get; set; }
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
        public List<PermisosBE> LstPermisos { get; set; }
        #endregion

        #region "Constructores"        
        public PermisoPerfilModuloViewModel() {
            LstPermisos = new List<PermisosBE>();
    }
        #endregion

        #region "Operaciones"        

        private PermisoPerfilModulosBE ViewModelToBE(PermisoPerfilModuloViewModel m_PermisoPerfilModuloVM)
        {
            PermisoPerfilModulosBE permisoPerfilModulosBE = new PermisoPerfilModulosBE();

            permisoPerfilModulosBE.PermisoPerfilModuloId = m_PermisoPerfilModuloVM.PermisoPerfilModuloId;
            permisoPerfilModulosBE.PerfilModuloId = m_PermisoPerfilModuloVM.PerfilModuloId;
            permisoPerfilModulosBE.PermisoId = m_PermisoPerfilModuloVM.PermisoId;
            permisoPerfilModulosBE.EstadoId = m_PermisoPerfilModuloVM.EstadoId;
            permisoPerfilModulosBE.UsuarioRegistro = m_PermisoPerfilModuloVM.UsuarioRegistro;
            permisoPerfilModulosBE.FechaRegistro = m_PermisoPerfilModuloVM.FechaRegistro;
            permisoPerfilModulosBE.UsuarioModificacionRegistro = m_PermisoPerfilModuloVM.UsuarioModificacionRegistro;
            permisoPerfilModulosBE.FechaModificacionRegistro = m_PermisoPerfilModuloVM.FechaModificacionRegistro;
            permisoPerfilModulosBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            LstPermisos = new PermisosBL().Consultar_Lista().Where(x => x.PermisoId == m_PermisoPerfilModuloVM.PermisoId).ToList();

            return permisoPerfilModulosBE;
        }
        private PermisoPerfilModuloViewModel BEToViewModel(PermisoPerfilModulosBE m_permisoPerfilModulosBE)
        {
            PermisoPerfilModuloViewModel permisoPerfilModuloVM = new PermisoPerfilModuloViewModel();

            permisoPerfilModuloVM.PermisoPerfilModuloId = m_permisoPerfilModulosBE.PermisoPerfilModuloId;
            permisoPerfilModuloVM.PerfilModuloId = m_permisoPerfilModulosBE.PerfilModuloId;
            permisoPerfilModuloVM.PerfilId = new PerfilModulosBL().Consultar_PK(m_permisoPerfilModulosBE.PerfilModuloId.Value).FirstOrDefault().PerfilId;
            permisoPerfilModuloVM.ModuloId = new ModulosBL().Consultar_PK(m_permisoPerfilModulosBE.PerfilModuloId.Value).FirstOrDefault().ModuloId;
            permisoPerfilModuloVM.PermisoId = m_permisoPerfilModulosBE.PermisoId;
            permisoPerfilModuloVM.EstadoId = m_permisoPerfilModulosBE.EstadoId.Value;
            permisoPerfilModuloVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_permisoPerfilModulosBE.EstadoId).FirstOrDefault().Nombre;
            permisoPerfilModuloVM.UsuarioRegistro = m_permisoPerfilModulosBE.UsuarioRegistro;
            permisoPerfilModuloVM.FechaRegistro = m_permisoPerfilModulosBE.FechaRegistro;
            permisoPerfilModuloVM.UsuarioModificacionRegistro = m_permisoPerfilModulosBE.UsuarioModificacionRegistro;
            permisoPerfilModuloVM.FechaModificacionRegistro = m_permisoPerfilModulosBE.FechaModificacionRegistro;
            permisoPerfilModuloVM.NroIpRegistro = m_permisoPerfilModulosBE.NroIpRegistro;

            permisoPerfilModuloVM.PermisoNombre = new PermisosBL().Consultar_Lista().Where(x=>x.PermisoId==m_permisoPerfilModulosBE.PermisoId).FirstOrDefault().Nombre;
            permisoPerfilModuloVM.ModuloNombre = new ModulosBL().Consultar_PK(m_permisoPerfilModulosBE.ModuloId.Value).FirstOrDefault().Nombre;
            permisoPerfilModuloVM.PerfilNombre = new PerfilesBL().Consultar_PK(m_permisoPerfilModulosBE.PerfilModuloId.Value).FirstOrDefault().Nombre;
            LstPermisos = new PermisosBL().Consultar_Lista().Where(x => x.PermisoId == m_permisoPerfilModulosBE.PermisoId).ToList();

            return permisoPerfilModuloVM;
        }
        public bool Insertar(int m_perfilModuloId, int m_permisoId, string m_login)
        {
            String out_sms_err = "";
            bool v = false;
            PermisoPerfilModulosBE permisoPerfilmoduloBE = new PermisoPerfilModulosBE();
            permisoPerfilmoduloBE.PerfilModuloId = m_perfilModuloId;
            permisoPerfilmoduloBE.PermisoId = m_permisoId;
            permisoPerfilmoduloBE.UsuarioRegistro = m_login;
            permisoPerfilmoduloBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            v = (new PermisoPerfilModulosBL()).Insertar(permisoPerfilmoduloBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            PermisoPerfilModulosBE permisoPerfilmoduloBE = new PermisoPerfilModulosBE();
            permisoPerfilmoduloBE = ViewModelToBE(this);
            v = (new PermisoPerfilModulosBL()).Insertar(permisoPerfilmoduloBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            PermisoPerfilModulosBE permisoPerfilmoduloBE = new PermisoPerfilModulosBE();
            permisoPerfilmoduloBE = ViewModelToBE(this);
            v = (new PermisoPerfilModulosBL()).Actualizar(permisoPerfilmoduloBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public void BuscarPorId(int m_permisoPerfilmoduloId)
        {
            if (m_permisoPerfilmoduloId < 0) return;

            PermisoPerfilModulosBE permisoPerfilmoduloBE = new PermisoPerfilModulosBL().Consultar_PK(m_permisoPerfilmoduloId).FirstOrDefault();

            if (permisoPerfilmoduloBE != null)
                BEToViewModel(permisoPerfilmoduloBE);
        }

        public bool Eliminar(int m_perfilModuloId, int m_permisoId, string login)
        {
            bool v = false;
            if (m_perfilModuloId < 0) return false;

            PermisoPerfilModulosBE permisoPerfilModulosBE = new PermisoPerfilModulosBL().Consultar_Lista().Where(x => x.PerfilModuloId == m_perfilModuloId && x.PermisoId == m_permisoId && x.EstadoId == 1).FirstOrDefault();
            permisoPerfilModulosBE.UsuarioModificacionRegistro = login;
            permisoPerfilModulosBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            v = new PermisoPerfilModulosBL().Anular(permisoPerfilModulosBE);

            if (v == false) this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;

        }
        public List<PermisoPerfilModuloViewModel> ListarxModuloId(int m_moduloId)
        {
            List<PermisoPerfilModuloViewModel> LstPermisosPerfilModulosViewModel = new List<PermisoPerfilModuloViewModel>();
            List<PermisoPerfilModulosBE> LstPermisoPerfilesModulosBE = (new PermisoPerfilModulosBL()).Consultar_Lista().Where(x => x.ModuloId.Value == m_moduloId).ToList();

            foreach (PermisoPerfilModulosBE permisoPerfilModulosBE in LstPermisoPerfilesModulosBE)
            {
                LstPermisosPerfilModulosViewModel.Add(BEToViewModel(permisoPerfilModulosBE));

            }
            return LstPermisosPerfilModulosViewModel;
        }
        public List<PermisoPerfilModuloViewModel> ListarxPerfilModuloId(int m_perfilModuloId)
        {
            List<PermisoPerfilModuloViewModel> LstPermisosPerfilModulosViewModel = new List<PermisoPerfilModuloViewModel>();
            List<PermisoPerfilModulosBE> LstPermisoPerfilesModulosBE = (new PermisoPerfilModulosBL()).Consultar_Lista().Where(x => x.PerfilModuloId.Value == m_perfilModuloId).ToList();

            foreach (PermisoPerfilModulosBE permisoPerfilModulosBE in LstPermisoPerfilesModulosBE)
            {
                LstPermisosPerfilModulosViewModel.Add(BEToViewModel(permisoPerfilModulosBE));

            }
            return LstPermisosPerfilModulosViewModel;
        }
        public List<PermisoPerfilModuloViewModel> ListarxPermisoId(int m_permisoId)
        {
            List<PermisoPerfilModuloViewModel> LstPermisosPerfilModulosViewModel = new List<PermisoPerfilModuloViewModel>();
            List<PermisoPerfilModulosBE> LstPermisoPerfilesModulosBE = (new PermisoPerfilModulosBL()).Consultar_Lista().Where(x => x.PermisoId.Value == m_permisoId).ToList();

            foreach (PermisoPerfilModulosBE permisoPerfilModulosBE in LstPermisoPerfilesModulosBE)
            {
                LstPermisosPerfilModulosViewModel.Add(BEToViewModel(permisoPerfilModulosBE));

            }
            return LstPermisosPerfilModulosViewModel;
        }
        public List<PermisoPerfilModuloViewModel> Listar()
        {
            List<PermisoPerfilModuloViewModel> LstPermisosPerfilModulosViewModel = new List<PermisoPerfilModuloViewModel>();
            List<PermisoPerfilModulosBE> LstPermisoPerfilesModulosBE = (new PermisoPerfilModulosBL()).Consultar_Lista();

            foreach (PermisoPerfilModulosBE permisoPerfilModulosBE in LstPermisoPerfilesModulosBE)
            {
                LstPermisosPerfilModulosViewModel.Add(BEToViewModel(permisoPerfilModulosBE));

            }
            return LstPermisosPerfilModulosViewModel;
        }
        public List<PermisoPerfilModuloViewModel> ListarxId(int m_permisosPerfilModulosId)
        {
            List<PermisoPerfilModuloViewModel> LstPermisosPerfilModulosViewModel = new List<PermisoPerfilModuloViewModel>();
            List<PermisoPerfilModulosBE> LstPermisoPerfilesModulosBE = (new PermisoPerfilModulosBL()).Consultar_Lista().Where(x => x.PermisoPerfilModuloId == m_permisosPerfilModulosId).ToList();

            foreach (PermisoPerfilModulosBE permisoPerfilModulosBE in LstPermisoPerfilesModulosBE)
            {
                LstPermisosPerfilModulosViewModel.Add(BEToViewModel(permisoPerfilModulosBE));

            }
            return LstPermisosPerfilModulosViewModel;
        }













        //public List<PermisoPerfilModuloViewModel> Listar_grilla_x_perfil()
        //{
        //    List<PermisoPerfilModuloViewModel> r = new List<PermisoPerfilModuloViewModel>();

        //    List<Permiso_Perfil_ModuloDTO> l = (new PermisoPerfilModulosBL()).Listar_grilla_x_perfil(ViewModelToDto(this));
        //    foreach (Permiso_Perfil_ModuloDTO m in l)
        //    {
        //        r.Add(DtoToViewModel(m));
        //    }

        //    return r;
        //}

        //public List<PermisoPerfilModuloViewModel> Listar_grilla_x_usuario()
        //{
        //    List<PermisoPerfilModuloViewModel> r = new List<PermisoPerfilModuloViewModel>();

        //    List<Permiso_Perfil_ModuloDTO> l = (new PermisoPerfilModulosBL()).Listar_grilla_x_usuario(ViewModelToDto(this));
        //    foreach (Permiso_Perfil_ModuloDTO m in l)
        //    {
        //        r.Add(DtoToViewModel(m));
        //    }

        //    return r;
        //}

        //public List<PermisoPerfilModuloViewModel> Listar_permiso_activo_x_perfil(int id_usuario, string key_sistema)
        //{
        //    List<PermisoPerfilModuloViewModel> r = new List<PermisoPerfilModuloViewModel>();

        //    List<Permiso_Perfil_ModuloDTO> l = (new PermisoPerfilModulosBL()).Listar_permiso_activo_x_perfil(id_usuario,  key_sistema);
        //    foreach (Permiso_Perfil_ModuloDTO m in l)
        //    {

        //        r.Add(DtoToViewModel(m));
        //    }

        //    return r;
        //}
        //public List<PermisoPerfilModuloViewModel> Listar_permiso_activo(int id_usuario, int id_sistema)
        //{
        //    List<PermisoPerfilModuloViewModel> r = new List<PermisoPerfilModuloViewModel>();

        //    List<Permiso_Perfil_ModuloDTO> l = (new PermisoPerfilModulosBL()).Listar_permiso_activo(id_usuario, id_sistema);
        //    foreach (Permiso_Perfil_ModuloDTO m in l)
        //    {

        //        r.Add(DtoToViewModel(m));
        //    }

        //    return r;
        //}
        //public bool Eliminar(int id)
        //{
        //    if (id < 0) return false;

        //    PermisoPerfilModulosBE ent = new PermisoPerfilModulosBE();
        //    ent.EstadoId = id;
        //    return (new PermisoPerfilModulosBL()).Anular(ent);
        //}
        //public bool Actualizar()
        //{
        //    bool v = false;
            
        //    PermisoPerfilModulosBE ent = new PermisoPerfilModulosBE();

        //    ent.PermisoPerfilModuloId = this.PermisoPerfilModuloId;
        //    ent.PermisoId = this.PermisoId;
        //    ent.EstadoId = this.EstadoId;
        //    ent.UsuarioRegistro= this.UsuarioRegistro;
        //    ent.UsuarioModificacionRegistro= this.UsuarioModificacionRegistro;
        //    ent.FechaRegistro= this.FechaRegistro;
        //    ent.FechaModificacionRegistro= this.FechaModificacionRegistro;
        //    ent.UsuarioModuloId= this.UsuarioModuloId;
        //    ent.ModuloId= this.ModuloId;
        //    ent.PerfilModuloId= this.PerfilModuloId; 

        //    v = (new PermisoPerfilModulosBL()).Actualizar(ent);

        //    return v;
        //}

//        public bool CambiarEstado(int idUsrMod)
//        {
//            bool v = false;
//            PermisoPerfilModulosBE ent = new PermisoPerfilModulosBE();

//            ent.PermisoPerfilModuloId = this.PermisoPerfilModuloId;
//            ent.EstadoId = this.EstadoId;
//           // ent.UsuarioModificacionRegistro = idUsrMod; // Convertir ID a nombre
//            ent.FechaModificacionRegistro = DateTime.Now;

//            v = (new PermisoPerfilModulosBL()).CambiarEstado(ent);

//            return v;
//        }

//        public bool Insertar(int idUsrCrea)
//        {
//            bool v = false;
//            int id = -1;
//            PermisoPerfilModulosBE ent = new PermisoPerfilModulosBE();

//            ent.PermisoPerfilModuloId = this.PermisoPerfilModuloId;
//            ent.PermisoId = this.PermisoId;
//            ent.PerfilModuloId = this.PerfilModuloId; 
//            ent.EstadoId = this.EstadoId;
//           // ent.UsuarioRegistro = idUsrCrea;
//            //ent.UsuarioModificacionRegistro = idUsrCrea;
//            ent.FechaRegistro = DateTime.Now;
//            ent.FechaModificacionRegistro = DateTime.Now;
//            ent.UsuarioModuloId= this.UsuarioModuloId;
//            ent.ModuloId = this.ModuloId;
//            ent.UsuarioId = this.UsuarioId; 

//            id = (new PermisoPerfilModulosBL()).Insertar(ent);
//            if (id > 0) {
//                this.PermisoPerfilModuloId = id;
//                v = true;
//            }

//            return v;
//        }

//        private PermisoPerfilModuloViewModel DtoToViewModel(Permiso_Perfil_ModuloDTO m_PermisoPerfilModuloBE)
//        {
//            PermisoPerfilModuloViewModel m_PermisoPerfilModuloVM = new PermisoPerfilModuloViewModel();

//            ModulosBL bssMod = new ModulosBL();

//            m_PermisoPerfilModuloVM.PermisoPerfilModuloId = m_PermisoPerfilModuloBE.PermisoPerfilModuloId;
//            m_PermisoPerfilModuloVM.PermisoId = m_PermisoPerfilModuloBE.PermisoId;
//            m_PermisoPerfilModuloVM.PerfilModuloId = m_PermisoPerfilModuloBE.PerfilModuloId;
//            m_PermisoPerfilModuloVM.EstadoId = m_PermisoPerfilModuloBE.EstadoId.Value;
//            m_PermisoPerfilModuloVM.UsuarioRegistro = m_PermisoPerfilModuloBE.UsuarioRegistro;
//            m_PermisoPerfilModuloVM.UsuarioModificacionRegistro = m_PermisoPerfilModuloBE.UsuarioModificacionRegistro;
//            m_PermisoPerfilModuloVM.FechaRegistro = m_PermisoPerfilModuloBE.FechaRegistro;
//            m_PermisoPerfilModuloVM.FechaModificacionRegistro = m_PermisoPerfilModuloBE.FechaModificacionRegistro;
////            m_PermisoPerfilModuloVM.UsuarioModuloId = m_PermisoPerfilModuloBE.UsuarioModuloId;
//            m_PermisoPerfilModuloVM.ModuloId = m_PermisoPerfilModuloBE.ModuloId;
//            //vm.NOMBRE_MODULO_CONCAT = bssMod.getNombreModuloConcat(dto.MODULO_ID);
//            //m_PermisoPerfilModuloVM.SistemaId = m_PermisoPerfilModuloBE.SISTEMA_ID;
//            //m_PermisoPerfilModuloVM.ModuloKey = m_PermisoPerfilModuloBE.KEY_MODULO;
//            //m_PermisoPerfilModuloVM.SistemaKey = m_PermisoPerfilModuloBE.KEY_SISTEMA;
//            m_PermisoPerfilModuloVM.SistemaNombre = m_PermisoPerfilModuloBE.NOMBRES_SISTEMA;
//            m_PermisoPerfilModuloBE.USUARIO_ID = m_PermisoPerfilModuloVM.UsuarioId;
//            m_PermisoPerfilModuloBE.PERFIL_ID = m_PermisoPerfilModuloVM.PerfilId; 

//            return m_PermisoPerfilModuloVM;
//        }

//        private Permiso_Perfil_ModuloDTO ViewModelToDto(PermisoPerfilModuloViewModel m_PermisoPerfilModuloVM)
//        {
//            Permiso_Perfil_ModuloDTO m_PermisoPerfilModuloBE = new Permiso_Perfil_ModuloDTO();

//            m_PermisoPerfilModuloBE.PermisoPerfilModuloId = m_PermisoPerfilModuloVM.PermisoPerfilModuloId;
//            m_PermisoPerfilModuloBE.PermisoId = m_PermisoPerfilModuloVM.PermisoId;
//            m_PermisoPerfilModuloBE.PerfilModuloId = m_PermisoPerfilModuloVM.PerfilModuloId;
//            m_PermisoPerfilModuloBE.EstadoId = m_PermisoPerfilModuloVM.EstadoId;
//            m_PermisoPerfilModuloBE.UsuarioRegistro = m_PermisoPerfilModuloVM.UsuarioRegistro;
//            m_PermisoPerfilModuloBE.UsuarioModificacionRegistro = m_PermisoPerfilModuloVM.UsuarioModificacionRegistro;
//            m_PermisoPerfilModuloBE.FechaRegistro = m_PermisoPerfilModuloBE.FechaRegistro;
//            m_PermisoPerfilModuloBE.FechaModificacionRegistro = m_PermisoPerfilModuloVM.FechaModificacionRegistro;
//            m_PermisoPerfilModuloBE.UsuarioModuloId = m_PermisoPerfilModuloVM.UsuarioModuloId;
//            m_PermisoPerfilModuloBE.ModuloId = m_PermisoPerfilModuloVM.ModuloId;
//            m_PermisoPerfilModuloBE.SISTEMA_ID = m_PermisoPerfilModuloVM.SistemaId;
//            m_PermisoPerfilModuloBE.NOMBRES_SISTEMA = m_PermisoPerfilModuloVM.SistemaNombre;
//            m_PermisoPerfilModuloBE.USUARIO_ID = m_PermisoPerfilModuloVM.UsuarioId;
//            m_PermisoPerfilModuloBE.PERFIL_ID = m_PermisoPerfilModuloVM.PerfilId;
//            m_PermisoPerfilModuloBE.KEY_MODULO = m_PermisoPerfilModuloVM.ModuloKey;
//            m_PermisoPerfilModuloBE.KEY_SISTEMA = m_PermisoPerfilModuloVM.SistemaKey;


//            return m_PermisoPerfilModuloBE;
//        }

        #endregion
    }
}