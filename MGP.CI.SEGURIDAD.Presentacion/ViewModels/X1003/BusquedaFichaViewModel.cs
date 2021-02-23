using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.ClaseDTO;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class BusquedaFichaViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public int Ficha1003Id { get; set; }
        public int DatosPersonalesId { get; set; }
        
        [Display(Name = "Usuario Modificacion")]
        public DateTime FechaRegistro { get; set; }

        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }

        #endregion

        #region "Constructores"        

        public BusquedaFichaViewModel()
        {
            
        }
        #endregion

        #region "Operaciones"





        private BusquedaFichaViewModel DTOtoViewModel(BusquedaFichaXP1003DTO ent)
        {
            BusquedaFichaViewModel vm = new BusquedaFichaViewModel();

            vm.Ficha1003Id = ent.Ficha1003Id;
            vm.DatosPersonalesId = ent.DatosPersonalesId;
            vm.FechaRegistro = ent.FechaRegistro.Value;

            return vm;
        }

        private BusquedaFichaXP1003DTO ViewModelToDTO(BusquedaFichaViewModel vm)
        {
            BusquedaFichaXP1003DTO ent = new BusquedaFichaXP1003DTO();

            ent.Ficha1003Id = vm.Ficha1003Id;
            ent.DatosPersonalesId = vm.DatosPersonalesId;
            ent.FechaRegistro = vm.FechaRegistro;

            return ent;
        }


        public List<BusquedaFichaViewModel> ListarFichasFiltrados(BusquedaFichaViewModel vm)
        {
            List<BusquedaFichaViewModel> Lstvm = new List<BusquedaFichaViewModel>();

            foreach (BusquedaFichaXP1003DTO result in new BusquedaFichaBL().ListarFichasFiltrados(ViewModelToDTO(vm)))
            Lstvm.Add(DTOtoViewModel(result));

            return Lstvm;
        }



        #endregion


    }
}