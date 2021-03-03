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
        public string Condecoraciones_PaisNombre { get { return new PaisesBL().Consultar_PK(Condecoraciones_PaisId).FirstOrDefault().Descripcion; } }

        [Display(Name = "Institucion Militar")]
        public int Condecoraciones_InstitucionMilitarExtranjeraId { get; set; }
        public string Condecoraciones_InstitucionMilitarExtranjeraNombre { get { return new InstitucionesMilitaresExtranjerasBL().Consultar_PK(Condecoraciones_InstitucionMilitarExtranjeraId).FirstOrDefault().Descripcion; } }


        [Display(Name = "Condecoracion")]
        public int CondecoracionesExtranjerasId { get; set; }
        public string CondecoracionesExtranjerasNombre { get { return new CondecoracionesExtranjerasBL().Consultar_PK(CondecoracionesExtranjerasId).FirstOrDefault().Nombre; } }

        [Display(Name = "Año")]
        public int? CondecoracionesExtranjerasAno { get; set; }

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