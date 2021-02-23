using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.Views.X1003
{
    public class FotosViewModel
    {

        public string ErrorSMS { get; set; } = "";

        [Display(Name = "Foto de Frente")]
        public string FotoFrente { get; set; } = "";
        [Display(Name = "Foto Posterior")]
        public string FotoPosterior { get; set; } = "";
        [Display(Name = "Foto Lateral Izquierdo")]
        public string FotoLateralIzquierdo { get; set; } = "";
        [Display(Name = "Foto Lateral Derecho")]
        public string FotoLateralDerecho { get; set; } = "";


        //public string StrFotoFrente { get; set; } = "";
        //public string StrFotoPosterior { get; set; } = "";
        //public string StrFotoLateralIzquierdo { get; set; } = "";
        //public string StrFotoLateralDerecho { get; set; } = "";
        //public byte[] Base64FotoFrente { get; set; }
        //public byte[] Base64FotoPosterior { get; set; }
        //public byte[] Base64FotoLateralIzquierdo { get; set; }
        //public byte[] Base64FotoLateralDerecho { get; set; }


        //public byte[] Base64FotoFrente
        //{
        //    get
        //    {
        //        return Convert.FromBase64String(StrFotoFrente);
        //    }
        //}
        //public byte[] Base64FotoPosterior
        //{
        //    get
        //    {
        //        return Convert.FromBase64String(StrFotoPosterior);
        //    }
        //}
        //public byte[] Base64FotoLateralIzquierdo
        //{
        //    get
        //    {
        //        return Convert.FromBase64String(StrFotoLateralIzquierdo);
        //    }
        //}
        //public byte[] Base64FotoLateralDerecho
        //{
        //    get
        //    {
        //        return Convert.FromBase64String(StrFotoLateralDerecho);
        //    }
        //}


        public bool GrabarFotos(int DatosPersonalesId, string Paterno, string Materno, string login)
        {
            int FotoDeclaranteId = new FotosDeclarantesBL().GetMaxId();
            for (int i = 1; i < 5; i++)
            {
                FotosDeclarantesBE fotoBE = new FotosDeclarantesBE();
                fotoBE.FotoDeclaranteId = FotoDeclaranteId + i;
                fotoBE.DatosPersonalesId = DatosPersonalesId;
                fotoBE.FotoTipoId = i;
                fotoBE.EstadoId = 1;
                fotoBE.UsuarioRegistro = login;
                fotoBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                switch (i)
                {
                    case 1: fotoBE.Foto = Encoding.ASCII.GetBytes(this.FotoFrente);
                            break;
                    case 2: fotoBE.Foto = Encoding.ASCII.GetBytes(this.FotoPosterior);
                            break;
                    case 3: fotoBE.Foto = Encoding.ASCII.GetBytes(this.FotoLateralIzquierdo);
                            break;
                    case 4: fotoBE.Foto = Encoding.ASCII.GetBytes(this.FotoLateralDerecho);
                            break;
                }

                if (new FotosDeclarantesBL().Insertar(fotoBE) == false)
                {
                    ErrorSMS = "Error al insertar foto";
                    return false;
                }
            }







            //Grabar foto frente
            //Grabar foto posterior
            //Grabar foto izquierda
            //Grabar foto derecha

            return true;
        }
    }
}