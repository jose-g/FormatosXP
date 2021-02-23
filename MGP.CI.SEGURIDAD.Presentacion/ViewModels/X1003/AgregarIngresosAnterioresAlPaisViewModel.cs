using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarIngresosAnterioresAlPaisViewModel
    {
        [Display(Name = "Fecha de Ingreso")]
        public DateTime? IngresoAnteriorFechaIngreso { get; set; }

        [Display(Name = "Fecha de Salida")]
        public DateTime? IngresoAnteriorFechaSalida { get; set; }

        [Display(Name = "Destino")]
        public string IngresoAnteriorDestino { get; set; }

        [Display(Name = "Motivo")]
        public string IngresoAnteriorMotivo { get; set; }

        [Display(Name = "Donde Residio")]
        public string IngresoAnteriorDondeResidio { get; set; }
    }
}