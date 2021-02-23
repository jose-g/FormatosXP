using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class UbigeoViewModel
    {
        #region Propiedades

        public string ErrorSMS { get; set; }
        public string InfoSMS { get; set; }

        public int UbigeoId { get; set; }
        public string UbigeoCodigo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModificacionRegistro { get; set; }
        public DateTime? FechaModificacionRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string NroIpRegistro { get; set; }
        public int EstadoId { get; set; }
        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        public String FechaModificacionRegistroStr
        {
            get
            {
                return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
            }
        }

        public List<UbigeoBE> LstUbigeo;
        public List<UbigeoViewModel> LstUbigeoVM;

        public List<UbigeoBE> LstDepartamentos;
        public List<UbigeoBE> LstProvincia;
        public List<UbigeoBE> LstDistritos;
        #endregion

        public UbigeoViewModel()
        {
            LstUbigeo = new List<UbigeoBE>();
            LstUbigeoVM = new List<UbigeoViewModel>();
            LstDepartamentos = new List<UbigeoBE>();
            LstProvincia = new List<UbigeoBE>();
            LstDistritos = new List<UbigeoBE>();
        }
        public List<UbigeoViewModel> Listar()
        {
            LstUbigeo = new UbigeoBL().Consultar_Lista().ToList();

            foreach (var item in LstUbigeo)
                LstUbigeoVM.Add(BEToViewModel(item));

            return LstUbigeoVM.OrderBy(x => x.UbigeoId).ToList();
        }
        private UbigeoViewModel BEToViewModel(UbigeoBE m_BE)
        {
            UbigeoViewModel m_vm = new UbigeoViewModel();

            m_vm.UbigeoId = m_BE.UbigeoId;
            m_vm.UbigeoCodigo = m_BE.UbigeoCodigo;
            m_vm.Departamento = m_BE.Departamento;
            m_vm.Provincia = m_BE.Provincia;
            m_vm.Distrito = m_BE.Distrito;
            m_vm.UsuarioRegistro = m_BE.UsuarioRegistro;
            m_vm.UsuarioModificacionRegistro = m_BE.UsuarioModificacionRegistro;
            m_vm.FechaRegistro = m_BE.FechaRegistro;
            m_vm.UsuarioModificacionRegistro = m_BE.UsuarioModificacionRegistro;
            m_vm.FechaModificacionRegistro = m_BE.FechaModificacionRegistro;
            m_vm.NroIpRegistro = m_BE.NroIpRegistro;
            m_vm.EstadoId = m_BE.EstadoId.Value;
            m_vm.EstadoNombre = new EstadosBL().Consultar_PK(m_BE.EstadoId.Value).FirstOrDefault().Nombre;

            return m_vm;
        }
        private UbigeoBE ViewModelToBE(UbigeoViewModel m_vm)
        {
            UbigeoBE m_BE = new UbigeoBE();
            m_BE.UbigeoId = m_vm.UbigeoId;
            m_BE.UbigeoCodigo = m_vm.UbigeoCodigo;
            m_BE.Departamento = m_vm.Departamento;
            m_BE.Provincia = m_vm.Provincia;
            m_BE.Distrito = m_vm.Distrito;
            m_BE.UsuarioRegistro = m_vm.UsuarioRegistro;
            m_BE.UsuarioModificacionRegistro = m_vm.UsuarioModificacionRegistro;
            m_BE.FechaRegistro = m_vm.FechaRegistro;
            m_BE.UsuarioModificacionRegistro = m_vm.UsuarioModificacionRegistro;
            m_BE.FechaModificacionRegistro = m_vm.FechaModificacionRegistro;
            m_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            m_BE.EstadoId = m_vm.EstadoId;
            return m_BE;
        }
        public List<UbigeoBE> GetDepartmentos()
        {
            LstDepartamentos = new UbigeoBL().Consultar_Lista().DistinctBy(x => x.Departamento).ToList();
            return LstDepartamentos;
        }
        public List<UbigeoBE> GetPronviciaPorDepartamento(String DepartamentoId)
        {
            LstProvincia = new UbigeoBL().Consultar_Lista().Where(x => x.UbigeoCodigo.ToString().StartsWith(DepartamentoId.Substring(0, 2)) && x.UbigeoCodigo.ToString().Substring(2, 4) != "0000").DistinctBy(x => x.Provincia).ToList();
            return LstProvincia;
        }
        public List<UbigeoBE> GetDistritoPorProvincia(String ProvinciaId)
        {
            LstDistritos = new UbigeoBL().Consultar_Lista().Where(x => x.UbigeoCodigo.ToString().StartsWith(ProvinciaId.Substring(0, 4)) && x.UbigeoCodigo.ToString().Substring(4, 2) != "00").ToList();
            return LstDistritos;
        }
        public UbigeoViewModel BuscarxIdReturnVM(int UbigeoId)
        {
            UbigeoBE ubigeoBE = new UbigeoBL().Consultar_PK(UbigeoId).FirstOrDefault();
            if (ubigeoBE != null)
                return BEToViewModel(ubigeoBE);

            return null;
        }
        public void BuscarxId(int UbigeId)
        {
            if (UbigeId < 0) return;

            UbigeoBE ubigeoNavalBE = new UbigeoBL().Consultar_PK(UbigeId).FirstOrDefault();

            if (ubigeoNavalBE != null)
                BEToViewModel(ubigeoNavalBE);
        }



    }

}