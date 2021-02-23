using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarObservacionViewModel
    {
        [Display(Name = "Observacion ")]
        public string Observacion{ get; set; }

        public AgregarObservacionViewModel()
        {

        }
    }
}