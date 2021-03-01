using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.XP1005;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class BusquedaDeclaranteXP1005ViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE

        [Display(Name = "Ape. Paterno")]
        public string ApePaterno { get; set; } = "";

        [Display(Name = "Ape. Materno")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string ApeMaterno { get; set; } = "";

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = "";

        [Display(Name = "Tipo Doc. Identidad")]
        public int DocumentoIdentidadId { get; set; }

        public string DocumentoIdentidadNombre { get; set; }

        [Display(Name = "Num. Doc. Identidad")]
        public string DocumentoIdentidadNumero { get; set; }
        public int DeclaranteXP1005Id { get; set; }

        public List<DocumentoIdentidadTiposBE> LstDocumentosIdentidad;

        //[Display(Name = "Usuario Modificacion")]
        //public DateTime FechaRegistro { get; set; }

        //public String FechaRegistroStr
        //{
        //    get
        //    {
        //        return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
        //    }
        //}

        #endregion

        #region "Constructores"        
        //public BusquedaFichasXP1005ViewModel ConsultarFichasFromDeclarante(int DeclaranteId)
        //{
        //    List<BusquedaFichasXP1005ViewModel> Lstvm = new List<BusquedaFichasXP1005ViewModel>();

        //    foreach (BusquedaDeclaranteXP1005DTO result in new BusquedaDeclaranteXP1005BL().ConsultarFichasFromDeclarante(ViewModelToDTO(vm)))
        //        Lstvm.Add(DTOtoViewModel(result));

        //    return Lstvm;
        //}

        public BusquedaDeclaranteXP1005ViewModel()
        {
            LstDocumentosIdentidad = new List<DocumentoIdentidadTiposBE>();
        }
        #endregion

        public void CargarTablasMaestras()
        {
            LstDocumentosIdentidad = new DocumentoIdentidadTiposBL().Consultar_Lista();
        }
        private BusquedaDeclaranteXP1005ViewModel DTOtoViewModel(BusquedaDeclaranteXP1005DTO ent)
        {
            BusquedaDeclaranteXP1005ViewModel vm = new BusquedaDeclaranteXP1005ViewModel();

            vm.ApePaterno = ent.Paterno;
            vm.ApeMaterno = ent.Materno;
            vm.Nombres = ent.Nombres;
            vm.DeclaranteXP1005Id= ent.DeclaranteId;

            return vm;
        }
        private BusquedaDeclaranteXP1005DTO ViewModelToDTO(BusquedaDeclaranteXP1005ViewModel vm)
        {
            BusquedaDeclaranteXP1005DTO ent = new BusquedaDeclaranteXP1005DTO();

            ent.Paterno = vm.ApePaterno;
            ent.Materno = vm.ApeMaterno;
            ent.Nombres = vm.Nombres;
            ent.TipoDocumento = vm.DocumentoIdentidadId;
            ent.NroDocumento = vm.DocumentoIdentidadNumero;

            return ent;
        }

        public List<BusquedaDeclaranteXP1005ViewModel> ListarUsuariosFiltrados(BusquedaDeclaranteXP1005ViewModel vm)
        {
            List<BusquedaDeclaranteXP1005ViewModel> Lstvm = new List<BusquedaDeclaranteXP1005ViewModel>();

            foreach (BusquedaDeclaranteXP1005DTO result in new BusquedaDeclaranteXP1005BL().ListarUsuariosFiltrados(ViewModelToDTO(vm)))
                Lstvm.Add(DTOtoViewModel(result));

            return Lstvm;
        }


    }
}