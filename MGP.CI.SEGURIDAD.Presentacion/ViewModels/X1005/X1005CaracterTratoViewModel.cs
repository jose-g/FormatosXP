using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.X1005;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005CaracterTratoViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }
        public Int32 CaracterTratoId { get; set; }

        [Display(Name = "Nivel de Desarrollo Profesional")]
        public int NivelDesarrolloProfesional { get; set; }
        public string DescripcionDesarrolloProfesional { get; set; }
        [Display(Name = "Nivel de Conocimiento Intelectual")]
        public int NivelCI { get; set; }
        public string DescripcionCI { get; set; }
        [Display(Name = "Como fue el Trato con sus compañeros?")]
        public string RelacionConCompaneros { get; set; }

        public List<NivelesBuenoBE> LstNivelesBueno { get; set; }

        #endregion

        public X1005CaracterTratoViewModel()
        {
            LstNivelesBueno = new List<NivelesBuenoBE>();
        }
        public void CargarTablasMaestras()
        {
            LstNivelesBueno = new NivelesBuenoBL().Consultar_Lista();
        }

    }
}