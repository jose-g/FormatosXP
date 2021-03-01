using MGP.CI.SEGURIDAD.Entidades.XP1003;
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
using System.Text;

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
        public int PaisInstitucionId { get; set; } = -1;

        [Required]
        [Display(Name = "Institucion Militar ")]
        public int InstitucioneMilitarExtranjeraId { get; set; } = -1;

        [Required]
        [Display(Name = "Grado")]
        public int GradoExtranjeroId { get; set; } = -1;

        [Required]
        [Display(Name = "Especialidad")]
        public int EspecialidadExtranjeraId { get; set; } = -1;

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
        public int NacionalidadId { get; set; } = -1;

        [Required]
        [Display(Name = "Pais de Nacimiento")]
        public int PaisNacimientoId { get; set; } = -1;

        [Required]
        [Display(Name = "Lugar de Nacimiento")]
        public string LugarNacimiento { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Grupo Sanguineo")]
        public int GrupoSanguineoId { get; set; } = -1;

        [Required]
        [Display(Name = "Tipo de Enfermedad")]
        public int EnfermedadTipoId { get; set; } = -1;

        [Required]
        [Display(Name = "Enfermedad")]
        public int EnfermedadId { get; set; } = -1;

        [Required]
        [Display(Name = "Estado Civil")]
        public int EstadoCivilId { get; set; } = -1;

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
        public List<GradosExtranjerosBE> LstGradosExtranjeros { get; set; }
        public List<EspecialidadesExtranjerasBE> LstEspecialidadesExtranjeras { get; set; }
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
            LstGradosExtranjeros = new List<GradosExtranjerosBE>();
            LstEspecialidadesExtranjeras = new List<EspecialidadesExtranjerasBE>();
            LstNacionalidades = new List<NacionalidadBE>();
            LstEstadoCivil = new List<EstadoCivilBE>();
            LstGrupoSanguineo = new List<GrupoSanguineoBE>();
            LstTiposPasaportes = new List<SelectListItem>();
            LstTipoDocumentos = new List<DocumentoIdentidadTiposBE>();
            LstMaestraIdentificaciones = new List<DeclaranteIdentificacionesBE>();
            LstTipoEnfermedad = new List<EnfermedadesBE>();
            LstFotos = new List<FotosViewModel>();
            LstIdentificaciones = new List<DeclaranteIdentificacionesBE>();
            LstEnfermedad = new List<EnfermedadesBE>();
            LstAgregarDocumentoVM = new List<AgregarDocumentoViewModel>();
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
            BE.PaisInstitucionId = m_vm.PaisInstitucionId;
            BE.InstitucionMilitarExtranjeroId = m_vm.InstitucioneMilitarExtranjeraId;
            BE.PaisId = m_vm.PaisNacimientoId;
            BE.LugarNacimiento = m_vm.LugarNacimiento;
            BE.EstadoCivilId = m_vm.EstadoCivilId;
            BE.GrupoSanguineoId = m_vm.GrupoSanguineoId;
            BE.EnfermedadId = m_vm.EnfermedadId;
            BE.EnfermedadTipoId = m_vm.EnfermedadTipoId;
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
            LstInstitucionesMilitaresExtranjeras=new InstitucionesMilitaresExtranjerasBL().Consultar_Lista().Where(x => x.PaisId.ToString().Equals(PaisInstitucionId.ToString())).OrderBy(x => x.Descripcion).ToList();
            LstGradosExtranjeros = new GradosExtranjerosBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId.ToString())).ToList();
            LstEspecialidadesExtranjeras = new EspecialidadesExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId == InstitucioneMilitarExtranjeraId).ToList();
            LstNacionalidades = new NacionalidadBL().Consultar_Lista();
            LstEstadoCivil = new EstadoCivilBL().Consultar_Lista();
            LstGrupoSanguineo = new GrupoSanguineoBL().Consultar_Lista();
            LstTipoDocumentos = new DocumentoIdentidadTiposBL().Consultar_Lista();
            LstTipoEnfermedad = new EnfermedadesBL().Consultar_Lista().DistinctBy(x => x.EnfermedadTipo).ToList();
            LstEnfermedad = new EnfermedadesBL().Consultar_Lista().Where(x => x.EnfermedadesId.ToString().StartsWith(EnfermedadId.ToString().Substring(0, 2))).ToList();
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

        public X1003DatosPersonalesViewModel BuscarxId(int m_DatosPersonalesId)
        {
            DatosPersonales1003BE m_BE = new DatosPersonales1003BL().Consultar_PK(m_DatosPersonalesId).FirstOrDefault();

            FotosDeclarantesBL objFotosBL = new FotosDeclarantesBL();
            List<FotosDeclarantesBE> lstFotos = new List<FotosDeclarantesBE>();
            lstFotos = objFotosBL.Consultar_FK(m_DatosPersonalesId);

            FotosDeclarantesBE m_fotos_BE = new FotosDeclarantesBE();
            FotosViewModel f_vm = new FotosViewModel();

            m_fotos_BE =lstFotos.Where(x => x.FotoTipoId == 1).FirstOrDefault();
            f_vm.FotoFrente= Encoding.ASCII.GetString(m_fotos_BE.Foto);

            m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 2).FirstOrDefault();
            f_vm.FotoPosterior = Encoding.ASCII.GetString(m_fotos_BE.Foto);

            m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 3).FirstOrDefault();
            f_vm.FotoLateralIzquierdo = Encoding.ASCII.GetString(m_fotos_BE.Foto);

            m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 4).FirstOrDefault();
            f_vm.FotoLateralDerecho = Encoding.ASCII.GetString(m_fotos_BE.Foto);

            LstFotos.Add(f_vm);

            DeclaranteIdentificacionesBL objIdentBL = new DeclaranteIdentificacionesBL();
            LstIdentificaciones = objIdentBL.Consultar_FK(m_DatosPersonalesId);
            if (m_BE != null)
                return BEToViewModel(m_BE);

            return null;
        }
        public X1003DatosPersonalesViewModel BuscarxFicha(int m_FichaId)
        {

            int m_DatosPersonalesId;
            try
            {
                m_DatosPersonalesId = new DatosPersonales1003BL().Consultar_FK(m_FichaId).FirstOrDefault().DatosPersonalesId;
                return BuscarxId(m_DatosPersonalesId);
            }
            catch(Exception e)
            {

            }


            return new X1003DatosPersonalesViewModel();
        }
        private X1003DatosPersonalesViewModel BEToViewModel(DatosPersonales1003BE m_BE)
        {
            X1003DatosPersonalesViewModel m_vm = new X1003DatosPersonalesViewModel();

             m_vm.DatosPersonalesId= m_BE.DatosPersonalesId;
             m_vm.FichaId= m_BE.FichaId;
             m_vm.GradoExtranjeroId= m_BE.GradoExtranjeroId.Value;
             m_vm.EspecialidadExtranjeraId= m_BE.EspecialidaIdExtranjeraId.Value;
            m_vm.InstitucioneMilitarExtranjeraId = m_BE.InstitucionMilitarExtranjeroId.Value;
             m_vm.Paterno= m_BE.Paterno;
             m_vm.Materno= m_BE.Materno;
             m_vm.Nombres1= m_BE.Nombres1;
             m_vm.Nombres2= m_BE.Nombres2;
             m_vm.Nombres3= m_BE.Nombres3;
             m_vm.FechaNacimiento= m_BE.FechaNamiento;
             m_vm.NacionalidadId= m_BE.NacionalidadId.Value;
            m_vm.PaisInstitucionId = m_BE.PaisInstitucionId;
            //m_vm.PaisId = m_BE.PaisId;
            m_vm.PaisNacimientoId= m_BE.PaisId;
             m_vm.LugarNacimiento= m_BE.LugarNacimiento;
             m_vm.EstadoCivilId= m_BE.EstadoCivilId.Value;
             m_vm.GrupoSanguineoId= m_BE.GrupoSanguineoId.Value;
             m_vm.EnfermedadId= m_BE.EnfermedadId.Value;
            m_vm.EnfermedadTipoId = m_BE.EnfermedadTipoId.Value;
            m_vm.EstadoId= m_BE.EstadoId;
             m_vm.UsuarioRegistro= m_BE.UsuarioRegistro;
             m_vm.FechaRegistro= m_BE.FechaRegistro;
             m_vm.UsuarioModificacionRegistro= m_BE.UsuarioModificacionRegistro;
             m_vm.FechaModificacionRegistro= m_BE.FechaModificacionRegistro;
             m_vm.NroIpRegistro = m_BE.NroIpRegistro;
             m_vm.SexoId= m_BE.SexoId;

            m_vm.LstFotos = this.LstFotos;
            m_vm.LstIdentificaciones = this.LstIdentificaciones;

            return m_vm;
        }
    }
}