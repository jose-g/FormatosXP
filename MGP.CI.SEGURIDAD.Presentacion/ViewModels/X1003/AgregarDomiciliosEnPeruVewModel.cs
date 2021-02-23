using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class AgregarDomiciliosEnPeruVewModel
    {

        [Display(Name = "Departamento")]

        public string DepartamentoDomicilioDeclaranteId { get; set; }
        [Display(Name = "Provincia")]
        public string ProvinciaDomicilioDeclaranteId { get; set; }
        [Display(Name = "Distrito")]
        public string DistritoDomicilioDeclaranteId { get; set; }
        public int UbigeoDomicilioDeclaranteId { get; set; }

        [Display(Name = "Lugar de Residencia")]
        public string LugarResidenciaDomicilioDeclarante { get; set; }
        [Display(Name = "Referencia")]
        public string ReferenciaDomicilioDeclarante { get; set; }
        [Display(Name = "Telefono")]
        public int? TelefonoDomicilioDeclarante { get; set; }
        [Display(Name = "Email")]
        public string lblEmailDomicilioDeclarante { get; set; }
        public string EmailParteIzquierda{ get; set; }
        public string EmailParteDerecha { get; set; }

        public List<UbigeoBE> LstDepartamentosDomicilioDeclarante;
        public List<UbigeoBE> LstProvinciaDomicilioDeclarante;
        public List<UbigeoBE> LstDistritosDomicilioDeclarante;

        public AgregarDomiciliosEnPeruVewModel()
        {
            LstDepartamentosDomicilioDeclarante = new List<UbigeoBE>();
            LstProvinciaDomicilioDeclarante = new List<UbigeoBE>();
            LstDistritosDomicilioDeclarante = new List<UbigeoBE>();
            LstDepartamentosDomicilioDeclarante =  new UbigeoBL().Consultar_Lista().DistinctBy(x => x.Departamento).ToList();

        }
    }
}
