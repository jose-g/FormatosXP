using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.X1005;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005VinculacionesViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }

        public Int32 VinculacionesId { get; set; }


        public List<VinculosBE> LstVinculos { get; set; }
        public string VinculoDescripcion { get; set; }


        // Opinion Sistema de Gobierno
        public List<NivelesBuenoBE> LstNivelesBueno { get; set; }
        public List<OpinionMaestraBE> LstOpinionMaestra { get; set; }
        public string  OpinionMaestraDescripcion { get; set; }
        [Display(Name = "Tendencia Idiologica")]
        public string TendenciaIdelogica { get; set; }
        [Display(Name = "Linea Politica")]
        public string LineaPolitica { get; set; }

        public X1005VinculacionesViewModel()
        {
            LstVinculos = new List<VinculosBE>();
            LstNivelesBueno = new List<NivelesBuenoBE>();
            LstOpinionMaestra = new List<OpinionMaestraBE>();
            CargarTablasMaestras();
        }

        #endregion
        public void CargarTablasMaestras()
        {
            LstVinculos = new VinculosBL().Consultar_Lista();
            LstNivelesBueno = new NivelesBuenoBL().Consultar_Lista();
            LstOpinionMaestra = new OpinionMaestraBL().Consultar_Lista();
        }

    }
}