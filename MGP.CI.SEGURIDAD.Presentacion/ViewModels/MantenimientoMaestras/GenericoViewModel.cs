using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.MantenimientoMaestras
{
    public class GenericoViewModel<VM,BE>
    {
        public delegate void MiDelegado();


        //public string ErrorSMS { get; set; }
        #region PropiedadesBE
        //[Display(Name = "Nombre")]
        //public string TablaNombre { get; set; }
        //[Display(Name = "Descripcion")]
        //public string Descripcion { get; set; }
        //public int? Id { get; set; } = 0;
        //public int? Codigo{ get; set; } = 0;
        //public int? EstadoId { get; set; } = 1;
        //[Display(Name = "Estado Nombre")]
        //public string EstadoNombre { get; set; }
        //[Display(Name = "Usuario Registro")]
        //public string UsuarioRegistro { get; set; }
        //[Display(Name = "Fecha Registro")]
        //public DateTime? FechaRegistro { get; set; }
        //[Display(Name = "Usuario Modificacion")]
        //public string UsuarioModificacionRegistro { get; set; }
        //[Display(Name = "Fecha de Modificacion")]
        //public DateTime? FechaModificacionRegistro { get; set; }
        //[Display(Name = "IP de Registro")]
        //public string NroIpRegistro { get; set; }
        //public String FechaModificacionRegistroStr
        //{
        //    get
        //    {
        //        return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
        //    }
        //}
        //public String FechaRegistroStr
        //{
        //    get
        //    {
        //        return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
        //    }
        //}
        public List<VM> LstTipo{ get; set; }


        //Action<string> CONSULTARLISTA;
        // Action @static = (new DocumentoIdentidadTiposBL()).Consultar_Lista();
        //MiDelegado delegado = new MiDelegado(new DocumentoIdentidadTiposBL()).Consultar_Lista());


        #endregion

        #region "Constructor"        
        public GenericoViewModel()
        {
            LstTipo = new List<VM>();
        }

        #endregion


        #region "Opeaciones"     

        //private static void PrintType<BE>(BE object)
        //{
        //    Console.WriteLine(object.GetType());
        //}


        public void CargarTipos()
        {
            //List<VM> LstDocumentoIdentidadTiposBE = CONSULTARLISTA().Consultar_Lista();

            //if (VM().GetType() == new DocumentoIdentidadTiposBE().GetType())
            //{

            //}


            ////            List<DocumentoIdentidadTiposBE> LstDocumentoIdentidadTiposBE = (new DocumentoIdentidadTiposBL()).Consultar_Lista();


            //foreach (DocumentoIdentidadTiposBE DocumentoIdentidadTiposBE in LstDocumentoIdentidadTiposBE)
            //    LstTipoDocumentos.Add(BEToViewModel(DocumentoIdentidadTiposBE));
        }

        #endregion

    }
}