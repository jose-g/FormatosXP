using MGP.CI.SEGURIDAD.Entidades.XP1005;
using MGP.CI.SEGURIDAD.Negocio.XP1005;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class BusquedaFichasXP1005ViewModel
    {
        public int FichaId { get; set; }
        public int TipoFichaId { get; set; }
        public DateTime? FechaRegistro;
        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        public string TipoFichaStr { get; set; }
        public int NroFamiliares { get; set; }
        public int NroIdentificaciones { get; set; }

        public BusquedaFichasXP1005ViewModel()
        {
        }

        private BusquedaFichasXP1005ViewModel BEtoViewModel(BusquedaFichasXP1005BE ent)
        {
            BusquedaFichasXP1005ViewModel vm = new BusquedaFichasXP1005ViewModel();
            vm.FechaRegistro = ent.FechaRegistro;
            vm.FichaId = ent.FichaId;
            vm.TipoFichaId = ent.TipoFichaId;
            vm.TipoFichaStr = "XP 1003";
            vm.NroFamiliares = ent.NroFamiliares;
            vm.NroIdentificaciones = ent.NroIdentificaciones;

            return vm;
        }
        private BusquedaFichasXP1005BE ViewModelToBE(BusquedaFichasXP1005ViewModel vm)
        {
            BusquedaFichasXP1005BE ent = new BusquedaFichasXP1005BE();
            ent.FichaId = vm.FichaId;
            ent.TipoFichaId = vm.TipoFichaId;
            ent.NroFamiliares = vm.NroFamiliares;
            ent.NroIdentificaciones = vm.NroIdentificaciones;
            ent.FechaRegistro = vm.FechaRegistro;

            return ent;
        }

        public List<BusquedaFichasXP1005ViewModel> ListarFichasFromDeclarante(int DeclaranteId)
        {
            List<BusquedaFichasXP1005ViewModel> Lstvm = new List<BusquedaFichasXP1005ViewModel>();

            foreach (BusquedaFichasXP1005BE result in new BusquedaFichasXP1005BL().ListarFichasFromDeclarante(DeclaranteId))
                Lstvm.Add(BEtoViewModel(result));

            return Lstvm;
        }


    }
}