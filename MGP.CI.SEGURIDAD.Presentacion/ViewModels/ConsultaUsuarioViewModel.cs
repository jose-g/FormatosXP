using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Entidades;
using System.ComponentModel.DataAnnotations;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class ConsultaUsuarioViewModel
    {
        public string ErrorSMS { get; set; } = "";

        [Display(Name = "Nro de DNI")]
        public string NumeroDocConsulta { get; set; }

        [Display(Name = "Ape. Paterno")]
        public string ApePaterno { get; set; } = "";

        [Display(Name = "Ape. Materno")]
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string ApeMaterno { get; set; } = "";

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = "";

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo{ get; set; }

        public int SexoId { get; set; }

        public string TipoFuente { get; set; }

        public List<string> LstFuentes { get; set; }

        public ConsultaUsuarioViewModel()
        {
            LstFuentes = new List<string>() { "Declarantes", "Recursos Humanos", "Reniec" };
        }
    }
}