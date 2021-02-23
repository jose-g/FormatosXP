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
    public class BusquedaDeclaranteViewModel
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

        public int Ficha1003Id { get; set; }

        public List<DocumentoIdentidadTiposBE> LstDocumentosIdentidad;

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

        public BusquedaDeclaranteViewModel()
        {
            LstDocumentosIdentidad = new List<DocumentoIdentidadTiposBE>();
        }
        #endregion

        #region "Operaciones"

        public void CargarTablasMaestras()
        {
            CargarListaDocumentosIdentidad();
        }

        public void CargarListaDocumentosIdentidad()
        {
            LstDocumentosIdentidad = new DocumentoIdentidadTiposBL().Consultar_Lista().OrderBy(x => x.Descripcion).ToList();
        }

        private BusquedaDeclaranteViewModel DTOtoViewModel(BusquedaDeclaranteXP1003DTO ent)
        {
            BusquedaDeclaranteViewModel vm = new BusquedaDeclaranteViewModel();


            vm.ApePaterno = ent.Paterno;
            vm.ApeMaterno = ent.Materno;
            vm.Nombres = ent.Nombres;
            vm.DocumentoIdentidadId= ent.TipoDocumento;
            vm.DocumentoIdentidadNombre = new DocumentoIdentidadTiposBL().Consultar_PK(vm.DocumentoIdentidadId).FirstOrDefault().Descripcion;
            vm.Ficha1003Id = ent.Ficha1003Id;
            vm.FechaRegistro = ent.FechaRegistro.Value;

            return vm;
        }

        private BusquedaDeclaranteXP1003DTO ViewModelToDTO(BusquedaDeclaranteViewModel vm)
        {
            BusquedaDeclaranteXP1003DTO ent = new BusquedaDeclaranteXP1003DTO();

            ent.Paterno = vm.ApePaterno;
            ent.Materno = vm.ApeMaterno;
            ent.Nombres = vm.Nombres;
            ent.TipoDocumento = vm.DocumentoIdentidadId;
            ent.NroDocumento = vm.DocumentoIdentidadNombre;
            ent.Ficha1003Id = vm.Ficha1003Id;
            ent.FechaRegistro = vm.FechaRegistro;

            return ent;
        }


        public List<BusquedaDeclaranteViewModel> ListarUsuariosFiltrados(BusquedaDeclaranteViewModel vm)
        {
            List<BusquedaDeclaranteViewModel> Lstvm = new List<BusquedaDeclaranteViewModel>();

            foreach (BusquedaDeclaranteXP1003DTO result in new BusquedaDeclaranteBL().ListarUsuariosFiltrados(ViewModelToDTO(vm)))
            Lstvm.Add(DTOtoViewModel(result));

            return Lstvm;
        }



        #endregion


    }
}