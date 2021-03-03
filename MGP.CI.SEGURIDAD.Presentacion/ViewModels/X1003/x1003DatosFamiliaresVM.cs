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
        
        public int DatosPersonalesId { get; set; }
        public int? EstadoId { get; set; } = 1;
        public string UsuarioRegistro { get; set; }
        public int? ParentescoId { get; set; } = 3;
        public string NroIpRegistro { get; set; } = HttpContext.Current.Request.UserHostAddress;
        public int? EsResidente { get; set; }
        public int? EnfermedadTipoId { get; set; }
        public int? EnfermedadId { get; set; }

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
            LstFotos = new List<FotosFamiliaresViewModel>();

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
            LstEnfermedad = new EnfermedadesBL().Consultar_Lista().Where(x => x.EnfermedadesId.ToString().StartsWith(EsposaEnfermedadId.ToString().Substring(0, 2))).ToList();
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
        private x1003DatosFamiliaresVM BEToViewModel(DatosFamiliares1003BE BE)
        {
            x1003DatosFamiliaresVM m_vm = new x1003DatosFamiliaresVM();
            m_vm.DatosFamiliaresId= BE.FamiliarId;
            m_vm.DatosPersonalesId= BE.DatosPersonalesId;
            m_vm.ParentescoId= BE.ParentescoId;
            m_vm.EsposaPaterno= BE.Paterno;
            m_vm.EsposaMaterno= BE.Materno;
            m_vm.EsposaNombre1= BE.Nombres1;
            m_vm.EsposaNombre2= BE.Nombres2;
            m_vm.EsposaNombre3= BE.Nombres3;
            m_vm.EsposaNacionalidadId= BE.NacionalidadId.Value;
            m_vm.EsposaFechaNacimiento= BE.FechaNamiento;
            m_vm.EsposaPaisNacimientoId= BE.PaisId.Value;
            m_vm.EsposaLugarNacimiento= BE.LugarNacimiento;
            m_vm.EsposaGrupoSanguineoId= BE.GrupoSanguineoId.Value;
            m_vm.EsposaEnfermedadTipoId= BE.EnfermedadTipoId;
            m_vm.EsposaEnfermedadId= BE.EnfermedadId;
            m_vm.EsposaAProfesionId= BE.ProfesionId.Value;
            m_vm.EsposaActividades= BE.Actividades;
            m_vm.EstadoId= BE.EstadoId;
            m_vm.UsuarioRegistro= BE.UsuarioRegistro;
            m_vm.NroIpRegistro= BE.NroIpRegistro;
            m_vm.EsResidente= BE.EsResidente;
            return m_vm;
        }
        public x1003DatosFamiliaresVM BuscarxDatosPersonales(int m_DatosPersonalesId)
        {
            List<DatosFamiliares1003BE> lstDatosFamiliares = new List<DatosFamiliares1003BE>();
            try
            {
                lstDatosFamiliares = new DatosFamiliares1003BL().Consultar_FK(m_DatosPersonalesId);
                DatosFamiliares1003BE objDatosFamiliares = new DatosFamiliares1003BE();
                objDatosFamiliares = lstDatosFamiliares.Find(x => x.ParentescoId == 3);

                x1003DatosFamiliaresVM vm = new x1003DatosFamiliaresVM();

                if(objDatosFamiliares != null)
                {
                    vm = objDatosFamiliares != null ? BEToViewModel(objDatosFamiliares) : vm;

                    // carga fotos de esposa

                    FotosFamiliaresBL objFotosBL = new FotosFamiliaresBL();
                    List<FotosFamiliaresBE> lstFotos = new List<FotosFamiliaresBE>();
                    lstFotos = objFotosBL.Consultar_FK(objDatosFamiliares.FamiliarId);

                    FotosFamiliaresBE m_fotos_BE = new FotosFamiliaresBE();
                    FotosFamiliaresViewModel f_vm = new FotosFamiliaresViewModel();

                    m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 1).FirstOrDefault();
                    f_vm.FotoFrente = m_fotos_BE == null ? null : Encoding.ASCII.GetString(m_fotos_BE.Foto);

                    m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 2).FirstOrDefault();
                    f_vm.FotoPosterior = m_fotos_BE == null ? null : Encoding.ASCII.GetString(m_fotos_BE.Foto);

                    m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 3).FirstOrDefault();
                    f_vm.FotoLateralIzquierdo = m_fotos_BE == null ? null : Encoding.ASCII.GetString(m_fotos_BE.Foto);

                    m_fotos_BE = lstFotos.Where(x => x.FotoTipoId == 4).FirstOrDefault();
                    f_vm.FotoLateralDerecho = m_fotos_BE == null ? null : Encoding.ASCII.GetString(m_fotos_BE.Foto);

                    vm.LstFotos.Add(f_vm);

                    List<FamiliarIdentificacionBE> lstIdent = new FamiliarIdentificacionBL().Consultar_FK(objDatosFamiliares.FamiliarId);

                    lstIdent.ForEach(be => vm.LstIdentificaciones.Add(new AgregarDocumentoViewModel { NroDocumentoIdentidad = be.FamiliarNumeroDocumento, DocumentoIdentidadTipoId = be.DocumentoIdentidadTipoId.Value.ToString() }));

                    vm.LstStrIdiomas = new FamiliarIdiomasBL().Consultar_FK(objDatosFamiliares.FamiliarId).Select(x => x.IdiomaId).ToList().ConvertAll<string>(delegate (int? i) { return i.ToString(); }); ;
                }
                // Cargar informacion de hijos

                List<DatosFamiliares1003BE> lstHijos = lstDatosFamiliares.Where(x => x.ParentescoId == 4).ToList();

                lstHijos.ForEach(be => {
                    FamiliarIdentificacionBE FamiliarIdentificacionHijoBE = new FamiliarIdentificacionBL().Consultar_FK(be.FamiliarId).FirstOrDefault();
                    // fotos
                    FotosFamiliaresBL objFotosHijosBL = new FotosFamiliaresBL();
                    List<FotosFamiliaresBE> lstFotosHijos = new List<FotosFamiliaresBE>();
                    lstFotosHijos = objFotosHijosBL.Consultar_FK(be.FamiliarId);

                    FotosFamiliaresBE m_fotos_hijos_BE = new FotosFamiliaresBE();
                    FotosFamiliaresViewModel f_hijos_vm = new FotosFamiliaresViewModel();

                    m_fotos_hijos_BE = lstFotosHijos.Where(x => x.FotoTipoId == 1).FirstOrDefault();
                    f_hijos_vm.FotoFrente = Encoding.ASCII.GetString(m_fotos_hijos_BE.Foto);

                    m_fotos_hijos_BE = lstFotosHijos.Where(x => x.FotoTipoId == 2).FirstOrDefault();
                    f_hijos_vm.FotoPosterior = Encoding.ASCII.GetString(m_fotos_hijos_BE.Foto);

                    m_fotos_hijos_BE = lstFotosHijos.Where(x => x.FotoTipoId == 3).FirstOrDefault();
                    f_hijos_vm.FotoLateralIzquierdo = Encoding.ASCII.GetString(m_fotos_hijos_BE.Foto);

                    m_fotos_hijos_BE = lstFotosHijos.Where(x => x.FotoTipoId == 4).FirstOrDefault();
                    f_hijos_vm.FotoLateralDerecho = Encoding.ASCII.GetString(m_fotos_hijos_BE.Foto);

                    vm.LstHijos.Add(new AgregarHijoViewModel
                    {
                        HijoPaterno = be.Paterno,
                        HijoMaterno = be.Materno,
                        HijoNombre1 = be.Nombres1,
                        HijoNombre2 = be.Nombres2,
                        HijoNombre3 = be.Nombres3,
                        HijoFechaNacimiento = be.FechaNamiento,
                        HijoNacionalidadId = be.NacionalidadId.ToString(),
                        
                        HijoDocumentoIdentidadTipoId = FamiliarIdentificacionHijoBE.DocumentoIdentidadTipoId.ToString(),
                        HijoNroDocumentoIdentidad = FamiliarIdentificacionHijoBE.FamiliarNumeroDocumento,
                        LstFotos = new List<FotosFamiliaresViewModel> { f_hijos_vm }
                    });
                });

                // Cargar informacion de familiares que acompañan

                List<DatosFamiliares1003BE> lstFamiliares = lstDatosFamiliares.Where(x => x.EsResidente == 0).ToList();

                lstFamiliares.ForEach(be => {
                    FamiliarIdentificacionBE FamiliarIdentificacionBE = new FamiliarIdentificacionBL().Consultar_FK(be.FamiliarId).FirstOrDefault();

                    // fotos familiares acompañan
                    FotosFamiliaresBL objFotosFamBL = new FotosFamiliaresBL();
                    List<FotosFamiliaresBE> lstFotosFam = new List<FotosFamiliaresBE>();
                    lstFotosFam = objFotosFamBL.Consultar_FK(be.FamiliarId);

                    FotosFamiliaresBE m_fotos_fam_BE = new FotosFamiliaresBE();
                    FotosFamiliaresViewModel f_fam_vm = new FotosFamiliaresViewModel();

                    m_fotos_fam_BE = lstFotosFam.Where(x => x.FotoTipoId == 1).FirstOrDefault();
                    f_fam_vm.FotoFrente = Encoding.ASCII.GetString(m_fotos_fam_BE.Foto);

                    m_fotos_fam_BE = lstFotosFam.Where(x => x.FotoTipoId == 2).FirstOrDefault();
                    f_fam_vm.FotoPosterior = Encoding.ASCII.GetString(m_fotos_fam_BE.Foto);

                    m_fotos_fam_BE = lstFotosFam.Where(x => x.FotoTipoId == 3).FirstOrDefault();
                    f_fam_vm.FotoLateralIzquierdo = Encoding.ASCII.GetString(m_fotos_fam_BE.Foto);

                    m_fotos_fam_BE = lstFotosFam.Where(x => x.FotoTipoId == 4).FirstOrDefault();
                    f_fam_vm.FotoLateralDerecho = Encoding.ASCII.GetString(m_fotos_fam_BE.Foto);

                    vm.LstFamiliares.Add(new AgregarFamiliarViewModel
                    {
                    FamiliarPaterno = be.Paterno,
                        FamiliarMaterno = be.Materno,
                        FamiliarNombre1 = be.Nombres1,
                        FamiliarNombre2 = be.Nombres2,
                        FamiliarNombre3 = be.Nombres3,
                        FamiliarFechaNacimiento = be.FechaNamiento,
                        FamiliarNacionalidadId = be.NacionalidadId.ToString(),
                        FamiliarParentescoId = be.ParentescoId.ToString(),
                        FamiliarDocumentoIdentidadTipoId = FamiliarIdentificacionBE.DocumentoIdentidadTipoId.ToString(),
                        FamiliarNroDocumentoIdentidad = FamiliarIdentificacionBE.FamiliarNumeroDocumento,
                        LstFotos = new List<FotosFamiliaresViewModel> { f_fam_vm }
                    });
                });

                // Cargar informacion de familiares que residen en Peru

                List<DatosFamiliares1003BE> lstFamResidentes = lstDatosFamiliares.Where(x => x.EsResidente == 1).ToList();

                lstFamResidentes.ForEach(be => {
                    FamiliarIdentificacionBE FamiliarIdentificacionResidentesBE = new FamiliarIdentificacionBL().Consultar_FK(be.FamiliarId).FirstOrDefault();

                    // fotos
                    FotosFamiliaresBL objFotosresBL = new FotosFamiliaresBL();
                    List<FotosFamiliaresBE> lstFotosres = new List<FotosFamiliaresBE>();
                    lstFotosres = objFotosresBL.Consultar_FK(be.FamiliarId);

                    FotosFamiliaresBE m_fotos_res_BE = new FotosFamiliaresBE();
                    FotosFamiliaresViewModel f_res_vm = new FotosFamiliaresViewModel();

                    m_fotos_res_BE = lstFotosres.Where(x => x.FotoTipoId == 1).FirstOrDefault();
                    f_res_vm.FotoFrente = Encoding.ASCII.GetString(m_fotos_res_BE.Foto);

                    m_fotos_res_BE = lstFotosres.Where(x => x.FotoTipoId == 2).FirstOrDefault();
                    f_res_vm.FotoPosterior = Encoding.ASCII.GetString(m_fotos_res_BE.Foto);

                    m_fotos_res_BE = lstFotosres.Where(x => x.FotoTipoId == 3).FirstOrDefault();
                    f_res_vm.FotoLateralIzquierdo = Encoding.ASCII.GetString(m_fotos_res_BE.Foto);

                    m_fotos_res_BE = lstFotosres.Where(x => x.FotoTipoId == 4).FirstOrDefault();
                    f_res_vm.FotoLateralDerecho = Encoding.ASCII.GetString(m_fotos_res_BE.Foto);
                    vm.LstFamResidentes.Add(new AgregarFamiliarResidentesEnPeru
                    {
                        ResidentePaterno = be.Paterno,
                        ResidenteMaterno = be.Materno,
                        ResidenteNombre1 = be.Nombres1,
                        ResidenteNombre2 = be.Nombres2,
                        ResidenteNombre3 = be.Nombres3,
                        ResidenteFechaNacimiento = be.FechaNamiento,
                        ResidenteNacionalidadId = be.NacionalidadId.ToString(),
                        ResidenteParentescoId = be.ParentescoId.ToString(),
                        ResidenteDocumentoIdentidadTipoId = FamiliarIdentificacionResidentesBE.DocumentoIdentidadTipoId.ToString(),
                        ResidenteNroDocumentoIdentidad = FamiliarIdentificacionResidentesBE.FamiliarNumeroDocumento,
                        LstFotos = new List<FotosFamiliaresViewModel> { f_res_vm }
                    });
                });
                return vm;
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            return new x1003DatosFamiliaresVM();
        }
        
    }
}