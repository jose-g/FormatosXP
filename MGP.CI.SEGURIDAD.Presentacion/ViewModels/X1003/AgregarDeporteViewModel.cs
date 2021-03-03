using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarDeporteViewModel
    {
        [Display(Name = "Nombre ")]
        public int OtrosDeporteId { get; set; }
        public string OtrosDeporteNombre { get { return new DeportesBL().Consultar_PK(OtrosDeporteId).FirstOrDefault().Nombre; } }

        public List<DeportesBE> LstDeportes;

        public AgregarDeporteViewModel()
        {
            LstDeportes = new List<DeportesBE>();
            LstDeportes = new DeportesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }


    }
}