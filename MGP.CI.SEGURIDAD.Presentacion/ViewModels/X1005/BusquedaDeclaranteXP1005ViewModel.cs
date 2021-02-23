using MGP.CI.SEGURIDAD.Entidades;
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

        public BusquedaDeclaranteXP1005ViewModel()
        {
            LstDocumentosIdentidad = new List<DocumentoIdentidadTiposBE>();
        }
        #endregion
    }
}