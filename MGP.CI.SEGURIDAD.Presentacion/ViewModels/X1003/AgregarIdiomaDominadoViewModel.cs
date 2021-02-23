using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarIdiomaDominadoViewModel
    {
        public int InformacionCastrenseId { get; set; }


        [Display(Name = "Idioma")]
        public int IdiomaDominadoId { get; set; }

        [Range(typeof(int), "0", "100", ErrorMessage = "{0} Solamente se admiten valores entre {1} y {2}")]
        [Display(Name = "Hablado (%)")]
        public int IdiomaHabla{ get; set; }

        [Range(typeof(int), "0", "100", ErrorMessage = "{0} Solamente se admiten valores entre {1} y {2}")]
        [Display(Name = "Escrito (%)")]
        public int IdiomaEscrito { get; set; }

        [Range(typeof(int), "0", "100", ErrorMessage = "{0} Solamente se admiten valores entre {1} y {2}")]
        [Display(Name = "Leido (%)")]
        public int IdiomaLeido { get; set; }

        public List<IdiomaBE> LstIdiomas { get; set; }

        public AgregarIdiomaDominadoViewModel()
        {
            LstIdiomas = new List<IdiomaBE>();
            LstIdiomas = new IdiomaBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }

    }
}