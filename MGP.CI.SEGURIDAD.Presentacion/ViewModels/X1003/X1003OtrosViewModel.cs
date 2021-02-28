using MGP.CI.SEGURIDAD.Entidades.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Negocio.XP1003;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003OtrosViewModel
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public int OtrosId { get; set; }


        [Display(Name = "Subir CV : ")]
        public string PathCV { get; set; }
        public Int32 X1003OtrosId { get; set; }


        public List<AgregarDeporteViewModel> LstDeporte;
        public List<AgregarObservacionViewModel> LstObservacion;

        //[Display(Name = "Adjuntar CV : ")]

        //public HttpPostedFileBase File { get; set; }

        public X1003OtrosViewModel()
        {
            LstDeporte = new List<AgregarDeporteViewModel>();
            LstObservacion = new List<AgregarObservacionViewModel>();
        }

        public void CargarTablasMaestras()
        {

        }

        public bool Insertar(string login)
        {
            OtrosXP1003BE c_BE = new OtrosXP1003BE();
            c_BE.OtrosId = new OtrosXP1003BL().GetMaxId() + 1;
            c_BE.EstadoId = 1;
            c_BE.FichaId = this.FichaId;
            c_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            c_BE.UsuarioRegistro = login;

            if (new OtrosXP1003BL().Consultar_PK(c_BE.OtrosId).FirstOrDefault() == null)
            {
                if (new OtrosXP1003BL().Insertar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Informacion Castrense";
                    RollBack(c_BE.OtrosId);
                    return false;
                }
            }
            else
            {
                if (new OtrosXP1003BL().Actualizar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Actualizar Informacion Castrense";
                    RollBack(c_BE.OtrosId);
                    return false;
                }
            }

            // guardar deportes
            if (LstDeporte != null)
            {
                int DeporteRealizadoId = new DeportesRealizadosBL().GetMaxId();
                foreach (AgregarDeporteViewModel dom in LstDeporte)
                {
                    DeportesRealizadosBE d_BE = new DeportesRealizadosBE();

                    d_BE.DeporteRealizadoId = ++DeporteRealizadoId;
                    d_BE.OtrosId = c_BE.OtrosId;
                    d_BE.DeportesId = dom.OtrosDeporteId;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new DeportesRealizadosBL().Consultar_PK(d_BE.DeporteRealizadoId).FirstOrDefault() == null)
                    {
                        if (new DeportesRealizadosBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.OtrosId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new DeportesRealizadosBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.OtrosId);
                            return false;
                        }
                    }
                }
            }
            // guardar observaciones
            if (LstObservacion != null)
            {
                int ObservacionesId = new ObservacionesBL().GetMaxId();
                foreach (AgregarObservacionViewModel dom in LstObservacion)
                {
                    ObservacionesBE d_BE = new ObservacionesBE();

                    d_BE.ObservacionesId = ++ObservacionesId;
                    d_BE.OtrosId = c_BE.OtrosId;
                    d_BE.Descripcion = dom.Observacion;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new ObservacionesBL().Consultar_PK(d_BE.ObservacionesId).FirstOrDefault() == null)
                    {
                        if (new ObservacionesBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.OtrosId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new ObservacionesBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.OtrosId);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void RollBack(int OtrosXP1003Id)
        {
            OtrosXP1003BE vm = new OtrosXP1003BE();
            vm = new OtrosXP1003BL().Consultar_PK(OtrosXP1003Id).FirstOrDefault();
            new OtrosXP1003BL().Anular(vm);

            foreach (DeportesRealizadosBE dom in new DeportesRealizadosBL().Consultar_Lista().Where(x => x.OtrosId == OtrosXP1003Id))
                new DeportesRealizadosBL().Anular(dom);

            foreach (ObservacionesBE dom in new ObservacionesBL().Consultar_Lista().Where(x => x.OtrosId == OtrosXP1003Id))
                new ObservacionesBL().Anular(dom);
        }
    }
}