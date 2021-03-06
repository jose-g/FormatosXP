using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;


namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003InformacionCastrenseViewModel
    {
        public string ErrorSMS { get; set; } = "";
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public Int32 X1003InformacionCastrenseId { get; set; }


        public List<AgregarAscensosObtenidosViewModel> LstAscensos;
        public List<AgregarCargosFuncionesRealizadasViewModel> LstCargos;
        public List<AgregarCondecoracionesViewModel> LstCondecoraciones;
        public List<AgregarCursoRealizadoViewModel> LstCursos;
        public List<AgregarIdiomaDominadoViewModel> LstIdiomas;

        public void CargarTablasMaestras()
        {

        }
        public X1003InformacionCastrenseViewModel()
        {
            LstAscensos = new List<AgregarAscensosObtenidosViewModel>();
            LstCargos = new List<AgregarCargosFuncionesRealizadasViewModel>();
            LstCondecoraciones = new List<AgregarCondecoracionesViewModel>();
            LstCursos = new List<AgregarCursoRealizadoViewModel>();
            LstIdiomas = new List<AgregarIdiomaDominadoViewModel>();
        }
        public List<CondecoracionesExtranjerasBE> GetCondecoracionesPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new CondecoracionesExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }

        public List<GradosExtranjerosBE> GetGradosPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new GradosExtranjerosBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Descripcion).ToList();

        }

        public List<EscuelasExtranjerasBE> GetEscuelasPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new EscuelasExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }

        public List<CursosEscuelasExtranjerasBE> GetCursosPorEscuelas(string EscuelaExtranjeraId)
        {
            return new CursosEscuelasExtranjerasBL().Consultar_Lista().Where(x => x.EscuelaExtranjeraId.ToString().Equals(EscuelaExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }

        public bool Insertar(string login)
        {
            InformacionCastrenseX1003BE c_BE = new InformacionCastrenseX1003BE();
            c_BE.InformacionCastrenseId = new InformacionCastrenseX1003BL().GetMaxId() + 1;
            c_BE.EstadoId = 1;
            c_BE.FichaId = this.FichaId;
            c_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            c_BE.UsuarioRegistro = login;

            if (new InformacionCastrenseX1003BL().Consultar_PK(c_BE.InformacionCastrenseId).FirstOrDefault() == null)
            {
                if (new InformacionCastrenseX1003BL().Insertar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Insertar Informacion Castrense";
                    RollBack(c_BE.InformacionCastrenseId);
                    return false;
                }
            }
            else
            {
                if (new InformacionCastrenseX1003BL().Actualizar(c_BE) == false)
                {
                    this.ErrorSMS = "Error al Actualizar Informacion Castrense";
                    RollBack(c_BE.InformacionCastrenseId);
                    return false;
                }
            }

            // guardar ascensos
            if (LstAscensos != null)
            {
                int AscensosObtenidosId = new AscensosObtenidosBL().GetMaxId();
                foreach (AgregarAscensosObtenidosViewModel dom in LstAscensos)
                {
                    AscensosObtenidosBE d_BE = new AscensosObtenidosBE();

                    d_BE.AscensosObtenidosId = ++AscensosObtenidosId;
                    d_BE.InformacionCastrenseId = c_BE.InformacionCastrenseId;
                    d_BE.GradoExtranjeroId = dom.Asc_Obt_GradoId;
                    d_BE.GradoExtranjeroAno = dom.Asc_Obt_Fecha;
                    d_BE.InstitucionMilitarExtranjeroId = dom.Asc_Obt_InstitucionMilitarExtranjeraId;
                    d_BE.PaisId = dom.Asc_Obt_PaisId;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new AscensosObtenidosBL().Consultar_PK(d_BE.AscensosObtenidosId).FirstOrDefault() == null)
                    {
                        if (new AscensosObtenidosBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new AscensosObtenidosBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                }
            }
            // guardar cargos
            if (LstCargos != null)
            {
                int CargosFuncionesRealizadasId = new CargosFuncionesRealizadasBL().GetMaxId();
                foreach (AgregarCargosFuncionesRealizadasViewModel dom in LstCargos)
                {
                    CargosFuncionesRealizadasBE d_BE = new CargosFuncionesRealizadasBE();

                    d_BE.CargosFuncionesRealizadasId = ++CargosFuncionesRealizadasId;
                    d_BE.CargosFuncionesId = dom.CargosFuncionesId;
                    d_BE.InformacionCastrenseId = c_BE.InformacionCastrenseId;
                    d_BE.Cargos_Funciones_FechaInicio = dom.Cargos_Funciones_FechaInicio;
                    d_BE.Cargos_Funciones_FechaFin = dom.Cargos_Funciones_FechaFin;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new CargosFuncionesRealizadasBL().Consultar_PK(d_BE.CargosFuncionesRealizadasId).FirstOrDefault() == null)
                    {
                        if (new CargosFuncionesRealizadasBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new CargosFuncionesRealizadasBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                }
            }
            // guardar condecoraciones
            if (LstCondecoraciones != null)
            {
                int CondecoracionesObtenidasId = new CondecoracionesObtenidasBL().GetMaxId();
                foreach (AgregarCondecoracionesViewModel dom in LstCondecoraciones)
                {
                    CondecoracionesObtenidasBE d_BE = new CondecoracionesObtenidasBE();

                    d_BE.CondecoracionesObtenidasId = ++CondecoracionesObtenidasId;
                    d_BE.InformacionCastrenseId = c_BE.InformacionCastrenseId;
                    d_BE.Condecoraciones_PaisId = dom.Condecoraciones_PaisId;
                    d_BE.Condecoraciones_InstitucionMilitarExtranjeraId = dom.Condecoraciones_InstitucionMilitarExtranjeraId;
                    d_BE.CondecoracionesExtranjerasId = dom.CondecoracionesExtranjerasId;
                    d_BE.CondecoracionesExtranjerasAno = dom.CondecoracionesExtranjerasAno;
                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new CondecoracionesObtenidasBL().Consultar_PK(d_BE.CondecoracionesObtenidasId).FirstOrDefault() == null)
                    {
                        if (new CondecoracionesObtenidasBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new CondecoracionesObtenidasBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                }
            }
            // guardar escuelas
            if (LstCursos != null)
            {
                int CursosRealizadosId = new CursosRealizadosBL().GetMaxId();
                foreach (AgregarCursoRealizadoViewModel dom in LstCursos)
                {
                    CursosRealizadosBE d_BE = new CursosRealizadosBE();

                    d_BE.CursosRealizadosId = ++CursosRealizadosId;
                    d_BE.InformacionCastrenseId = c_BE.InformacionCastrenseId;
                    d_BE.PaisId = dom.CR_PaisId;
                    d_BE.InstitucionMilitaresExtranjerasId = dom.CR_InstitucionMilitaresExtranjerasId;
                    d_BE.EscuelaExtranjeraId = dom.CR_EscuelaExtranjeraId;
                        d_BE.CursoEscuelaExtranjeraId = dom.CR_CursoEscuelaExtranjeraId;
                        d_BE.Ano = dom.CR_Ano;
        d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new CursosRealizadosBL().Consultar_PK(d_BE.CursosRealizadosId).FirstOrDefault() == null)
                    {
                        if (new CursosRealizadosBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new CursosRealizadosBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                }
            }
            // guardar idiomas
            if (LstIdiomas != null)
            {
                int IdiomasDominadosId = new IdiomasDominadosBL().GetMaxId();
                foreach (AgregarIdiomaDominadoViewModel dom in LstIdiomas)
                {
                    IdiomasDominadosBE d_BE = new IdiomasDominadosBE();

                    d_BE.IdiomasDominadosId = ++IdiomasDominadosId;
                    d_BE.InformacionCastrenseId = c_BE.InformacionCastrenseId;

                    d_BE.IdiomaId = dom.IdiomaDominadoId;
                    d_BE.Hablado = dom.IdiomaHabla;
                    d_BE.Escrito = dom.IdiomaEscrito;
                    d_BE.Leido = dom.IdiomaLeido;


                    d_BE.EstadoId = 1;
                    d_BE.UsuarioRegistro = login;
                    d_BE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
                    if (new IdiomasDominadosBL().Consultar_PK(d_BE.IdiomasDominadosId).FirstOrDefault() == null)
                    {
                        if (new IdiomasDominadosBL().Insertar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Insertar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                    else
                    {
                        if (new IdiomasDominadosBL().Actualizar(d_BE) == false)
                        {
                            this.ErrorSMS = "Error al Actualizar Ascensos";
                            RollBack(c_BE.InformacionCastrenseId);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void RollBack(int InformacionCastrenseX1003Id)
        {
            InformacionCastrenseX1003BE vm = new InformacionCastrenseX1003BE();
            vm = new InformacionCastrenseX1003BL().Consultar_PK(InformacionCastrenseX1003Id).FirstOrDefault();
            new InformacionCastrenseX1003BL().Anular(vm);

            foreach (AscensosObtenidosBE dom in new AscensosObtenidosBL().Consultar_Lista().Where(x => x.InformacionCastrenseId == InformacionCastrenseX1003Id))
                new AscensosObtenidosBL().Anular(dom);

            foreach (CargosFuncionesRealizadasBE dom in new CargosFuncionesRealizadasBL().Consultar_Lista().Where(x => x.InformacionCastrenseId == InformacionCastrenseX1003Id))
                new CargosFuncionesRealizadasBL().Anular(dom);

            foreach (CondecoracionesObtenidasBE dom in new CondecoracionesObtenidasBL().Consultar_Lista().Where(x => x.InformacionCastrenseId == InformacionCastrenseX1003Id))
                new CondecoracionesObtenidasBL().Anular(dom);

            foreach (CursosRealizadosBE dom in new CursosRealizadosBL().Consultar_Lista().Where(x => x.InformacionCastrenseId == InformacionCastrenseX1003Id))
                new CursosRealizadosBL().Anular(dom);

            foreach (IdiomasDominadosBE dom in new IdiomasDominadosBL().Consultar_Lista().Where(x => x.InformacionCastrenseId == InformacionCastrenseX1003Id))
                new IdiomasDominadosBL().Anular(dom);
        }

        public X1003InformacionCastrenseViewModel BuscarxFicha(int m_FichaId)
        {
            int m_Id;
            try
            {
                m_Id = new InformacionCastrenseX1003BL().Consultar_FK(m_FichaId).FirstOrDefault().InformacionCastrenseId;
                return BuscarxId(m_Id);
            }
            catch (Exception e)
            {
                return new X1003InformacionCastrenseViewModel();
            }
        }
        public X1003InformacionCastrenseViewModel BuscarxId(int m_InformacionCastrenseId)
        {
            InformacionCastrenseX1003BE m_BE = new InformacionCastrenseX1003BL().Consultar_PK(m_InformacionCastrenseId).FirstOrDefault();

            X1003InformacionCastrenseViewModel vm = new X1003InformacionCastrenseViewModel();
            vm = BEToViewModel(m_BE);

            List<AscensosObtenidosBE> lstBE_Ascensos = new List<AscensosObtenidosBE>();
            lstBE_Ascensos = new AscensosObtenidosBL().Consultar_FK(m_InformacionCastrenseId);

            foreach (AscensosObtenidosBE be in lstBE_Ascensos)
            {
                AgregarAscensosObtenidosViewModel VM = new AgregarAscensosObtenidosViewModel();
                VM.Asc_Obt_GradoId = be.GradoExtranjeroId;
                VM.Asc_Obt_Fecha = be.GradoExtranjeroId;
                VM.Asc_Obt_InstitucionMilitarExtranjeraId = be.InstitucionMilitarExtranjeroId;
                VM.Asc_Obt_PaisId = be.PaisId;
                VM.Asc_Obt_Fecha = be.GradoExtranjeroAno;
                vm.LstAscensos.Add(VM);
            }

            List<CargosFuncionesRealizadasBE> lstBE_Cargos = new List<CargosFuncionesRealizadasBE>();
            lstBE_Cargos = new CargosFuncionesRealizadasBL().Consultar_FK(m_InformacionCastrenseId);

            foreach (CargosFuncionesRealizadasBE be in lstBE_Cargos)
            {
                AgregarCargosFuncionesRealizadasViewModel VM = new AgregarCargosFuncionesRealizadasViewModel();
                VM.CargosFuncionesId = be.CargosFuncionesId.Value;
                VM.Cargos_Funciones_FechaInicio = be.Cargos_Funciones_FechaInicio;
                VM.Cargos_Funciones_FechaFin = be.Cargos_Funciones_FechaFin;
                vm.LstCargos.Add(VM);
            }

            List<CondecoracionesObtenidasBE> lstBE_Condecoraciones = new List<CondecoracionesObtenidasBE>();
            lstBE_Condecoraciones = new CondecoracionesObtenidasBL().Consultar_FK(m_InformacionCastrenseId);

            foreach (CondecoracionesObtenidasBE be in lstBE_Condecoraciones)
            {
                AgregarCondecoracionesViewModel VM = new AgregarCondecoracionesViewModel();
                VM.Condecoraciones_PaisId = be.Condecoraciones_PaisId;
                VM.Condecoraciones_InstitucionMilitarExtranjeraId = be.Condecoraciones_InstitucionMilitarExtranjeraId;
                VM.CondecoracionesExtranjerasId = be.CondecoracionesExtranjerasId;
                VM.CondecoracionesExtranjerasAno = be.CondecoracionesExtranjerasAno;
                vm.LstCondecoraciones.Add(VM);
            }

            List<CursosRealizadosBE> lstBE_Cursos = new List<CursosRealizadosBE>();
            lstBE_Cursos = new CursosRealizadosBL().Consultar_FK(m_InformacionCastrenseId);

            foreach (CursosRealizadosBE be in lstBE_Cursos)
            {
                AgregarCursoRealizadoViewModel VM = new AgregarCursoRealizadoViewModel();
                VM.CR_PaisId = be.PaisId;
                VM.CR_InstitucionMilitaresExtranjerasId = be.InstitucionMilitaresExtranjerasId;
                VM.CR_EscuelaExtranjeraId = be.EscuelaExtranjeraId;
                VM.CR_CursoEscuelaExtranjeraId = be.CursoEscuelaExtranjeraId;
                VM.CR_Ano = be.Ano;
                vm.LstCursos.Add(VM);
            }

            List<IdiomasDominadosBE> lstBE_Idiomas = new List<IdiomasDominadosBE>();
            lstBE_Idiomas = new IdiomasDominadosBL().Consultar_FK(m_InformacionCastrenseId);

            foreach (IdiomasDominadosBE be in lstBE_Idiomas)
            {
                AgregarIdiomaDominadoViewModel VM = new AgregarIdiomaDominadoViewModel();
                VM.IdiomaDominadoId = be.IdiomaId;
                VM.IdiomaHabla = be.Hablado.Value;
                VM.IdiomaEscrito = be.Escrito.Value;
                VM.IdiomaLeido = be.Leido.Value;
                vm.LstIdiomas.Add(VM);
            }
            return vm;
        }
        private X1003InformacionCastrenseViewModel BEToViewModel(InformacionCastrenseX1003BE m_BE)
        {
            X1003InformacionCastrenseViewModel m_vm = new X1003InformacionCastrenseViewModel();

            m_vm.X1003InformacionCastrenseId = m_BE.InformacionCastrenseId;
            m_vm.FichaId = m_BE.FichaId;

            m_vm.LstAscensos = this.LstAscensos;
            m_vm.LstCargos = this.LstCargos;
            m_vm.LstCondecoraciones = this.LstCondecoraciones;
            m_vm.LstCursos = this.LstCursos;
            m_vm.LstIdiomas = this.LstIdiomas;

            return m_vm;
        }
    }
}