using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarCursoRealizadoViewModel
    {
        public int InformacionCastrenseId { get; set; }

        public int CursosRealizadosId { get; set; }

        [Display(Name = "Año")]
        public int? CR_Ano{ get; set; }


        [Display(Name = "Curso")]
        public int CR_CursoEscuelaExtranjeraId { get; set; }
        public string CR_CursoEscuelaExtranjeraNombre { get { return new CursosEscuelasExtranjerasBL().Consultar_PK(CR_CursoEscuelaExtranjeraId).FirstOrDefault().Nombre; } }

        [Display(Name = "Escuela Extranjera")]
        public int CR_EscuelaExtranjeraId { get; set; }
        public string CR_EscuelaExtranjeraNombre { get { return new EscuelasExtranjerasBL().Consultar_PK(CR_EscuelaExtranjeraId).FirstOrDefault().Descripcion; } }

        [Display(Name = "Institucion Militar")]
        public int CR_InstitucionMilitaresExtranjerasId { get; set; }
        public string CR_InstitucionMilitaresExtranjerasNombre { get { return new InstitucionesMilitaresExtranjerasBL().Consultar_PK(CR_InstitucionMilitaresExtranjerasId).FirstOrDefault().Descripcion; } }

        [Display(Name = "Pais")]
        public int CR_PaisId { get; set; }
        public string CR_PaisNombre { get { return new PaisesBL().Consultar_PK(CR_PaisId).FirstOrDefault().Descripcion; } }



        public List<CursosEscuelasExtranjerasBE> LstCursosEscuelasExtranjeras;
        public List<EscuelasExtranjerasBE> LstEscuelasExtranjeras;
        public List<PaisesBE> LstPaises;
        public List<InstitucionesMilitaresExtranjerasBE> LstInstitucionMilitaresExtranjeras;


        public AgregarCursoRealizadoViewModel()
        {
            LstPaises = new List<PaisesBE>();
            LstInstitucionMilitaresExtranjeras = new List<InstitucionesMilitaresExtranjerasBE>();
            LstEscuelasExtranjeras = new List<EscuelasExtranjerasBE>();
            LstCursosEscuelasExtranjeras = new List<CursosEscuelasExtranjerasBE>();
            LstPaises = new PaisesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }
    }
}