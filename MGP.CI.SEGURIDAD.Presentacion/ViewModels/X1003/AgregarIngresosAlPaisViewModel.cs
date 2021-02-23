using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarIngresosAlPaisViewModel
    {
        [Display(Name = "Fecha de Ingreso")]
        public DateTime? IngresoAlPaisFechaIngreso{ get; set; }

        [Display(Name = "Fecha de Inicio de Mision")]
        public DateTime? IngresoAlPaisFechaInicioMision { get; set; }

        [Display(Name = "Fecha de Termino de Mision")]
        public DateTime? IngresoAlPaisFechaTerminoMision { get; set; }

    }
}