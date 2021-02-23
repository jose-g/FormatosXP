using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class ModulosViewModel
    {
        public String ErrorSms { get; set; } = "";

        #region "Propiedades"        

        public int ModuloId { get; set; }
        [Display(Name = "SistemaId")]
        public int SistemaId { get; set; }
        [Display(Name = "Nombre del Sistema")]
        public string SistemaNombre { get; set; }
        [Display(Name = "Id Modulo Padre")]
        public int? ModuloPadreId { get; set; }
        [Display(Name = "Nombre del Modulo")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion del Modulo")]
        public string Descripcion { get; set; }
        [Display(Name = "Display del Modulo")]
        public bool MenuDisplay { get; set; }
        [Display(Name = "Icono del Menu")]
        public string MenuIcono { get; set; }
        [Display(Name = "Nombre del Menu")]
        public string MenuNombre { get; set; }
        [Display(Name = "Path Vista")]
        public string MenuPath { get; set; }
        [Display(Name = "Prioridad Menu")]
        public int MenuPrioridad { get; set; }
        [Display(Name = "Estado Id")]
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
        public List<PerfilModulosBE> LstPerfilModulosBE { get; set; }

        #endregion

        #region "Constructores"        

        public ModulosViewModel() {
            LstPerfilModulosBE = new List<PerfilModulosBE>();
        }

        #endregion

        #region "Operaciones"        


        public List<ModulosViewModel> ListarxSistema(ModulosViewModel m_moduloVM)
        {
            List<ModulosViewModel> LstModulosViewModel = new List<ModulosViewModel>();

            List<ModulosBE> LstModulosBE = (new ModulosBL()).Consultar_Lista().Where(x => x.SistemaId == m_moduloVM.SistemaId).OrderBy(x => x.SistemaId).OrderBy(x => x.ModuloId).ToList();

            foreach (ModulosBE moduloBE in LstModulosBE)
            {
                LstModulosViewModel.Add(BEToViewModel(moduloBE));
            }

            return LstModulosViewModel;
        }
        public List<ModulosViewModel> Listar(ModulosViewModel m_moduloVM)
        {
                List<ModulosViewModel> LstModulosViewModel = new List<ModulosViewModel>();

                List<ModulosBE> LstModulosBE = (new ModulosBL()).Consultar_Lista();

                foreach (ModulosBE moduloBE in LstModulosBE)
                {
                LstModulosViewModel.Add(BEToViewModel(moduloBE));

                }

                return LstModulosViewModel;



            //ModulosViewModel moduloVM = new ModulosViewModel();
            //List<ModulosBE> LstModulosBE= new List<ModulosBE>();

            //if (m_moduloVM.ModuloId > 0)
            //    m_moduloVM.SistemaId = null;

            //List<ModulosViewModel> r = new List<ModulosViewModel>();

            //if (m_moduloVM.ModuloPadreId == null || m_moduloVM.ModuloPadreId <= 0)
            //{
            //    moduloVM.SistemaId = m_moduloVM.SistemaId;
            //    ModulosBE moduloBE = (new ModulosBL()).Consultar_Lista().Where(x => x.SistemaId == m_moduloVM.SistemaId).FirstOrDefault();
            //}
            //else
            //{
            //    moduloVM.ModuloPadreId = m_moduloVM.ModuloPadreId;
            //    LstModulosBE = (new ModulosBL()).Listar_grilla_x_modpadre(ViewModelToBE(moduloVM));
            //}

            //foreach (ModulosBE m in LstModulosBE)
            //{
            //    r.Add(BEToViewModel(m));
            //}

            //return r;
        }
        public bool Eliminar(int m_moduloId)
        {
            bool v = false;
            if (m_moduloId < 0) return false;

            v = (new ModulosBL()).Anular(new ModulosBL().Consultar_PK(m_moduloId).FirstOrDefault());

            if (v == false) this.ErrorSms = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;

        }
        public void BuscarPorId(int id)
        {
            if (id < 0) return;

            ModulosBE moduloBE = new ModulosBL().Consultar_PK(id).FirstOrDefault();

            if (moduloBE != null)
                BEToViewModel(moduloBE);
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            ModulosBE moduloBE = new ModulosBE();
            moduloBE = ViewModelToBE(this);
            v = (new ModulosBL()).Actualizar(moduloBE, ref out_sms_err);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            ModulosBE sistemasBE = new ModulosBE();
            sistemasBE = ViewModelToBE(this);
            v = (new ModulosBL()).Insertar(sistemasBE, ref out_sms_err);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        private ModulosViewModel BEToViewModel(ModulosBE m_modulosBE)
        {
            ModulosViewModel modulosVM = new ModulosViewModel();

            modulosVM.ModuloId = m_modulosBE.ModuloId;
            modulosVM.Nombre = m_modulosBE.Nombre;
            modulosVM.ModuloPadreId = m_modulosBE.ModuloPadreId;
            modulosVM.Nombre = m_modulosBE.Nombre;
            modulosVM.Descripcion = m_modulosBE.Descripcion;
            modulosVM.MenuDisplay = m_modulosBE.MenuDisplay;
            modulosVM.MenuIcono = m_modulosBE.MenuIcono;
            modulosVM.EstadoId = m_modulosBE.EstadoId;
            modulosVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_modulosBE.EstadoId).FirstOrDefault().Nombre;
            modulosVM.MenuNombre = m_modulosBE.MenuNombre;
            modulosVM.MenuPath = m_modulosBE.MenuPath;
            modulosVM.MenuPrioridad = m_modulosBE.MenuPrioridad;
            modulosVM.UsuarioRegistro = m_modulosBE.UsuarioRegistro;
            modulosVM.FechaRegistro = m_modulosBE.FechaRegistro;
            modulosVM.UsuarioModificacionRegistro = m_modulosBE.UsuarioModificacionRegistro;
            modulosVM.FechaModificacionRegistro = m_modulosBE.FechaModificacionRegistro;
            modulosVM.NroIpRegistro = m_modulosBE.NroIpRegistro;
            modulosVM.LstPerfilModulosBE = new PerfilModulosBL().Consultar_Lista().Where(x => x.ModuloId == m_modulosBE.ModuloId).ToList();
            return modulosVM;
        }
        private ModulosBE ViewModelToBE(ModulosViewModel m_modulosVM)
        {
            ModulosBE modulosBE = new ModulosBE();

            modulosBE.ModuloId = m_modulosVM.ModuloId;
            modulosBE.SistemaId = m_modulosVM.SistemaId;
            modulosBE.Nombre = m_modulosVM.Nombre;
            modulosBE.ModuloPadreId = m_modulosVM.ModuloPadreId;
            modulosBE.Nombre = m_modulosVM.Nombre;
            modulosBE.Descripcion = m_modulosVM.Descripcion;
            modulosBE.MenuDisplay = m_modulosVM.MenuDisplay;
            modulosBE.MenuIcono = m_modulosVM.MenuIcono;
            modulosBE.EstadoId = m_modulosVM.EstadoId;
            modulosBE.MenuNombre = m_modulosVM.MenuNombre;
            modulosBE.MenuPath = m_modulosVM.MenuPath;
            modulosBE.MenuPrioridad = m_modulosVM.MenuPrioridad;
            modulosBE.UsuarioRegistro = m_modulosVM.UsuarioRegistro;
            modulosBE.FechaRegistro = m_modulosVM.FechaRegistro;
            modulosBE.UsuarioModificacionRegistro = m_modulosVM.UsuarioModificacionRegistro;
            modulosBE.FechaModificacionRegistro = m_modulosVM.FechaModificacionRegistro;
            modulosBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return modulosBE;
        }

        #endregion

    }
}