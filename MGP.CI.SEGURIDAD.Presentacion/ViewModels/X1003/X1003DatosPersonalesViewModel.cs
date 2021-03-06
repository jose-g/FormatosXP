﻿using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MGP.CI.SEGURIDAD.Negocio;
using Microsoft.Ajax.Utilities;
using MGP.CI.SEGURIDAD.Presentacion.Views.X1003;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003DatosPersonalesViewModel
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }
        public Int32 DatosPersonalesId { get; set; }

        #region Declarante
        [Required]
        [Display(Name = "Pais")]
        public int PaisInstitucionId { get; set; } = 5;

        [Required]
        [Display(Name = "Institucion Militar ")]
        public int InstitucioneMilitarExtranjeraId { get; set; } = 5;

        [Required]
        [Display(Name = "Grado")]
        public int GradoExtranjeroId { get; set; } = 3;

        [Required]
        [Display(Name = "Especialidad")]
        public int EspecialidadExtranjeraId { get; set; } = 3;

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Paterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string Materno { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres1 { get; set; }

        [Required]
        public string Nombres2 { get; set; }

        [Required]
        public string Nombres3 { get; set; }

        [Required]
        [Display(Name = "Nacionalidad")]
        public int NacionalidadId { get; set; } = 5;

        [Required]
        [Display(Name = "Pais de Nacimiento")]
        public int PaisNacimientoId { get; set; } = 1;

        [Required]
        [Display(Name = "Lugar de Nacimiento")]
        public string LugarNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Grupo Sanguineo")]
        public int GrupoSanguineoId { get; set; } = 1;

        [Display(Name = "Tipo de Enfermedad")]
        public int EnfermedadTipoId { get; set; } = 1;
              [Required]
        [Display(Name = "Enfermedad")]
        public string EnfermedadId { get; set; }

        [Required]
        [Display(Name = "Estado Civil")]
        public int EstadoCivilId { get; set; } = 1;

        public List<FotosViewModel> LstFotos { get; set; }

        public List<DeclaranteIdentificacionesBE> LstIdentificaciones;
        public List<DeclaranteIdentificacionesBE> LstMaestraIdentificaciones;
        public List<AgregarDocumentoViewModel> LstAgregarDocumentoVM;
        public int? EstadoId { get; set; } = 1;
        public string UsuarioRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public string UsuarioModificacionRegistro { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime? FechaModificacionRegistro { get; set; }
        [Display(Name = "IP de Registro")]
        public string NroIpRegistro { get; set; }
        [Display(Name = "Pais")]
        public int PaisInstitucionNombre{ get; set; } = 5;
        [Display(Name = "Grado")]
        public int GradoInstitucionNombre { get; set; } = 5;
        public int GradoInstitucionId { get; set; } = 5;
        [Display(Name = "Especialidad")]
        public int EspecialidadInstitucionNombre { get; set; } = 5;
        public int EspecialidadInstitucionId { get; set; } = 5;
        [Display(Name = "Categoria Militar ")]
        public int CategoriaMilitarId { get; set; } = 2;
        [Display(Name = "Especialidad")]
        public int EspecialidadId { get; set; } = 1;
        [Display(Name = "Nro de Documento de Identidad")]
        public int DocumentoIdentidadNro { get; set; } = 5;
        [Display(Name = "Nro de Pasaporte")]
        public int PasaporteNro { get; set; } = 5;
        [Display(Name = "Tipo de Documento")]
        public int  DocumentosTipoId { get; set; } = 5;
        public List<DocumentoIdentidadTiposBE> LstTipoDocumentos { get; set; } 
        [Display(Name = "Tipo de Pasaporte")]
        public int TipoPasaporteId { get; set; } = 1;
        public List<SelectListItem> LstTiposPasaportes { get; set; }

        [Display(Name = "Sexo")]
        public int SexoId{ get; set; } = 1;

        #endregion
      

        #region Maestras
        public List<PaisesBE> LstPaises { get; set; }
        public List<InstitucionesMilitaresExtranjerasBE> LstInstitucionesMilitaresExtranjeras{ get; set; }
        public List<NacionalidadBE> LstNacionalidades { get; set; }
        public List<EstadoCivilBE> LstEstadoCivil { get; set; }
        public List<GrupoSanguineoBE> LstGrupoSanguineo { get; set; }
        public List<EnfermedadesBE> LstTipoEnfermedad { get; set; }
        public List<EnfermedadesBE> LstEnfermedad { get; set; }
        #endregion


        public List<EnfermedadesBE> GetEnfermedadxTipo(string EnfermedadesId)
        {
            return new EnfermedadesBL().Consultar_Lista().Where(x => x.EnfermedadesId.ToString().StartsWith(EnfermedadesId.Substring(0, 2))).ToList();
        }
        public X1003DatosPersonalesViewModel()
        {
            LstPaises = new List<PaisesBE>();
            LstInstitucionesMilitaresExtranjeras = new List<InstitucionesMilitaresExtranjerasBE>();
            LstNacionalidades = new List<NacionalidadBE>();
            LstEstadoCivil = new List<EstadoCivilBE>();
            LstGrupoSanguineo = new List<GrupoSanguineoBE>();
            LstTiposPasaportes = new List<SelectListItem>();
            LstTipoDocumentos = new List<DocumentoIdentidadTiposBE>();
            LstMaestraIdentificaciones = new List<DeclaranteIdentificacionesBE>();
            LstTipoEnfermedad = new List<EnfermedadesBE>();
            LstFotos = new List<FotosViewModel>();
            LstIdentificaciones = new List<DeclaranteIdentificacionesBE>();
        }
        public bool Insertar(string login)
        {
            bool v = false;
            DatosPersonales1003BE BE = new DatosPersonales1003BE();
            this.UsuarioRegistro = login;
            this.DatosPersonalesId = new DatosPersonales1003BL().GetMaxId() + 1;
            this.EstadoId = 1;

            BE = ViewModelToBE(this);

            if (new DatosPersonales1003BL().Insertar(BE) == false)
            {
                this.ErrorSMS = "Error al Insertar Datos Personales";
                return false;
            }

            DeclaranteIdentificacionesBE m_BE = new DeclaranteIdentificacionesBE();
            foreach (AgregarDocumentoViewModel vm in LstAgregarDocumentoVM)
            {
                
                m_BE.DatosPersonalesId = BE.DatosPersonalesId;
                m_BE.UsuarioRegistro = login; ;
                m_BE.EstadoId = 1;
                m_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                m_BE.DocumentoIdentidadTipoId = Int32.Parse(vm.DocumentoIdentidadTipoId);
                m_BE.DeclaranteNumeroDocumento= vm.NroDocumentoIdentidad;

                if (new DeclaranteIdentificacionesBL().Insertar(m_BE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Datos Personales : " + m_BE.DeclaranteNumeroDocumento;
                    return false;
                }
            }

            FotosViewModel f_vm = new FotosViewModel();

            foreach (FotosViewModel vm in LstFotos)
            {
                if (vm.GrabarFotos(this.DatosPersonalesId, this.Paterno, this.Materno, login) == false)
                {
                    this.ErrorSMS = "Error al Insertar Datos Personales : " + m_BE.DeclaranteNumeroDocumento;
                    return false;
                }

                return true;
            }

            return true;
        }
        public void ConvertToIdentificacionesBE(string[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                DeclaranteIdentificacionesBE BE = new DeclaranteIdentificacionesBE();
                string[] register = array[i];
                BE.DocumentoIdentidadTipoId = Int32.Parse(register[0]);
                BE.DeclaranteNumeroDocumento = register[1];
                LstMaestraIdentificaciones.Add(BE);
            }
        }
        private DatosPersonales1003BE ViewModelToBE(X1003DatosPersonalesViewModel m_vm)
        {
            DatosPersonales1003BE BE = new DatosPersonales1003BE();

            BE.DatosPersonalesId = m_vm.DatosPersonalesId;
            BE.FichaId = m_vm.FichaId;
            BE.GradoExtranjeroId = m_vm.GradoExtranjeroId;
            BE.EspecialidaIdExtranjeraId = m_vm.EspecialidadExtranjeraId;
            BE.Paterno = m_vm.Paterno;
            BE.Materno = m_vm.Materno;
            BE.Nombres1 = m_vm.Nombres1;
            BE.Nombres2 = m_vm.Nombres2;
            BE.Nombres3 = m_vm.Nombres3;
            BE.FechaNamiento = m_vm.FechaNacimiento;
            BE.NacionalidadId = m_vm.NacionalidadId;
            BE.PaisId = m_vm.PaisNacimientoId;
            BE.LugarNacimiento = m_vm.LugarNacimiento;
            BE.EstadoCivilId = m_vm.EstadoCivilId;
            BE.GrupoSanguineoId = m_vm.GrupoSanguineoId;
            BE.EnfermedadId = Int32.Parse(m_vm.EnfermedadId);
            //BE.Enfermedades = m_vm.Enfermedades;
          //  BE.Alergias = m_vm.Alergias;
            BE.EstadoId = m_vm.EstadoId;
            BE.UsuarioRegistro = m_vm.UsuarioRegistro;
            BE.FechaRegistro = m_vm.FechaRegistro;
            BE.UsuarioModificacionRegistro = m_vm.UsuarioModificacionRegistro;
            BE.FechaModificacionRegistro = m_vm.FechaModificacionRegistro;
            BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            BE.SexoId = m_vm.SexoId;
            BE.EstadoDatosPersonales = true;

            return BE;
        }
        public void CargarTablasMaestras()
        {
            LstPaises = new PaisesBL().Consultar_Lista().OrderBy(x => x.Nombre).ToList();
            LstInstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasBL().Consultar_Lista();
            LstNacionalidades = new NacionalidadBL().Consultar_Lista();
            LstEstadoCivil = new EstadoCivilBL().Consultar_Lista();
            LstGrupoSanguineo = new GrupoSanguineoBL().Consultar_Lista();
            LstTipoDocumentos = new DocumentoIdentidadTiposBL().Consultar_Lista();
            LstTipoEnfermedad = new EnfermedadesBL().Consultar_Lista().DistinctBy(x => x.EnfermedadTipo).ToList();

        }
        public List<InstitucionesMilitaresExtranjerasBE> GetInstitucionesPorPais(string PaisId)
        {
            return new InstitucionesMilitaresExtranjerasBL().Consultar_Lista().Where(x => x.PaisId.ToString().Equals(PaisId)).OrderBy(x=>x.Descripcion).ToList();

        }
        public List<GradosExtranjerosBE> GetGradosExtranjerosPorInstitucionMilitar(string InstitucionMilitarExtranjeraId)
        {
            return new GradosExtranjerosBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucionMilitarExtranjeraId)).ToList();
        }
        public List<EspecialidadesExtranjerasBE> GetEspecialidadExtranjerosPorInstitucion(string GradoExtranjeroId)
        {
            int InstMilExtId = new GradosExtranjerosBL().Consultar_PK(Int32.Parse(GradoExtranjeroId)).FirstOrDefault().InstitucionMilitarExtranjeraId.Value;

            return new EspecialidadesExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId == InstMilExtId).ToList();
        }
    }
}