using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003CargosFuncionesViewModel
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }
        public Int32 CargosFuncionesX1003Id { get; set; }


        public int UbigeoId { get; set; }
        public int? EstadoId { get; set; }
        public string UsuarioRegistro { get; set; }
        public string NroIpRegistro { get; set; }




        public List<AgregarDomiciliosEnPeruVewModel> LstDomicilios;
        public List<AgregarVehiculoViewModel> LstVehiculos;
        public List<AgregarIngresosAlPaisViewModel> LstIngresos;
        public List<AgregarIngresosAnterioresAlPaisViewModel> LstIngresosAnteriores;
        public X1003CargosFuncionesViewModel()
        {
            LstDomicilios = new List<AgregarDomiciliosEnPeruVewModel>();
            LstVehiculos = new List<AgregarVehiculoViewModel>();
            LstIngresos = new List<AgregarIngresosAlPaisViewModel>();
            LstIngresosAnteriores = new List<AgregarIngresosAnterioresAlPaisViewModel>();
        }

        public void CargarTablasMaestras()
        {

        }

        public bool Insertar(string login)
        {
            int UbigeoId = 1;
            CargosFuncionesX1003BE c_BE = new CargosFuncionesX1003BE();
            c_BE.CargosFuncionesX1003Id = new CargosFuncionesX1003BL().GetMaxId() + 1;
            c_BE.EstadoId = 1;
            c_BE.FichaId = this.FichaId;
            c_BE.UbigeoId = UbigeoId;
            c_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            c_BE.UsuarioRegistro = login;

            if (new CargosFuncionesX1003BL().Consultar_PK(c_BE.CargosFuncionesX1003Id).FirstOrDefault() == null)
            {
                if (new CargosFuncionesX1003BL().Insertar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Cargos Funcionales";
                    RollBack(c_BE.CargosFuncionesX1003Id);
                    return false;
                }
            }
            else
            {
                if (new CargosFuncionesX1003BL().Actualizar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Actualizar Cargos Funcionales";
                    RollBack(c_BE.CargosFuncionesX1003Id);
                    return false;
                }
            }
        




            if (LstDomicilios != null)
            {
                int DomicilioId = new DomiciliosBL().GetMaxId();
                foreach (AgregarDomiciliosEnPeruVewModel dom in LstDomicilios)
                {
                    DomiciliosBE d_BE = new DomiciliosBE();
                    d_BE.DomicilioId = ++DomicilioId;
                    d_BE.CargosFuncionesX1003Id = c_BE.CargosFuncionesX1003Id;
                    d_BE.LugardeResidencia = dom.LugarResidenciaDomicilioDeclarante;
                    d_BE.Referencia = dom.ReferenciaDomicilioDeclarante;
                    d_BE.Telefono = dom.TelefonoDomicilioDeclarante.ToString();
                    d_BE.Email = dom.lblEmailDomicilioDeclarante;
                    d_BE.UbigeoId = new UbigeoBL().Consultar_Lista().Find(x => x.UbigeoCodigo == dom.DistritoDomicilioDeclaranteId.ToString()).UbigeoId;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new DomiciliosBL().Consultar_PK(d_BE.DomicilioId).FirstOrDefault() == null)
                    {
                        if (new DomiciliosBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Domicilios";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                    else
                    {
                        if (new DomiciliosBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Domicilios";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                }
            }

            if (LstVehiculos != null)
            {
                int VehiculoId = new VehiculosBL().GetMaxId();
                foreach (AgregarVehiculoViewModel dom in LstVehiculos)
                {
                    VehiculosBE v_BE = new VehiculosBE();
                    v_BE.VehiculoId = ++VehiculoId;
                    v_BE.CargosFuncionesX1003Id = c_BE.CargosFuncionesX1003Id;
                    v_BE.VehiculoTipoId = Int32.Parse(dom.ExtranjeroTipoVehiculoId);
                    v_BE.AutoModeloId = dom.ExtranjeroVehiculoModeloId;
                    v_BE.AutoMarcaId = dom.ExtranjeroVehiculoMarcaId;
                    v_BE.Placa = dom.ExtranjeroVehiculoPlaca;
                    v_BE.EstadoId = 1;
                    v_BE.UsuarioRegistro = login;
                    v_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                    if (new VehiculosBL().Consultar_PK(v_BE.VehiculoId).FirstOrDefault() == null)
                    {
                        if (new VehiculosBL().Insertar(v_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Vehiculo";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                    else
                    {
                        if (new VehiculosBL().Actualizar(v_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar  Vehiculo";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                }
            }



            if (LstIngresos != null)
            {
                int IngresoPasiId = new IngresosAlPaisBL().GetMaxId();
                foreach (AgregarIngresosAlPaisViewModel dom in LstIngresos)
                {
                    IngresosAlPaisBE i_BE = new IngresosAlPaisBE();
                    i_BE.IngresoPaisId = ++IngresoPasiId;
                    i_BE.CargosFuncionesX1003Id = c_BE.CargosFuncionesX1003Id;
                    i_BE.FechaIngreso = dom.IngresoAlPaisFechaIngreso;
                    i_BE.FechaInicioMision = dom.IngresoAlPaisFechaInicioMision;
                    i_BE.FechaTerminoMision = dom.IngresoAlPaisFechaTerminoMision;
                    i_BE.EstadoId = 1;
                    i_BE.UsuarioRegistro = login;
                    i_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                    if (new IngresosAlPaisBL().Consultar_PK(i_BE.IngresoPaisId).FirstOrDefault() == null)
                    {
                        if (new IngresosAlPaisBL().Insertar(i_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ingreso al Pais";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                    else
                    {
                        if (new IngresosAlPaisBL().Actualizar(i_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ingreso al Pais";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                }
            }

            if (LstIngresosAnteriores != null)
            {
                int IngresosAnterioresId = new IngresosAnterioresAlPaisBL().GetMaxId();
                foreach (AgregarIngresosAnterioresAlPaisViewModel dom in LstIngresosAnteriores)
                {
                    IngresosAnterioresAlPaisBE i_BE = new IngresosAnterioresAlPaisBE();
                    i_BE.IngresosAnterioresAlPaisID = ++IngresosAnterioresId;
                    i_BE.CargosFuncionesX1003Id = c_BE.CargosFuncionesX1003Id;
                    i_BE.FechaIngreso = dom.IngresoAnteriorFechaIngreso;
                    i_BE.FechaSalid = dom.IngresoAnteriorFechaSalida;
                    i_BE.Motivo = dom.IngresoAnteriorMotivo;
                    i_BE.DondeResidio = dom.IngresoAnteriorDondeResidio;
                    i_BE.Destino = dom.IngresoAnteriorDestino;
                    i_BE.UbigeoId = 1;
                    i_BE.EstadoId = 1;
                    i_BE.UsuarioRegistro = login;
                    i_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                    if (new IngresosAnterioresAlPaisBL().Consultar_PK(c_BE.CargosFuncionesX1003Id).FirstOrDefault() == null)
                    {
                        if (new IngresosAnterioresAlPaisBL().Insertar(i_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ingresos anteriores al pais";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                    else
                    {
                        if (new IngresosAnterioresAlPaisBL().Actualizar(i_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ingresos anteriores al pais";
                            RollBack(c_BE.CargosFuncionesX1003Id);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void RollBack(int CargosFuncionesX1003Id)
        {
            CargosFuncionesX1003BE vm = new CargosFuncionesX1003BE();
            vm = new CargosFuncionesX1003BL().Consultar_PK(CargosFuncionesX1003Id).FirstOrDefault();
            new CargosFuncionesX1003BL().Anular(vm);

            foreach (DomiciliosBE dom in new DomiciliosBL().Consultar_Lista().Where(x => x.CargosFuncionesX1003Id == CargosFuncionesX1003Id))
                new DomiciliosBL().Anular(dom);

            foreach (VehiculosBE dom in new VehiculosBL().Consultar_Lista().Where(x => x.CargosFuncionesX1003Id == CargosFuncionesX1003Id))
                new VehiculosBL().Anular(dom);

            foreach (IngresosAlPaisBE dom in new IngresosAlPaisBL().Consultar_Lista().Where(x => x.CargosFuncionesX1003Id == CargosFuncionesX1003Id))
                new IngresosAlPaisBL().Anular(dom);

            foreach (IngresosAnterioresAlPaisBE dom in new IngresosAnterioresAlPaisBL().Consultar_Lista().Where(x => x.CargosFuncionesX1003Id == CargosFuncionesX1003Id))
                new IngresosAnterioresAlPaisBL().Anular(dom);
        }
        private X1003CargosFuncionesViewModel BEToViewModel(CargosFuncionesX1003BE m_BE)
        {
            X1003CargosFuncionesViewModel m_vm = new X1003CargosFuncionesViewModel();

            m_vm.CargosFuncionesX1003Id = m_BE.CargosFuncionesX1003Id;
            m_vm.EstadoId = m_BE.EstadoId;
            m_vm.FichaId = m_BE.FichaId;
            m_vm.UbigeoId = m_BE.UbigeoId;
            m_vm.NroIpRegistro = m_BE.NroIpRegistro;
            m_vm.UsuarioRegistro = m_BE.UsuarioRegistro;

            m_vm.LstDomicilios=this.LstDomicilios;
            m_vm.LstVehiculos=this.LstVehiculos;
            m_vm.LstIngresos=this.LstIngresos;
            m_vm.LstIngresosAnteriores=this.LstIngresosAnteriores;


            return m_vm;
        }
        public X1003CargosFuncionesViewModel BuscarxId(int m_CargosFuncionesId)
        {
            CargosFuncionesX1003BE m_BE = new CargosFuncionesX1003BL().Consultar_PK(m_CargosFuncionesId).FirstOrDefault();

            
            List<DomiciliosBE> lstBE_Domicilio = new List<DomiciliosBE>();
            lstBE_Domicilio = new DomiciliosBL().Consultar_FK(m_CargosFuncionesId);

            foreach (DomiciliosBE be in lstBE_Domicilio)
            {
                AgregarDomiciliosEnPeruVewModel VM = new AgregarDomiciliosEnPeruVewModel();
                VM.LugarResidenciaDomicilioDeclarante = be.LugardeResidencia;
                VM.DistritoDomicilioDeclaranteId = new UbigeoBL().Consultar_PK(be.UbigeoId).Find(x => x.UbigeoId == be.UbigeoId).UbigeoCodigo;
                VM.ProvinciaDomicilioDeclaranteId = VM.DistritoDomicilioDeclaranteId.Remove(VM.DistritoDomicilioDeclaranteId.Length - 2) + "01";
                VM.DepartamentoDomicilioDeclaranteId = VM.DistritoDomicilioDeclaranteId.Remove(VM.DistritoDomicilioDeclaranteId.Length - 4) + "0101";
                VM.ReferenciaDomicilioDeclarante = be.Referencia;
                VM.TelefonoDomicilioDeclarante = Int32.Parse(be.Telefono);
                VM.lblEmailDomicilioDeclarante = be.Email;
                LstDomicilios.Add(VM);
            }
                List<IngresosAlPaisBE> lstBE_IngresoAlPais = new List<IngresosAlPaisBE>();
            lstBE_IngresoAlPais = new IngresosAlPaisBL().Consultar_FK(m_CargosFuncionesId);

            foreach (IngresosAlPaisBE be in lstBE_IngresoAlPais)
            {
                AgregarIngresosAlPaisViewModel VM = new AgregarIngresosAlPaisViewModel();
                VM.IngresoAlPaisFechaIngreso = be.FechaIngreso;
                VM.IngresoAlPaisFechaInicioMision = be.FechaInicioMision;
                VM.IngresoAlPaisFechaTerminoMision = be.FechaTerminoMision;
                LstIngresos.Add(VM);
            }

            List<IngresosAnterioresAlPaisBE> lstBE_IngresosAnterioresAlPais = new List<IngresosAnterioresAlPaisBE>();
            lstBE_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisBL().Consultar_FK(m_CargosFuncionesId);

            foreach (IngresosAnterioresAlPaisBE be in lstBE_IngresosAnterioresAlPais)
            {
                AgregarIngresosAnterioresAlPaisViewModel VM = new AgregarIngresosAnterioresAlPaisViewModel();
                VM.IngresoAnteriorFechaIngreso = be.FechaIngreso;
                VM.IngresoAnteriorFechaSalida = be.FechaSalid;
                VM.IngresoAnteriorMotivo = be.Motivo;
                VM.IngresoAnteriorDondeResidio = be.DondeResidio;
                VM.IngresoAnteriorDestino = be.Destino;
                LstIngresosAnteriores.Add(VM);
            }

            List<VehiculosBE> lstBE_Vehiculos = new List<VehiculosBE>();
            lstBE_Vehiculos = new VehiculosBL().Consultar_FK(m_CargosFuncionesId);

            foreach (VehiculosBE be in lstBE_Vehiculos)
            {
                AgregarVehiculoViewModel VM = new AgregarVehiculoViewModel();
                VM.ExtranjeroTipoVehiculoId = be.VehiculoTipoId.ToString();
                VM.ExtranjeroVehiculoModeloId = be.AutoModeloId;
                VM.ExtranjeroVehiculoMarcaId = be.AutoMarcaId;
                VM.ExtranjeroVehiculoPlaca = be.Placa;
                LstVehiculos.Add(VM);
            }

            

            if (m_BE != null) return BEToViewModel(m_BE);
            return null;
        }
        public X1003CargosFuncionesViewModel BuscarxFicha(int m_FichaId)
        {
            int m_Id;
            try
            {
                m_Id = new CargosFuncionesX1003BL().Consultar_FK(m_FichaId).FirstOrDefault().CargosFuncionesX1003Id;
                return BuscarxId(m_Id);
            }
            catch (Exception e)
            {
                return new X1003CargosFuncionesViewModel();
            }
        }

    }
}