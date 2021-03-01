using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.X1005;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005ViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }

        public X1005DatosGeneralesViewModel X1005DatosGeneralesVM;
        public X1005CaracterTratoViewModel X1005CaracterTratoVM;
        public X1005ActividadesEnElPaisViewModel X1005ActividadesVM;
        public X1005VinculacionesViewModel X1005VinculacionesVM;
        public X1005PerfilPsicologicoViewModel X1005PerfilPsicologicoVM;
        public X1005ObservacionesViewModel X1005ObservacionesVM;

        #endregion

        public X1005ViewModel()
        {
            X1005DatosGeneralesVM = new X1005DatosGeneralesViewModel();
            X1005CaracterTratoVM = new X1005CaracterTratoViewModel();
            X1005ActividadesVM = new X1005ActividadesEnElPaisViewModel();
            X1005VinculacionesVM = new X1005VinculacionesViewModel();
            X1005PerfilPsicologicoVM = new X1005PerfilPsicologicoViewModel();
            X1005ObservacionesVM = new X1005ObservacionesViewModel();
        }

        public bool CrearNuevaFichaXP1005(string login, int DeclaranteId)
        {
            bool v = false;

            FichasBE fichaBE = new FichasBE();
            fichaBE.FichaId = new FichasBL().GetMaxId() + 1;
            fichaBE.FichaTipoId = 2;
            fichaBE.DeclaranteId = DeclaranteId;
            fichaBE.EstadoFichaId = 2;
            fichaBE.UsuarioRegistro = login;
            fichaBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            if (new FichasBL().Insertar(fichaBE) == false)
            {
                this.ErrorSMS = "Error crear Ficha";
                return false;
            }
            this.FichaId = fichaBE.FichaId;

            X1005DatosGeneralesVM.DatosGeneralesId = new DatosGenerales1005BL().GetMaxId() + 1;
            X1005DatosGeneralesVM.FichaId = this.FichaId;
            X1005DatosGeneralesVM.DeclaranteId = DeclaranteId;

            X1005CaracterTratoVM.CaracterTratoId = new CaracterTrato1005BL().GetMaxId() + 1;
            X1005CaracterTratoVM.FichaId = this.FichaId;
            X1005CaracterTratoVM.DeclaranteId = DeclaranteId;

            X1005ActividadesVM.ActividadesEnElPaisId = new ActividadesIntoPais1005BL().GetMaxId() + 1;
            X1005ActividadesVM.FichaId = this.FichaId;
            X1005ActividadesVM.DeclaranteId = DeclaranteId;

            X1005VinculacionesVM.VinculacionesId= new Vinculaciones1005BL().GetMaxId() + 1;
            X1005VinculacionesVM.FichaId = this.FichaId;
            X1005VinculacionesVM.DeclaranteId = DeclaranteId;

            X1005PerfilPsicologicoVM.PerfilPsicologicoId = new PerfilPsicologico1005BL().GetMaxId() + 1;
            X1005PerfilPsicologicoVM.FichaId = this.FichaId;
            X1005PerfilPsicologicoVM.DeclaranteId = DeclaranteId;

            X1005ObservacionesVM.ObservacionesId = new Observaciones1005BL().GetMaxId() + 1;
            X1005ObservacionesVM.FichaId = this.FichaId;
            X1005ObservacionesVM.DeclaranteId = DeclaranteId;

            return v;
        }

        public void CargarTablasMaestras()
        {
            X1005DatosGeneralesVM.CargarTablasMaestras();
            X1005CaracterTratoVM.CargarTablasMaestras();
            X1005ActividadesVM.CargarTablasMaestras();
            X1005VinculacionesVM.CargarTablasMaestras();
            X1005PerfilPsicologicoVM.CargarTablasMaestras();
            X1005ObservacionesVM.CargarTablasMaestras();
        }

        private X1005ViewModel BEToViewModel(FichasBE m_BE)
        {
            X1005ViewModel m_vmM = new X1005ViewModel();


            return m_vmM;
        }

        public X1005ViewModel BuscarxId(int m_FichaId)
        {
            FichasBE m_BE = new FichasBL().Consultar_PK(m_FichaId).FirstOrDefault();

            if (m_BE != null)
                return BEToViewModel(m_BE);

            return null;
        }

    }
}