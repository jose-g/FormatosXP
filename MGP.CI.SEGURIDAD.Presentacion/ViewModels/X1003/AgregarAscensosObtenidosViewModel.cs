using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarAscensosObtenidosViewModel
    {
        public int InformacionCastrenseId { get; set; }
        public int AscensosObtenidosId { get; set; }

        [Display(Name = "Pais")]
        public int Asc_Obt_PaisId{ get; set; }

        [Display(Name = "Institucion Militar")]
        public int Asc_Obt_InstitucionMilitarExtranjeraId { get; set; }

        [Display(Name = "Grado")]
        public int Asc_Obt_GradoId { get; set; }

        [Display(Name = "Año")]
        public DateTime? Asc_Obt_Fecha{ get; set; }


        public List<PaisesBE> LstPaises;
        public List<InstitucionesMilitaresExtranjerasBE> LstInstitucionMilitaresExtranjeras;
        public List<GradosExtranjerosBE> LstGradosExtranjeros;

        public AgregarAscensosObtenidosViewModel()
        {
            LstPaises = new List<PaisesBE>();
            LstInstitucionMilitaresExtranjeras = new List<InstitucionesMilitaresExtranjerasBE>();
            LstGradosExtranjeros = new List<GradosExtranjerosBE>();
            LstPaises = new PaisesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
    }
}
}