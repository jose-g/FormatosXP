using MGP.CI.SEGURIDAD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class SesionViewModel
    {
        public string ErrorSMS { get; set; }
        public int UsuarioId { get; set; }
        public String Login { get; set; }
       // public String Password { get; set; }
        public String UsuarioNombres { get; set; }
        public DateTime GFHInicio{ get; set; }
        public DateTime GFHFin{ get; set; }
        public int UsuarioPerfilAdmId{ get; set; }

        public int FichaId { get; set; }
        public int DatosPersonalesId { get; set; }
        public int FamiliarId { get; set; }
        public int CargosFuncionesId { get; set; }
        public int InformacionCastrenseId { get; set; }
        public int OtrosId { get; set; }

        public List<UsuarioPerfilesBE> LstPerfilesAsociados { get; set; }
        public List<PerfilModulosBE> LstModulosAsociados { get; set; }
        public List<PermisoPerfilModulosBE> LstPermisosAsociados { get; set; }

        public SesionViewModel()
        {
            LstPerfilesAsociados = new List<UsuarioPerfilesBE>();
            LstModulosAsociados = new List<PerfilModulosBE>();
            LstPermisosAsociados = new List<PermisoPerfilModulosBE>();
            UsuarioPerfilAdmId = 0;
        }


    }
}