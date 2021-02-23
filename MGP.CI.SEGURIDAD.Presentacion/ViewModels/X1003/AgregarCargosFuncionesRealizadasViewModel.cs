using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarCargosFuncionesRealizadasViewModel
    {
        public int InformacionCastrenseId { get; set; }
        public int CargosFuncionesRealizadasId { get; set; }

        [Display(Name = "Cargo")]
        public int CargosFuncionesId { get; set; }

        [Display(Name = "Fecha de Inicio")]
        public DateTime? Asc_Obt_FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        public DateTime? Asc_Obt_FechaFin { get; set; }

        public List<CargosFuncionesBE> LstCargosFunciones { get; set; }
        public AgregarCargosFuncionesRealizadasViewModel()
        {
            LstCargosFunciones = new List<CargosFuncionesBE>();
            LstCargosFunciones = new CargosFuncionesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }

    }
}