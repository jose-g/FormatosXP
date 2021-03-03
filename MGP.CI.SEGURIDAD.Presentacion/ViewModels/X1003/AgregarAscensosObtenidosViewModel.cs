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
        public int? Asc_Obt_PaisId{ get; set; }
        public string Asc_Obt_PaisNombre { get { return new PaisesBL().Consultar_PK(Asc_Obt_PaisId.Value).FirstOrDefault().Descripcion; } }

        [Display(Name = "Institucion Militar")]
        public int? Asc_Obt_InstitucionMilitarExtranjeraId { get; set; }
        public String Asc_Obt_InstitucionMilitarExtranjeraNombre { get { return new InstitucionesMilitaresExtranjerasBL().Consultar_PK(Asc_Obt_InstitucionMilitarExtranjeraId.Value).FirstOrDefault().Descripcion; } }

        [Display(Name = "Grado")]
        public int Asc_Obt_GradoId { get; set; }
        public string Asc_Obt_GradoNombre { get { return new GradosExtranjerosBL().Consultar_PK(Asc_Obt_GradoId).FirstOrDefault().Descripcion; } }

        [Display(Name = "Año")]
        public int? Asc_Obt_Fecha{ get; set; }


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