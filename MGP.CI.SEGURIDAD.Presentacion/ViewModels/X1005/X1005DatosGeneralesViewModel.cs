using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.XP1005;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using MGP.CI.SEGURIDAD.Negocio.X1005;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005DatosGeneralesViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }

        public Int32 DatosGeneralesId { get; set; }

        //Datos Generales

        [Display(Name = "Nombres")]
        public string ExtranjeroNombres { get; set; } = "";

        [Display(Name = "Apellido Paterno")]
        public string ExtranjeroPaterno { get; set; } = "";

        [Display(Name = "Apellido Materno")]
        public string ExtranjeroMaterno { get; set; } = "";

        [Display(Name = "Nacionalidad")]
        public int ExtranjeroNacionalidadId { get; set; } 
        public List<NacionalidadBE> LstNacionalidades { get; set; }

        [Display(Name = "Grado")]
        public int ExtranjeroGradoId { get; set; } 
        public List<GradosExtranjerosBE> LstGradosExtranjeros { get; set; }

        [Display(Name = "Especialidad")]
        public int ExtranjeroEspecialidadId { get; set; }
        public List<EspecialidadesExtranjerasBE> LstEspecialidadesExtranjeras { get; set; }

        [Display(Name = "Institucion")]
        public int ExtranjeroInstitucionId { get; set; }
        public List<InstitucionesMilitaresExtranjerasBE> LstInstitucionesExtranjeras { get; set; }

        [Display(Name = "Cargo o Funcion Principal que Desempeña")]
        public string ExtranjeroCargoDesempena { get; set; } = "";
        public int CargoDesempenaId { get; set; }

        //Situacion Economica



        //Valores y Moral        
        [Display(Name = "Preferencia Sexual")]
        public int PreferenciaSexualId { get; set; }
        public List<PreferenciaSexualMaestraBE> LstPreferenciaSexual { get; set; }
        [Display(Name = "Prefiere Hogar o Diversión")]

        public bool Hogar_Diversion { get; set; }
        [Display(Name = "Religion que Profesa")]

        public int ReligionId { get; set; }
        public List<ReligionMaestraBE> LstReligiones { get; set; }
        #endregion

        public X1005DatosGeneralesViewModel()
        {
            LstNacionalidades = new List<NacionalidadBE>();
            LstGradosExtranjeros = new List<GradosExtranjerosBE>();
            LstEspecialidadesExtranjeras = new List<EspecialidadesExtranjerasBE>();
            LstInstitucionesExtranjeras = new List<InstitucionesMilitaresExtranjerasBE>();
            LstPreferenciaSexual = new List<PreferenciaSexualMaestraBE>();
            LstReligiones = new List<ReligionMaestraBE>();

            CargarTablasMaestras();
        }
        public void  CargarTablasMaestras()
        {
            LstNacionalidades = new NacionalidadBL().Consultar_Lista();
            LstGradosExtranjeros = new GradosExtranjerosBL().Consultar_Lista();
            LstEspecialidadesExtranjeras = new EspecialidadesExtranjerasBL().Consultar_Lista();
            LstInstitucionesExtranjeras = new InstitucionesMilitaresExtranjerasBL().Consultar_Lista();
            LstPreferenciaSexual = new PreferenciaSexualMaestraBL().Consultar_Lista();
            LstReligiones = new ReligionMaestraBL().Consultar_Lista();
        }
    }
}