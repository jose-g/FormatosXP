using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarDocumentoViewModel
    {
        [Display(Name = "Numero de Documento")]
        public string NroDocumentoIdentidad { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string DocumentoIdentidadTipoId { get; set; }

        public string DocumentoIdentidadTipoNombre { get { return LstTipoDocumentos.Find(x => x.DocumentoIdentidadTipoId == int.Parse(DocumentoIdentidadTipoId)).Descripcion; } }

        public List<DocumentoIdentidadTiposBE> LstTipoDocumentos;

        public AgregarDocumentoViewModel()
        {
            LstTipoDocumentos = new List<DocumentoIdentidadTiposBE>();
            LstTipoDocumentos = new DocumentoIdentidadTiposBL().Consultar_Lista().OrderBy(x => x.Descripcion).ToList();
        }


    }
}