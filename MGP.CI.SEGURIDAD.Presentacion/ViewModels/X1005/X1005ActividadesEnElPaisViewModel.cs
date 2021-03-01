using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005ActividadesEnElPaisViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }
        public Int32 ActividadesEnElPaisId { get; set; }
        #endregion

        public void CargarTablasMaestras()
        {

        }

    }
}