using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class TablasMaestrasViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public int TablaId { get; set; }

        [Display(Name = "Nombre de la Tabla")]
        public string TablaNombre { get; set; }
        public string TablaDescripcion { get; set; }
        public int? SistemaId { get; set; } = 0;
        [Display(Name = "Sistema Nombre")]
        public string SistemaNombre{ get; set; }
        public int? EstadoId { get; set; } = 1;
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
        public String FechaModificacionRegistroStr
        {
            get
            {
                return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
            }
        }
        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        public List<SistemasBE> LstSistemas { get; set; }
        #endregion

        #region "Operaciones"        
        public TablasMaestrasViewModel()
        {
            LstSistemas = new List<SistemasBE>();
        }

        

        public List<TablasMaestrasViewModel> Consultar_listaToDatatableXp()
        {
            List<TablasMaestrasViewModel> LstTablasMaestrasVM = new List<TablasMaestrasViewModel>();

            foreach (TablasMaestrasBE tablaBE in new TablasMaestrasBL().Consultar_Lista().Where(x => x.SistemaId == 2).ToList())
                LstTablasMaestrasVM.Add(BEToViewModel(tablaBE));

            return LstTablasMaestrasVM;
        }

        public List<TablasMaestrasViewModel> Consultar_listaToDatatableSeg()
        {
            List<TablasMaestrasViewModel> LstTablasMaestrasVM = new List<TablasMaestrasViewModel>();

            foreach (TablasMaestrasBE tablaBE in new TablasMaestrasBL().Consultar_Lista().Where(x=>x.SistemaId==1).ToList())
                LstTablasMaestrasVM.Add(BEToViewModel(tablaBE));

            return LstTablasMaestrasVM;
        }
        private TablasMaestrasViewModel BEToViewModel(TablasMaestrasBE m_tablaBE)
        {
            TablasMaestrasViewModel m_tablamaestraVM = new TablasMaestrasViewModel();

            m_tablamaestraVM.TablaId = m_tablaBE.TablaId;
            m_tablamaestraVM.TablaNombre = m_tablaBE.TablaNombre;
            m_tablamaestraVM.TablaDescripcion = m_tablaBE.TablaDescripcion;
            m_tablamaestraVM.SistemaId= m_tablaBE.SistemaId;
            m_tablamaestraVM.EstadoId = m_tablaBE.EstadoId;
            m_tablamaestraVM.UsuarioRegistro = m_tablaBE.UsuarioRegistro;
            m_tablamaestraVM.FechaRegistro = m_tablaBE.FechaRegistro;
            m_tablamaestraVM.UsuarioModificacionRegistro = m_tablaBE.UsuarioModificacionRegistro;
            m_tablamaestraVM.FechaModificacionRegistro = m_tablaBE.FechaModificacionRegistro;
            m_tablamaestraVM.NroIpRegistro = m_tablaBE.NroIpRegistro;
            m_tablamaestraVM.EstadoNombre = new EstadosBL().Consultar_PK(m_tablaBE.EstadoId.Value).FirstOrDefault().Nombre;
            m_tablamaestraVM.SistemaNombre = new SistemasBL().Consultar_Lista().Find(x => x.SistemaId == m_tablaBE.SistemaId).Nombre;

            return m_tablamaestraVM;
        }
        private TablasMaestrasBE ViewModelToBE(TablasMaestrasViewModel m_tablamaestraVM)
        {
            TablasMaestrasBE m_tablaBE = new TablasMaestrasBE();

            m_tablaBE.TablaId = m_tablamaestraVM.TablaId;
            m_tablaBE.TablaNombre = m_tablamaestraVM.TablaNombre;
            m_tablaBE.TablaDescripcion = m_tablamaestraVM.TablaDescripcion;

            if (m_tablamaestraVM.SistemaId == 0)
            {
                var sistema = new SistemasBL().Consultar_Lista().Find(x => x.Nombre.ToLower().Equals(m_tablamaestraVM.SistemaNombre.ToLower()));
                if (sistema == null)
                    m_tablaBE.SistemaId = 10000;
                else
                    m_tablaBE.SistemaId = sistema.SistemaId;

            }
            else
            m_tablaBE.EstadoId = m_tablamaestraVM.EstadoId;
            m_tablaBE.UsuarioRegistro = m_tablamaestraVM.UsuarioRegistro;
            m_tablaBE.FechaRegistro = m_tablamaestraVM.FechaRegistro;
            m_tablaBE.UsuarioModificacionRegistro = m_tablamaestraVM.UsuarioModificacionRegistro;
            m_tablaBE.FechaModificacionRegistro = m_tablamaestraVM.FechaModificacionRegistro;
            m_tablaBE.NroIpRegistro = m_tablamaestraVM.NroIpRegistro;

            return m_tablaBE;
        }
        public List<TablasMaestrasViewModel> ListarTablasFiltradas(TablasMaestrasViewModel m_tablamaestraVM)
        {
            List<TablasMaestrasViewModel> LstTablamaestraVM = new List<TablasMaestrasViewModel>();
            List<TablasMaestrasBE> LstTablasMaestrasBE = (new TablasMaestrasBL()).ListarUsuariosFiltrados(ViewModelToBE(m_tablamaestraVM));

            foreach (TablasMaestrasBE usuarioDTO in LstTablasMaestrasBE)
            {
                LstTablamaestraVM.Add(BEToViewModel(usuarioDTO));
            }

            return LstTablamaestraVM;
        }


        #endregion

    }
}