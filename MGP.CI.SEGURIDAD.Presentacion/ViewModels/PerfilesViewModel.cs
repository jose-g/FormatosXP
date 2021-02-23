using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class PerfilesViewModel
    {
        public String ErrorSms { get; set; } = "";

        #region "Propiedades"        
        public int PerfilesId { get; set; }

        [Display(Name = "Nombre del Perfil")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public String Nombre { get; set; }

        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione {0}")]
        public int? EstadoId { get; set; }

        [Display(Name = "Estado")]
        public string EstadoNombre { get; set; }

        [Display(Name = "Creado por")]
        public int? UsuarioRegistroId { get; set; }

        [Display(Name = "Creado por")]
        public String UsuarioRegistroNombre { get; set; }

        [Display(Name = "Modificado por")]
        public int? UsuarioModificacionRegistroId { get; set; }

        [Display(Name = "Modificado por")]
        public String UsuarioModificacionRegistroNombre { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? FechaRegistro { get; set; }

        [Display(Name = "Fecha modificación")]
        public DateTime? FechaModificacionRegistro { get; set; }
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
        #endregion

        #region "Constructores"        
        public PerfilesViewModel() { }
        #endregion

        #region "Operaciones"        

        public List<PerfilesViewModel> Listar()
        {
            List<PerfilesViewModel> LstPerfilesViewModel = new List<PerfilesViewModel>();
            List<PerfilesBE> LstPerfilesBE = (new PerfilesBL()).Consultar_Lista();

            foreach (PerfilesBE perfilmoduloBE in LstPerfilesBE)
            {
                LstPerfilesViewModel.Add(BEToViewModel(perfilmoduloBE));

            }
            return LstPerfilesViewModel;
        }
        public bool Eliminar(int PerfilId)
        {
            bool ret = false;
            if (PerfilId < 0) return false;
            if (PerfilId < 10 )
            {
                this.ErrorSms = "No es posible eliminar el registro, es un usuario del sistema, como alternativa inhabilite al usuario.";
                return false;
            }

            PerfilesBE perfilBE = new PerfilesBL().Consultar_PK(PerfilId).FirstOrDefault();
            if (perfilBE != null)
                ret = (new PerfilesBL()).Anular(perfilBE);

            if (ret == false)
                this.ErrorSms = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        public void BuscarxId(int PerfilId)
        {
            if (PerfilId < 0) return;

            PerfilesBE perfilBE = new PerfilesBL().Consultar_PK(PerfilId).FirstOrDefault();

            if (perfilBE != null)
                BEToViewModel(perfilBE);
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            PerfilesBE perfilesBE = new PerfilesBE();
            perfilesBE = ViewModelToBE(this);
            v = (new PerfilesBL()).Insertar(perfilesBE);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            PerfilesBE perfilesBE = new PerfilesBE();
            perfilesBE = ViewModelToBE(this);
            v = (new PerfilesBL()).Actualizar(perfilesBE, ref out_sms_err);

            if (v == false) this.ErrorSms=out_sms_err;

            return v;
        }
        #endregion




        public List<PerfilesViewModel> Listar_grilla(PerfilesViewModel mv)
        {
            List<PerfilesViewModel> r = new List<PerfilesViewModel>();

            List<PerfilesBE> l = (new PerfilesBL()).Listar_grilla(ViewModelToBE(mv));
            foreach (PerfilesBE m in l)
            {
                r.Add(BEToViewModel(m));
            }

            return r;
        }
        public List<PerfilesViewModel> ListarPerfilesDisponibles(int UsuarioId)
        {
            List<PerfilesViewModel> LstPerfilesVM = new List<PerfilesViewModel>();

            List<PerfilesBE> LstPErfilesBE  = (new PerfilesBL()).ListarPerfilesDisponibles(UsuarioId);
            foreach (PerfilesBE m in LstPErfilesBE)
            {
                LstPerfilesVM.Add(BEToViewModel(m));
            }

            return LstPerfilesVM.OrderBy(x=>x.Nombre).ToList();
        }
        //public bool Eliminar(int id)
        //{
        //    bool v = false;
        //    if (id < 0) return false;

        //    PerfilesBE ent = new PerfilesBE();
        //    ent.PerfilesId = id;

        //    v = (new PerfilesBL()).Eliminar(id);

        //    if (v == false)
        //        this.ErrorSms = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

        //    return v;
        //}
        public void BuscarPorId(int id)
        {

            if (id < 0) return;

            PerfilesBE m_perfilesBE = new PerfilesBE();
            PerfilesBE perfilesBE = new PerfilesBL().Consultar_Lista().Where(x => x.PerfilesId ==id).First();
            this.PerfilesId = perfilesBE.PerfilesId;
            this.Nombre = perfilesBE.Nombre;
            this.Descripcion = perfilesBE.Descripcion;
            this.EstadoId = perfilesBE.EstadoId;
            this.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == perfilesBE.EstadoId).First().Descripcion;
            this.UsuarioRegistroId = new UsuariosBL().Consultar_Lista().Where(x => x.Login== perfilesBE.UsuarioRegistro).First().UsuarioId;
            this.FechaRegistro = perfilesBE.FechaRegistro;
            this.FechaModificacionRegistro = perfilesBE.FechaModificacionRegistro;
            this.UsuarioRegistroNombre = perfilesBE.UsuarioRegistro;
            this.UsuarioModificacionRegistroNombre = perfilesBE.UsuarioModificacionRegistro;
        }
        //public bool Actualizar()
        //{
        //    bool v = false;
        //    String sms = "";
        //    PerfilesBE ent = new PerfilesBE();

        //    ent.PerfilesId = this.PerfilesId;
        //    ent.Nombre = this.Nombre.ToUpper();
        //    ent.Descripcion = this.Descripcion;
        //    ent.EstadoId= this.EstadoId;
        //    ent.UsuarioRegistro= this.UsuarioRegistroNombre;
        //    ent.UsuarioModificacionRegistro= this.UsuarioModificacionRegistroNombre;
        //    ent.FechaRegistro = this.FechaRegistro;
        //    ent.FechaModificacionRegistro = this.FechaModificacionRegistro;

        //    v = (new PerfilesBL()).Actualizar(ent, ref sms);

        //    if (v == false)
        //        this.ErrorSms = sms;

        //    return v;
        //}
        //public bool Insertar()
        //{
        //    bool v = false;
        //    String sms = "";
        //    PerfilesBE ent = new PerfilesBE();

        //    ent.PerfilesId = this.PerfilesId;
        //    ent.Nombre = this.Nombre.ToUpper();
        //    ent.Descripcion = this.Descripcion;
        //    ent.EstadoId = this.EstadoId;
        //    ent.UsuarioRegistro = this.UsuarioRegistroNombre;
        //    ent.UsuarioModificacionRegistro = this.UsuarioModificacionRegistroNombre;
        //    ent.FechaRegistro = this.FechaRegistro;
        //    ent.FechaModificacionRegistro = this.FechaModificacionRegistro;

        //    v = (new PerfilesBL()).Insertar(ent, ref sms);

        //    if (v == false)
        //        this.ErrorSms = sms;

        //    return v;
        //}
        private PerfilesViewModel BEToViewModel(PerfilesBE m_perfilesBE)
        {
            PerfilesViewModel vm = new PerfilesViewModel();

            vm.PerfilesId = m_perfilesBE.PerfilesId;
            vm.Nombre = m_perfilesBE.Nombre;
            vm.Descripcion = m_perfilesBE.Descripcion;
            vm.EstadoId = m_perfilesBE.EstadoId;
            vm.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_perfilesBE.EstadoId).First().Nombre;
            if (m_perfilesBE.UsuarioRegistro != null)
                vm.UsuarioRegistroId = new UsuariosBL().Consultar_Lista().Where(x => x.Login == m_perfilesBE.UsuarioRegistro).First().UsuarioId;
            vm.FechaRegistro = m_perfilesBE.FechaRegistro;
            vm.FechaModificacionRegistro = m_perfilesBE.FechaModificacionRegistro;
            vm.UsuarioRegistroNombre = m_perfilesBE.UsuarioRegistro;
            vm.UsuarioModificacionRegistroNombre = m_perfilesBE.UsuarioModificacionRegistro;

            return vm;
        }
        private PerfilesBE ViewModelToBE(PerfilesViewModel vm)
        {
            PerfilesBE m_perfilesBE = new PerfilesBE();


            m_perfilesBE.PerfilesId = vm.PerfilesId;
            m_perfilesBE.Nombre = vm.Nombre;
            m_perfilesBE.Descripcion = vm.Descripcion;
            m_perfilesBE.EstadoId = vm.EstadoId;
            m_perfilesBE.UsuarioRegistro = vm.UsuarioRegistroNombre;
            m_perfilesBE.FechaRegistro = vm.FechaRegistro;
            m_perfilesBE.FechaModificacionRegistro = vm.FechaModificacionRegistro;
            m_perfilesBE.UsuarioModificacionRegistro = vm.UsuarioModificacionRegistroNombre;
            m_perfilesBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            return m_perfilesBE;
        }

    }
}