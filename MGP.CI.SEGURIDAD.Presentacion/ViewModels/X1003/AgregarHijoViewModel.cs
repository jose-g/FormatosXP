using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using MGP.CI.SEGURIDAD.Presentacion.Views.X1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarHijoViewModel
    {
        [Display(Name = "Apellido Paterno")]
        public string HijoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string HijoMaterno { get; set; }
        [Display(Name = "Nombres1")]
        public string HijoNombre1 { get; set; }
        [Display(Name = "Nombre2")]
        public string HijoNombre2 { get; set; }
        [Display(Name = "Nombre3")]
        public string HijoNombre3 { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? HijoFechaNacimiento { get; set; }
        [Display(Name = "Tipo de Documento")]
        public string HijoDocumentoIdentidadTipoId { get; set; }

        [Display(Name = "Numero de Documento")]
        public string HijoNroDocumentoIdentidad{ get; set; }
        [Display(Name = "Nacionalidad")]
        public string HijoNacionalidadId { get; set; }


        public List<DocumentoIdentidadTiposBE> LstTipoDocumentos;
        public List<NacionalidadBE> LstNacionalidades { get; set; }
        public List<FotosFamiliaresViewModel> LstFotos { get; set; }
        public AgregarHijoViewModel()
        {
            LstTipoDocumentos = new List<DocumentoIdentidadTiposBE>();
            LstNacionalidades = new List<NacionalidadBE>();
            LstFotos = new List<FotosFamiliaresViewModel>();
            LstTipoDocumentos = new DocumentoIdentidadTiposBL().Consultar_Lista().OrderBy(x => x.Descripcion).ToList();
            LstNacionalidades = new NacionalidadBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
        }
    }
}