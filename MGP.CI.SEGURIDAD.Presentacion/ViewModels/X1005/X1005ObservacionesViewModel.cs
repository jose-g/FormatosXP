using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.X1005;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005ObservacionesViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }

        public int ObservacionesDetallesId { get; set; }

        public int ObservacionesId { get; set; }

        public int ObservacionesTipoId { get; set; }

        public string Hechos { get; set; }

        public string Observaciones { get; set; }

        public string EstadoId { get; set; }

        public List<Observaciones1005TipoBE> LstTipoObservaciones;

        #endregion

        public X1005ObservacionesViewModel()
        {
            LstTipoObservaciones = new List<Observaciones1005TipoBE>();
        }
        public void CargarTablasMaestras()
        {
            LstTipoObservaciones = new Observaciones1005TipoBL().Consultar_Lista().ToList();
        }

    }
}