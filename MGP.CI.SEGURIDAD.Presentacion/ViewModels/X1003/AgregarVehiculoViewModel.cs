using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using Microsoft.Ajax.Utilities;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarVehiculoViewModel
    {

        [Display(Name = "Modelo del Vehiculo")]
        public int ExtranjeroVehiculoModeloId { get; set; }

        [Display(Name = "Marca del Vehiculo")]
        public int ExtranjeroVehiculoMarcaId { get; set; }

        [Display(Name = "Placa del Vehiculo")]
        public string ExtranjeroVehiculoPlaca { get; set; }

        [Display(Name = "Tipo de Vehiculo")]
        public string ExtranjeroTipoVehiculoId { get; set; }

        public List<AutoMarcasBE> LstMarcas;
        public List<AutoModelosBE> LstModelos;
        public List<VehiculoTiposBE> LstTipoVehiculos;

        public AgregarVehiculoViewModel()
        {
            LstMarcas = new List<AutoMarcasBE>();
            LstMarcas = GetMarcas();

            LstModelos = new List<AutoModelosBE>();
            LstTipoVehiculos = new List<VehiculoTiposBE>();
            LstTipoVehiculos = new VehiculoTiposBL().Consultar_Lista();
        }


        public List<AutoMarcasBE> GetMarcas()
        {
            LstMarcas =  new AutoMarcasBL().Consultar_Lista().DistinctBy(x => x.Descripcion).ToList();
            return LstMarcas;
        }
        public List<AutoModelosBE> GetModelosxMarca(string MarcaId)
        {
            return new AutoModelosBL().Consultar_Lista().Where(x => x.AutoMarcaId.ToString().Equals(MarcaId)).OrderBy(x => x.Descripcion).ToList();

        }


    }
}