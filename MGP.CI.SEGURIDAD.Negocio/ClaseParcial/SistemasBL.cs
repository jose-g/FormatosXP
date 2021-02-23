using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class SistemasBL : BaseBL
    {
        const string Nombre_Clase = "SistemasBL";
        private string m_BaseDatos = string.Empty;

        public SistemasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public SistemasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        private bool ValidarActualizar(SistemasBE e_Sistemas, ref string outSms)
        {
            bool v = true;

            if (e_Sistemas.Nombre == null || e_Sistemas.Nombre == "")
            {
                outSms = outSms + "Ingrese Nombre del sistema";
                v = false;
            }
            if (e_Sistemas.EstadoId == null || e_Sistemas.EstadoId <= 0)
            {
                outSms = outSms + "Seleccione el tipo de estado";
                v = false;
            }

            SistemasBE sistemasBE = this.Consultar_PK(e_Sistemas.SistemaId).FirstOrDefault();

            if (sistemasBE != null)
            {
                if (sistemasBE.Nombre == e_Sistemas.Nombre)
                {
                    outSms = outSms + "Ya existe Sistema con ese nombre" + sistemasBE.Nombre;
                    v = false;
                }
            }

            return v;
        }

        private bool ValidarInsertar(SistemasBE e_Sistemas, ref string outSms)
        {
            bool v = true;

            if (e_Sistemas.Nombre == null || e_Sistemas.Nombre == "")
            {
                outSms = outSms + "Ingrese Nombre del sistema";
                v = false;
            }
            if (e_Sistemas.EstadoId == null || e_Sistemas.EstadoId <= 0)
            {
                outSms = outSms + "Seleccione el tipo de estado";
                v = false;
            }

            SistemasBE sistemasBE = Consultar_PK(e_Sistemas.SistemaId).FirstOrDefault();

            if (sistemasBE != null)
            {
                if (sistemasBE.Nombre == e_Sistemas.Nombre)
                {
                    outSms = outSms + "Ya existe Sistema con ese nombre" + sistemasBE.Nombre;
                    v = false;
                }
            }

            return v;
        }
        public bool Insertar(SistemasBE e_Sistemas)
        {
            try
            {
                SistemasDA o_Sistemas = new SistemasDA(m_BaseDatos);
                int resp = o_Sistemas.Insertar(e_Sistemas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Insertar(SistemasBE e_Sistemas, ref String out_sms_err)
        {
            if (ValidarActualizar(e_Sistemas, ref out_sms_err) == false) return false;

            try
            {
                SistemasDA sistemasDA = new SistemasDA();
                int resp = sistemasDA.Insertar(e_Sistemas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(SistemasBE e_Sistemas)
        {
            try
            {
                SistemasDA o_Sistemas = new SistemasDA(m_BaseDatos);
                int resp = o_Sistemas.Actualizar(e_Sistemas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Actualizar(SistemasBE e_Sistemas, ref String out_sms_err)
        {
            if (ValidarActualizar(e_Sistemas, ref out_sms_err) == false) return false;

            try
            {
                SistemasDA sistemasDA = new SistemasDA();
                int resp = sistemasDA.Actualizar(e_Sistemas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }


        public bool Anular(SistemasBE e_Sistemas)
        {
            try
            {
                SistemasDA o_Sistemas = new SistemasDA(m_BaseDatos);
                int resp = o_Sistemas.Anular(e_Sistemas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SistemasBE> Consultar_Lista()
        {
            List<SistemasBE> lista = new List<SistemasBE>();
            try
            {
                SistemasDA o_Sistemas = new SistemasDA(m_BaseDatos);
                return o_Sistemas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SistemasBE> Consultar_PK(int m_SistemaId)
        {
            List<SistemasBE> lista = new List<SistemasBE>();
            try
            {
                SistemasDA o_Sistemas = new SistemasDA(m_BaseDatos);
                return o_Sistemas.Consultar_PK(m_SistemaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
