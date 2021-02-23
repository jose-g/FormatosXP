using MGP.CI.SEGURIDAD.Entidades.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003OtrosViewModel
    {
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public int OtrosId { get; set; }


        [Display(Name = "Subir CV : ")]
        public string PathCV { get; set; }
        public Int32 X1003OtrosId { get; set; }



        //[Display(Name = "Adjuntar CV : ")]

        //public HttpPostedFileBase File { get; set; }

        public X1003OtrosViewModel()
        {

        }

        public void CargarTablasMaestras()
        {

        }

    }
}