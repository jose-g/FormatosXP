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
    public class x1003DatosFamiliaresVM
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public Int32 DatosFamiliaresId { get; set; }


        #region Esposa
        [Display(Name = "Apellido Paterno")]
        public string EsposaPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string EsposaMaterno { get; set; }
        [Display(Name = "Nombres")]
        public string EsposaNombre1 { get; set; }
        public string EsposaNombre2 { get; set; }
        public string EsposaNombre3 { get; set; }
        [Display(Name = "Nacionalidad")]
        public int EsposaNacionalidadId { get; set; } = 5;
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? EsposaFechaNacimiento { get; set; }

        [Display(Name = "Pais de Nacimiento")]
        public DateTime EsposaPaisNacimientoId { get; set; }

        [Display(Name = "Lugar de Nacimiento")]
        public string EsposaLugarNacimiento { get; set; }
        [Display(Name = "Grupo Sanguineo")]
        public int EsposaGrupoSanguineoId { get; set; } = 1;
        [Display(Name = "Enfermedades")]
        public string EsposaEnfermedades { get; set; }
        [Display(Name = "Alergias")]
        public string EsposaAlergias { get; set; }
        [Display(Name = "Profesion")]
        public int EsposaAProfesionId { get; set; }
        [Display(Name = "Actividades de preferencia")]
        public string EsposaActividades { get; set; }
        [Display(Name = "Idiomas que Habla")]
        public int EsposaIdiomaId { get; set; }
        public List<string> LstEsposaIdiomas { get; set; }
        [Display(Name = "Numero Doc Identidad")]
        public string EsposaDocIdentidadNro { get; set; }
        [Display(Name = "Numero Doc Pasaporte")]
        public string EsposaPasaporteNro { get; set; }
        [Display(Name = "Tipo de Enfermedad")]
        public int EsposaEnfermedadTipoId { get; set; } = 1;
        [Required]
        [Display(Name = "Enfermedad")]
        public string EsposaEnfermedadId { get; set; }
        public List<SexoBE> LstSexo { get; set; }
        public List<NacionalidadBE> LstNacionalidades { get; set; }
        public List<PaisesBE> LstPaises { get; set; }

        public List<IdiomaBE> LstIdiomas { get; set; }
        public List<ProfesionesBE> LstProfesiones { get; set; }
        public List<GrupoSanguineoBE> LstGrupoSanguineo { get; set; }

        #endregion

        public List<AgregarDocumentoViewModel> LstIdentificaciones;
        public List<AgregarHijoViewModel> LstHijos;
        public List<AgregarFamiliarViewModel> LstFamiliares;
        public List<AgregarFamiliarResidentesEnPeru> LstFamResidentes;
        public List<string> LstStrIdiomas { get; set; }
        public List<EnfermedadesBE> LstTipoEnfermedad { get; set; }
        public List<EnfermedadesBE> LstEnfermedad { get; set; }

        public x1003DatosFamiliaresVM()
        {
            LstNacionalidades = new List<NacionalidadBE>();
            LstSexo = new List<SexoBE>();
            LstIdiomas = new List<IdiomaBE>();
            LstProfesiones = new List<ProfesionesBE>();
            LstPaises = new List<PaisesBE>();
            LstGrupoSanguineo = new List<GrupoSanguineoBE>();
            LstTipoEnfermedad = new List<EnfermedadesBE>();


            //Para Grabar
            LstIdentificaciones = new List<AgregarDocumentoViewModel>();
            LstHijos = new List<AgregarHijoViewModel>();
            LstFamiliares = new List<AgregarFamiliarViewModel>();
            LstFamResidentes = new List<AgregarFamiliarResidentesEnPeru>();
            LstStrIdiomas = new List<string>();
        }

        public void CargarTablasMaestras()
        {
            LstNacionalidades = new NacionalidadBL().Consultar_Lista();
            LstSexo = new SexoBL().Consultar_Lista();
            LstIdiomas = new IdiomaBL().Consultar_Lista();
            LstProfesiones = new ProfesionesBL().Consultar_Lista();
            LstPaises = new PaisesBL().Consultar_Lista();
            LstGrupoSanguineo = new GrupoSanguineoBL().Consultar_Lista();
            LstTipoEnfermedad = new EnfermedadesBL().Consultar_Lista().DistinctBy(x => x.EnfermedadTipo).ToList();

        }


        public bool Insertar(string login)
        {
            bool v = false;
            //DatosFami BE = new DatosPersonales1003BE();
            //this.UsuarioRegistro = login;
            //this.DatosPersonalesId = new DatosPersonales1003BL().GetMaxId() + 1;
            //this.EstadoId = 1;

            //BE = ViewModelToBE(this);

            //if (new DatosPersonales1003BL().Insertar(BE) == false)
            //{
            //    this.ErrorSMS = "Error al Insertar Datos Personales";
            //    return false;
            //}

            //DeclaranteIdentificacionesBE m_BE = new DeclaranteIdentificacionesBE();
            //foreach (AgregarDocumentoViewModel vm in LstAgregarDocumentoVM)
            //{

            //    m_BE.DatosPersonalesId = BE.DatosPersonalesId;
            //    m_BE.UsuarioRegistro = login; ;
            //    m_BE.EstadoId = 1;
            //    m_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            //    m_BE.DocumentoIdentidadTipoId = Int32.Parse(vm.DocumentoIdentidadTipoId);
            //    m_BE.DeclaranteNumeroDocumento = vm.NroDocumentoIdentidad;

            //    if (new DeclaranteIdentificacionesBL().Insertar(m_BE) == false)
            //    {
            //        this.ErrorSMS = "Error al Insertar Datos Personales : " + m_BE.DeclaranteNumeroDocumento;
            //        return false;
            //    }
            //}

            return true;
        }


    }
}