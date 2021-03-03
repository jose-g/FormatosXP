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
        public string DepartamentoDomicilioDeclaranteNombre { get { return LstUbigeo.Find(x => x.UbigeoCodigo == DistritoDomicilioDeclaranteId).Departamento; } }
        [Display(Name = "Provincia")]
        public string ProvinciaDomicilioDeclaranteId { get; set; }
        public string ProvinciaDomicilioDeclaranteNombre { get { return LstUbigeo.Find(x => x.UbigeoCodigo == DistritoDomicilioDeclaranteId).Provincia; } }
        [Display(Name = "Distrito")]
        public string DistritoDomicilioDeclaranteId { get; set; }
        public string DistritoDomicilioDeclaranteNombre { get { return LstUbigeo.Find(x => x.UbigeoCodigo == DistritoDomicilioDeclaranteId).Distrito; } }
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

        public List<UbigeoBE> LstUbigeo;

        public AgregarDomiciliosEnPeruVewModel()
        {
            LstUbigeo = new List<UbigeoBE>();
            LstUbigeo = new UbigeoBL().Consultar_Lista();
            LstDepartamentosDomicilioDeclarante = new List<UbigeoBE>();
            LstProvinciaDomicilioDeclarante = new List<UbigeoBE>();
            LstDistritosDomicilioDeclarante = new List<UbigeoBE>();
            LstDepartamentosDomicilioDeclarante = LstUbigeo.DistinctBy(x => x.Departamento).ToList();
        }
    }
}
