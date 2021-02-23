using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarCondecoracionesViewModel
    {
        public int InformacionCastrenseId { get; set; }

        public int CondecoracionesObtenidasId { get; set; }

        [Display(Name = "Pais")]
        public int Condecoraciones_PaisId { get; set; }

        [Display(Name = "Institucion Militar")]
        public int Condecoraciones_InstitucionMilitarExtranjeraId { get; set; }


        [Display(Name = "Condecoracion")]
        public int CondecoracionesExtranjerasId { get; set; }

        [Display(Name = "Año")]
        public DateTime? CondecoracionesExtranjerasAno { get; set; }

        public List<PaisesBE> LstPaises;
        public List<InstitucionesMilitaresExtranjerasBE> LstInstitucionMilitaresExtranjeras;
        public List<CondecoracionesExtranjerasBE> LstCondecoracionesExtranjeras;

        public AgregarCondecoracionesViewModel()
        {
            LstPaises = new List<PaisesBE>();
            LstInstitucionMilitaresExtranjeras = new List<InstitucionesMilitaresExtranjerasBE>();
            LstCondecoracionesExtranjeras = new List<CondecoracionesExtranjerasBE>();
            LstPaises = new PaisesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }


    }
}