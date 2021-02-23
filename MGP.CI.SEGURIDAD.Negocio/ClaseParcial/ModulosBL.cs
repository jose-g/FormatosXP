using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class ModulosBL : BaseBL
    {
        const string Nombre_Clase = "ModulosBL";
        private string m_BaseDatos = string.Empty;

        public ModulosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public ModulosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        private bool ValidarActualizar(ModulosBE m_moduloBE, ref string outSms)
        {
            bool v = true;

            if (m_moduloBE.Nombre == null || m_moduloBE.Nombre == "")
            {
                outSms = outSms + "Ingrese Nombre del sistema";
                v = false;
            }
            if (m_moduloBE.EstadoId <= 0)
            {
                outSms = outSms + "Seleccione el tipo de estado";
                v = false;
            }

            ModulosBE sistemasBE = this.Consultar_PK(m_moduloBE.ModuloId).FirstOrDefault();

            if (sistemasBE != null)
            {
                if (sistemasBE.Nombre == m_moduloBE.Nombre)
                {
                    outSms = outSms + "Ya existe Sistema con ese nombre" + sistemasBE.Nombre;
                    v = false;
                }
            }

            return v;
        }
        private bool ValidarInsertar(ModulosBE m_moduloBE, ref string outSms)
        {
            bool v = true;

            if (m_moduloBE.Nombre == null || m_moduloBE.Nombre == "")
            {
                outSms = outSms + "Ingrese Nombre del sistema";
                v = false;
            }
            if (m_moduloBE.EstadoId <= 0)
            {
                outSms = outSms + "Seleccione el tipo de estado";
                v = false;
            }

            ModulosBE sistemasBE = Consultar_PK(m_moduloBE.ModuloId).FirstOrDefault();

            if (sistemasBE != null)
            {
                if (sistemasBE.Nombre == m_moduloBE.Nombre)
                {
                    outSms = outSms + "Ya existe Sistema con ese nombre" + sistemasBE.Nombre;
                    v = false;
                }
            }

            return v;
        }

        public bool Insertar(ModulosBE e_Modulos)
        {
            try
            {
                ModulosDA o_Modulos = new ModulosDA(m_BaseDatos);
                int resp = o_Modulos.Insertar(e_Modulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Insertar(ModulosBE e_Modulo, ref String out_sms_err)
        {
            if (ValidarActualizar(e_Modulo, ref out_sms_err) == false) return false;

            try
            {
                ModulosDA o_Modulos = new ModulosDA();
                int resp = o_Modulos.Insertar(e_Modulo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(ModulosBE e_Modulos)
        {
            try
            {
                ModulosDA o_Modulos = new ModulosDA(m_BaseDatos);
                int resp = o_Modulos.Actualizar(e_Modulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ModulosBE e_Modulos)
        {
            try
            {
                ModulosDA o_Modulos = new ModulosDA(m_BaseDatos);
                int resp = o_Modulos.Anular(e_Modulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(ModulosBE e_Modulo, ref String out_sms_err)
        {
            if (ValidarActualizar(e_Modulo, ref out_sms_err) == false) return false;

            try
            {
                ModulosDA o_Modulos = new ModulosDA();
                int resp = o_Modulos.Actualizar(e_Modulo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ModulosBE> Consultar_Lista()
        {
            List<ModulosBE> lista = new List<ModulosBE>();
            try
            {
                ModulosDA o_Modulos = new ModulosDA(m_BaseDatos);
                return o_Modulos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ModulosBE> Consultar_PK(
                              int m_ModuloId
                              )
        {
            List<ModulosBE> lista = new List<ModulosBE>();
            try
            {
                ModulosDA o_Modulos = new ModulosDA(m_BaseDatos);
                return o_Modulos.Consultar_PK(
                                                            m_ModuloId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
