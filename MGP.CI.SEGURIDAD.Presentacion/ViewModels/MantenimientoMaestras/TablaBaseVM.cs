using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class TablaBaseVM
    {
        public string ErrorSMS { get; set; }
        #region PropiedadesBE
        [Display(Name = "Nombre")]
        public string TablaNombre { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        public int? Id { get; set; } = 0;
        public int? Codigo { get; set; } = 0;
        public int? EstadoId { get; set; } = 1;
        [Display(Name = "Estado Nombre")]
        public string EstadoNombre { get; set; }
        [Display(Name = "Usuario Registro")]
        public string UsuarioRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public string UsuarioModificacionRegistro { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime? FechaModificacionRegistro { get; set; }
        [Display(Name = "IP de Registro")]
        public string NroIpRegistro { get; set; }
        public String FechaModificacionRegistroStr
        {
            get
            {
                return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
            }
        }
        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        #endregion
        #region constructor
        public TablaBaseVM()
        {
        }
        #endregion
    }
}