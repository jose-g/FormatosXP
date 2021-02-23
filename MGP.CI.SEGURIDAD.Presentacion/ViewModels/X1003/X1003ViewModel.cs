using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// considerar varios vm uno por cada seccion para dibujarlos de manera independiente

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003ViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE

        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }


        #endregion

        public X1003DatosPersonalesViewModel x1003datospersonalesVM;
        public X1003CargosFuncionesViewModel x1003cargosfuncionesVM;
        public X1003InformacionCastrenseViewModel x1003informacioncastrenseVM;
        public X1003OtrosViewModel x1003otrosVM;
        public x1003DatosFamiliaresVM x1003datosfamiliaresVM;


        public bool CrearNuevaFichaXP1003(string login)
        {
            bool v = false;

            DeclaranteBE declaranteBE = new DeclaranteBE();
            declaranteBE.DeclaranteId = new DeclaranteBL().GetMaxId() + 1;
            declaranteBE.isUsuario = false;
            declaranteBE.UsuarioRegistro = login;
            declaranteBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;


            if (new DeclaranteBL().Insertar(declaranteBE) == false)
            {
                this.ErrorSMS = "Error en el ingreso Declarante";
                return false;
            }
            this.DeclaranteId = declaranteBE.DeclaranteId;


            FichasBE fichaBE = new FichasBE();
            fichaBE.FichaId = new FichasBL().GetMaxId() + 1;
            fichaBE.FichaTipoId = 1;
            fichaBE.DeclaranteId = declaranteBE.DeclaranteId;
            fichaBE.EstadoFichaId = 2;
            fichaBE.UsuarioRegistro = login;
            fichaBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            if (new FichasBL().Insertar(fichaBE) == false)
            {
                this.ErrorSMS = "Error crear Ficha";
                return false;
            }
            this.FichaId = fichaBE.FichaId;

            x1003datospersonalesVM.DatosPersonalesId = new DatosPersonales1003BL().GetMaxId() + 1;
            x1003datospersonalesVM.FichaId = FichaId;
            x1003datospersonalesVM.DeclaranteId = DeclaranteId;

            x1003cargosfuncionesVM.CargosFuncionesX1003Id = new CargosFuncionesBL().GetMaxId() + 1;
            x1003cargosfuncionesVM.FichaId = FichaId;
            x1003cargosfuncionesVM.DeclaranteId = DeclaranteId;

            x1003informacioncastrenseVM.X1003InformacionCastrenseId = new InformacionCastrenseX1003BL().GetMaxId() + 1;
            x1003informacioncastrenseVM.FichaId = FichaId;
            x1003informacioncastrenseVM.DeclaranteId = DeclaranteId;

            x1003otrosVM.X1003OtrosId = new OtrosXP1003BL().GetMaxId() + 1;
            x1003otrosVM.FichaId = FichaId;
            x1003otrosVM.DeclaranteId = DeclaranteId;


            return true; ;
        }

        public X1003ViewModel()
        {
            x1003datospersonalesVM = new X1003DatosPersonalesViewModel();
            x1003datosfamiliaresVM = new x1003DatosFamiliaresVM();
            x1003cargosfuncionesVM = new X1003CargosFuncionesViewModel();
            x1003informacioncastrenseVM = new X1003InformacionCastrenseViewModel();
            x1003otrosVM = new X1003OtrosViewModel();
        }





        public void CargarTablasMaestras()
        {
            x1003datospersonalesVM.CargarTablasMaestras();
            x1003datosfamiliaresVM.CargarTablasMaestras();
            x1003cargosfuncionesVM.CargarTablasMaestras();
            x1003informacioncastrenseVM.CargarTablasMaestras();
            x1003otrosVM.CargarTablasMaestras();
        }

        private X1003ViewModel BEToViewModel(FichasBE m_BE)
        {
            X1003ViewModel m_vmM = new X1003ViewModel();


            return m_vmM;
        }


        public X1003ViewModel BuscarxId(int m_FichaId)
        {
            FichasBE m_BE = new FichasBL().Consultar_PK(m_FichaId).FirstOrDefault();

            if (m_BE != null)
                return BEToViewModel(m_BE);

            return null;
        }




    }
}