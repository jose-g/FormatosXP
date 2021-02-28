using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Presentacion.Views.X1003;
using System.Text;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class x1003DatosFamiliaresVM
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public Int32 DatosFamiliaresId { get; set; }
        
        public int? DatosPersonalesId { get; set; }
        public int? EstadoId { get; set; } = 1;
        public string UsuarioRegistro { get; set; }
        public int? ParentescoId { get; set; } = 3;
        public string NroIpRegistro { get; set; } = HttpContext.Current.Request.UserHostAddress;
        public int? EsResidente { get; set; }
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
        public int EsposaNacionalidadId { get; set; } = -1;
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? EsposaFechaNacimiento { get; set; }

        [Display(Name = "Pais de Nacimiento")]
        public int EsposaPaisNacimientoId { get; set; } = -1;

        [Display(Name = "Lugar de Nacimiento")]
        public string EsposaLugarNacimiento { get; set; }
        [Display(Name = "Grupo Sanguineo")]
        public int EsposaGrupoSanguineoId { get; set; } = -1;

        [Display(Name = "Alergias")]
        public int EsposaAlergiaId { get; set; } = -1;
        [Display(Name = "Profesion")]
        public int EsposaAProfesionId { get; set; } = -1;
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
        public int EsposaEnfermedadTipoId { get; set; } = -1;
        [Display(Name = "Enfermedad")]
        public int EsposaEnfermedadId { get; set; } = -1;
        public List<SexoBE> LstSexo { get; set; }
        public List<NacionalidadBE> LstNacionalidades { get; set; }
        public List<PaisesBE> LstPaises { get; set; }

        public List<IdiomaBE> LstIdiomas { get; set; }
        public List<ProfesionesBE> LstProfesiones { get; set; }
        public List<GrupoSanguineoBE> LstGrupoSanguineo { get; set; }

        #endregion
        public List<FotosFamiliaresViewModel> LstFotos;
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
            DatosFamiliares1003BE BE = new DatosFamiliares1003BE();
            this.UsuarioRegistro = login;
            this.DatosFamiliaresId = new DatosFamiliares1003BL().GetMaxId() + 1;
            this.EstadoId = 1;

            BE = ViewModelToBE(this);

            if (new DatosFamiliares1003BL().Insertar(BE) == false)
            {
                this.ErrorSMS = "Error al Insertar Datos Personales";
                return false;
            }

            //Guarda Fotos de Esposa

            FotosFamiliaresViewModel f_vm = new FotosFamiliaresViewModel();

            foreach (FotosFamiliaresViewModel vm in LstFotos)
            {
                if (vm.GrabarFotos(this.DatosFamiliaresId, login) == false)
                {
                    this.ErrorSMS = "Error al guardar fotos";
                    return false;
                }

                
            }

            // Guarda Identificacion de esposa

            FamiliarIdentificacionBE m_BE = new FamiliarIdentificacionBE();
            foreach (AgregarDocumentoViewModel vm in LstIdentificaciones)
            {
                int FamiliarIdentificacionId = new FamiliarIdentificacionBL().GetMaxId();
                m_BE.FamiliarIdentificacionId = FamiliarIdentificacionId + 1;
                m_BE.FamiliarId = this.DatosFamiliaresId;
                m_BE.UsuarioRegistro = login; ;
                m_BE.EstadoId = 1;
                m_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                m_BE.DocumentoIdentidadTipoId = Int32.Parse(vm.DocumentoIdentidadTipoId);
                m_BE.FamiliarNumeroDocumento = vm.NroDocumentoIdentidad;

                if (new FamiliarIdentificacionBL().Insertar(m_BE) == false)
                {
                    this.ErrorSMS = "Error al guardar numero de documento";
                    return false;
                }
            }


            // Guarda Idiomas de esposa

            FamiliarIdiomasBE m_idioma_BE = new FamiliarIdiomasBE();
            foreach (string IdiomaId in LstStrIdiomas)
            {
                int FamiliarIdiomasId = new FamiliarIdiomasBL().GetMaxId();
                m_idioma_BE.FamiliarIdiomasId = FamiliarIdiomasId + 1;
                m_idioma_BE.IdiomaId = Int32.Parse(IdiomaId);
                m_idioma_BE.EstadoId = 1;
                m_idioma_BE.FamiliarId = this.DatosFamiliaresId;
                m_idioma_BE.UsuarioRegistro = login;
                m_idioma_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                if (new FamiliarIdiomasBL().Insertar(m_idioma_BE) == false)
                {
                    this.ErrorSMS = "Error al guardar numero de documento";
                    return false;
                }
            }

            // Agregar informacion de hijos

            foreach (AgregarHijoViewModel vm in LstHijos)
            {

                DatosFamiliares1003BE DatosFamiliareHijoBE = new DatosFamiliares1003BE();

                DatosFamiliareHijoBE.FamiliarId= new DatosFamiliares1003BL().GetMaxId() + 1;
                DatosFamiliareHijoBE.DatosPersonalesId = this.DatosPersonalesId;
                DatosFamiliareHijoBE.ParentescoId=4;
                DatosFamiliareHijoBE.Paterno=vm.HijoPaterno;
                DatosFamiliareHijoBE.Materno=vm.HijoMaterno;
                DatosFamiliareHijoBE.Nombres1 = vm.HijoNombre1;
                DatosFamiliareHijoBE.Nombres2 = vm.HijoNombre2;
                DatosFamiliareHijoBE.Nombres3 = vm.HijoNombre3;
                DatosFamiliareHijoBE.NacionalidadId = Int32.Parse(vm.HijoNacionalidadId);
                DatosFamiliareHijoBE.FechaNamiento = vm.HijoFechaNacimiento;
                DatosFamiliareHijoBE.EstadoId=1;
                DatosFamiliareHijoBE.UsuarioRegistro=login;
                DatosFamiliareHijoBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                if (new DatosFamiliares1003BL().Insertar(DatosFamiliareHijoBE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Datos Personales";
                    return false;
                }

                // Agregar Identificacion de hijo

                FamiliarIdentificacionBE FamiliarIdentificacionHijoBE = new FamiliarIdentificacionBE();
                int FamiliarIdentificacionHijoId = new FamiliarIdentificacionBL().GetMaxId();
                FamiliarIdentificacionHijoBE.FamiliarIdentificacionId = FamiliarIdentificacionHijoId + 1;
                FamiliarIdentificacionHijoBE.FamiliarId = DatosFamiliareHijoBE.FamiliarId;
                FamiliarIdentificacionHijoBE.UsuarioRegistro = login;
                FamiliarIdentificacionHijoBE.EstadoId = 1;
                FamiliarIdentificacionHijoBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                FamiliarIdentificacionHijoBE.DocumentoIdentidadTipoId = Int32.Parse(vm.HijoDocumentoIdentidadTipoId);
                FamiliarIdentificacionHijoBE.FamiliarNumeroDocumento = vm.HijoNroDocumentoIdentidad;

                if (new FamiliarIdentificacionBL().Insertar(FamiliarIdentificacionHijoBE) == false)
                {
                    this.ErrorSMS = "Error al guardar numero de documento";
                    return false;
                }

                //Guarda Fotos de hijo

                

                foreach (FotosFamiliaresViewModel FotosFamiliaresHijo_vm in vm.LstFotos)
                {
                    if (FotosFamiliaresHijo_vm.GrabarFotos(DatosFamiliareHijoBE.FamiliarId, login) == false)
                    {
                        this.ErrorSMS = "Error al guardar fotos";
                        return false;
                    }


                }
            }

            // Agregar informacion de familiares que acompañan

            foreach (AgregarFamiliarViewModel vm in LstFamiliares)
            {

                DatosFamiliares1003BE DatosFamiliarBE = new DatosFamiliares1003BE();

                DatosFamiliarBE.FamiliarId = new DatosFamiliares1003BL().GetMaxId() + 1;
                DatosFamiliarBE.DatosPersonalesId = this.DatosPersonalesId;
                DatosFamiliarBE.ParentescoId = Int32.Parse(vm.FamiliarParentescoId);
                DatosFamiliarBE.Paterno = vm.FamiliarPaterno;
                DatosFamiliarBE.Materno = vm.FamiliarMaterno;
                DatosFamiliarBE.Nombres1 = vm.FamiliarNombre1;
                DatosFamiliarBE.Nombres2 = vm.FamiliarNombre2;
                DatosFamiliarBE.Nombres3 = vm.FamiliarNombre3;
                DatosFamiliarBE.NacionalidadId = Int32.Parse(vm.FamiliarNacionalidadId);
                DatosFamiliarBE.FechaNamiento = vm.FamiliarFechaNacimiento;
                DatosFamiliarBE.EsResidente = 0;
                DatosFamiliarBE.EstadoId = 1;
                DatosFamiliarBE.UsuarioRegistro = login;
                DatosFamiliarBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                if (new DatosFamiliares1003BL().Insertar(DatosFamiliarBE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Datos de familiares";
                    return false;
                }
                // Agregar Identificacion de familiar
                FamiliarIdentificacionBE FamiliarIdentificacionBE = new FamiliarIdentificacionBE();
                int FamiliarIdentificacionId = new FamiliarIdentificacionBL().GetMaxId();
                FamiliarIdentificacionBE.FamiliarIdentificacionId = FamiliarIdentificacionId + 1;
                FamiliarIdentificacionBE.FamiliarId = DatosFamiliarBE.FamiliarId;
                FamiliarIdentificacionBE.UsuarioRegistro = login;
                FamiliarIdentificacionBE.EstadoId = 1;
                FamiliarIdentificacionBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                FamiliarIdentificacionBE.DocumentoIdentidadTipoId = Int32.Parse(vm.FamiliarDocumentoIdentidadTipoId);
                FamiliarIdentificacionBE.FamiliarNumeroDocumento = vm.FamiliarNroDocumentoIdentidad;

                if (new FamiliarIdentificacionBL().Insertar(FamiliarIdentificacionBE) == false)
                {
                    this.ErrorSMS = "Error al guardar numero de documento";
                    return false;
                }
                //Guarda Fotos de familiar
                foreach (FotosFamiliaresViewModel FotosFamiliares_vm in vm.LstFotos)
                {
                    if (FotosFamiliares_vm.GrabarFotos(DatosFamiliarBE.FamiliarId, login) == false)
                    {
                        this.ErrorSMS = "Error al guardar fotos";
                        return false;
                    }
                }
            }

            // Agregar informacion de familiares que residen en Peru

            foreach (AgregarFamiliarResidentesEnPeru vm in LstFamResidentes)
            {

                DatosFamiliares1003BE DatosFamiliarBE = new DatosFamiliares1003BE();

                DatosFamiliarBE.FamiliarId = new DatosFamiliares1003BL().GetMaxId() + 1;
                DatosFamiliarBE.DatosPersonalesId = this.DatosPersonalesId;
                DatosFamiliarBE.ParentescoId = Int32.Parse(vm.ResidenteParentescoId);
                DatosFamiliarBE.Paterno = vm.ResidentePaterno;
                DatosFamiliarBE.Materno = vm.ResidenteMaterno;
                DatosFamiliarBE.Nombres1 = vm.ResidenteNombre1;
                DatosFamiliarBE.Nombres2 = vm.ResidenteNombre2;
                DatosFamiliarBE.Nombres3 = vm.ResidenteNombre3;
                DatosFamiliarBE.NacionalidadId = Int32.Parse(vm.ResidenteNacionalidadId);
                DatosFamiliarBE.FechaNamiento = vm.ResidenteFechaNacimiento;
                DatosFamiliarBE.EsResidente = 1;
                DatosFamiliarBE.EstadoId = 1;
                DatosFamiliarBE.UsuarioRegistro = login;
                DatosFamiliarBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

                if (new DatosFamiliares1003BL().Insertar(DatosFamiliarBE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Datos de familiares";
                    return false;
                }
                // Agregar Identificacion de familiar residente
                FamiliarIdentificacionBE FamiliarIdentificacionBE = new FamiliarIdentificacionBE();
                int FamiliarIdentificacionId = new FamiliarIdentificacionBL().GetMaxId();
                FamiliarIdentificacionBE.FamiliarIdentificacionId = FamiliarIdentificacionId + 1;
                FamiliarIdentificacionBE.FamiliarId = DatosFamiliarBE.FamiliarId;
                FamiliarIdentificacionBE.UsuarioRegistro = login;
                FamiliarIdentificacionBE.EstadoId = 1;
                FamiliarIdentificacionBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                FamiliarIdentificacionBE.DocumentoIdentidadTipoId = Int32.Parse(vm.ResidenteDocumentoIdentidadTipoId);
                FamiliarIdentificacionBE.FamiliarNumeroDocumento = vm.ResidenteNroDocumentoIdentidad;

                if (new FamiliarIdentificacionBL().Insertar(FamiliarIdentificacionBE) == false)
                {
                    this.ErrorSMS = "Error al guardar numero de documento";
                    return false;
                }
                //Guarda Fotos de familiar
                foreach (FotosFamiliaresViewModel FotosFamiliares_vm in vm.LstFotos)
                {
                    if (FotosFamiliares_vm.GrabarFotos(DatosFamiliarBE.FamiliarId, login) == false)
                    {
                        this.ErrorSMS = "Error al guardar fotos";
                        return false;
                    }
                }
            }
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
        private DatosFamiliares1003BE ViewModelToBE(x1003DatosFamiliaresVM m_vm)
        {
            DatosFamiliares1003BE BE = new DatosFamiliares1003BE();


            BE.FamiliarId = m_vm.DatosFamiliaresId;
            BE.DatosPersonalesId = m_vm.DatosPersonalesId;
            BE.ParentescoId = m_vm.ParentescoId;
            BE.Paterno = m_vm.EsposaPaterno;
            BE.Materno = m_vm.EsposaMaterno;
            BE.Nombres1 = m_vm.EsposaNombre1;
            BE.Nombres2 = m_vm.EsposaNombre2;
            BE.Nombres3 = m_vm.EsposaNombre3;
            BE.NacionalidadId = m_vm.EsposaNacionalidadId;
            BE.FechaNamiento = m_vm.EsposaFechaNacimiento;
            BE.PaisId = m_vm.EsposaPaisNacimientoId;
            BE.LugarNacimiento = m_vm.EsposaLugarNacimiento;
            BE.GrupoSanguineoId = m_vm.EsposaGrupoSanguineoId;
            BE.EnfermedadTipoId = m_vm.EsposaEnfermedadTipoId;
            BE.EnfermedadId = m_vm.EsposaEnfermedadId;
            BE.ProfesionId = m_vm.EsposaAProfesionId;
            BE.Actividades = m_vm.EsposaActividades;
            BE.EstadoId = m_vm.EstadoId;
            BE.UsuarioRegistro = m_vm.UsuarioRegistro;
            BE.NroIpRegistro = m_vm.NroIpRegistro;
            BE.EsResidente = m_vm.EsResidente;
            return BE;
        }
        
    }
}