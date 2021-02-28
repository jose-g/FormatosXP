using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Presentacion.Views.X1003;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarFamiliarResidentesEnPeru
    {
        [Display(Name = "Apellido Paterno")]
        public string ResidentePaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ResidenteMaterno { get; set; }
        [Display(Name = "Nombres1")]
        public string ResidenteNombre1 { get; set; }
        [Display(Name = "Nombre2")]
        public string ResidenteNombre2 { get; set; }
        [Display(Name = "Nombre3")]
        public string ResidenteNombre3 { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? ResidenteFechaNacimiento { get; set; }
        [Display(Name = "Nacionalidad")]
        public string ResidenteNacionalidadId { get; set; }
        [Display(Name = "Tipo de Documento")]
        public string ResidenteDocumentoIdentidadTipoId { get; set; }

        [Display(Name = "Numero de Documento")]
        public string ResidenteNroDocumentoIdentidad { get; set; }
        [Display(Name = "Parentesco")]
        public string ResidenteParentescoId { get; set; }

        public List<FotosFamiliaresViewModel> LstFotos { get; set; }
        public List<NacionalidadBE> LstNacionalidades { get; set; }
        public List<ParentescoBE> LstParentesco { get; set; }
        public List<DocumentoIdentidadTiposBE> LstTipoDocumentos { get; set; }

        public AgregarFamiliarResidentesEnPeru()
        {
            LstParentesco = new List<ParentescoBE>();
            LstNacionalidades = new List<NacionalidadBE>();
            LstParentesco = new ParentescoBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
            LstNacionalidades = new NacionalidadBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
            LstFotos = new List<FotosFamiliaresViewModel>();
            LstTipoDocumentos = new List<DocumentoIdentidadTiposBE>();
            LstTipoDocumentos = new DocumentoIdentidadTiposBL().Consultar_Lista().OrderBy(x => x.Descripcion).ToList();
        }


    }
}