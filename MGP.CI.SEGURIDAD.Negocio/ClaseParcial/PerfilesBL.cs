using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class PerfilesBL : BaseBL
    {
        const string Nombre_Clase = "PerfilesBL";
        private string m_BaseDatos = string.Empty;

        public PerfilesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public PerfilesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        private bool ValidarInsertar(PerfilesBE e_PERFIL, ref string outSms)
        {
            bool v = true;

            if (e_PERFIL.Nombre == null || e_PERFIL.Nombre == "")
            {
                outSms = outSms + "Ingrese la descripción del perfil";
                v = false;
            }

            PerfilesBE dto = new PerfilesBE();
            dto.Nombre = e_PERFIL.Nombre;

            List<PerfilesBE> l = (new PerfilesBL()).Consultar_Lista().Where(x => x.Nombre.Equals(e_PERFIL.Nombre)).ToList();
            if (l.Count > 0)
            {
                outSms = outSms + "Ya existe registro con la descripción " + e_PERFIL.Nombre;
                v = false;
            }

            return v;
        }

        public bool Insertar(PerfilesBE e_PERFIL, ref String out_sms)
        {
            if (ValidarInsertar(e_PERFIL, ref out_sms) == false) return false;

            try
            {
                PerfilesDA o_PERFIL = new PerfilesDA();
                int resp = o_PERFIL.Insertar(e_PERFIL);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                out_sms = "Ocurrió un error al insertar registro";
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Insertar(PerfilesBE e_Perfiles)
        {
            try
            {
                PerfilesDA o_Perfiles = new PerfilesDA(m_BaseDatos);
                int resp = o_Perfiles.Insertar(e_Perfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        private bool ValidarActualizar(PerfilesBE e_PERFIL, ref string outSms)
        {
            bool v = true;

            if (e_PERFIL.Nombre == null || e_PERFIL.Nombre == "")
            {
                outSms = outSms + "Ingrese perfil";
                v = false;
            }

            List<PerfilesBE> l = (new PerfilesBL()).Consultar_Lista().Where(x => x.Nombre.Equals(e_PERFIL.Nombre)).ToList();
            if (l.Count > 0)
            {
                if (l[0].PerfilesId != e_PERFIL.PerfilesId)
                {
                    outSms = outSms + "Ya existe registro con la descripción " + e_PERFIL.Nombre;
                    v = false;
                }
            }

            return v;
        }

        public bool Actualizar(PerfilesBE e_PERFIL, ref string outSMS)
        {
            if (ValidarActualizar(e_PERFIL, ref outSMS) == false) return false;

            try
            {
                PerfilesDA o_PERFIL = new PerfilesDA();
                int resp = o_PERFIL.Actualizar(e_PERFIL);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }

        }
        public bool Actualizar(PerfilesBE e_Perfiles)
        {
            try
            {
                PerfilesDA o_Perfiles = new PerfilesDA(m_BaseDatos);
                int resp = o_Perfiles.Actualizar(e_Perfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            PerfilesBE e_PERFIL = new PerfilesBE() { PerfilesId = id };

            try
            {
                int resp = (new PerfilesDA()).Anular(e_PERFIL);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PerfilesBE e_Perfiles)
        {
            try
            {
                PerfilesDA o_Perfiles = new PerfilesDA(m_BaseDatos);
                int resp = o_Perfiles.Anular(e_Perfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilesBE> Consultar_Lista()
        {
            List<PerfilesBE> lista = new List<PerfilesBE>();
            try
            {
                PerfilesDA o_Perfiles = new PerfilesDA(m_BaseDatos);
                return o_Perfiles.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilesBE> Consultar_PK(int m_PerfilId)
        {
            List<PerfilesBE> lista = new List<PerfilesBE>();
            try
            {
                PerfilesDA o_Perfiles = new PerfilesDA(m_BaseDatos);
                return o_Perfiles.Consultar_PK(
                                                            m_PerfilId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilesBE> Listar_grilla(PerfilesBE ent)
        {
            List<PerfilesBE> l = new List<PerfilesBE>();
            try
            {
                l = (new PerfilesDA()).Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public List<PerfilesBE> ListarPerfilesDisponibles(int UsuarioId)
        {
            List<PerfilesBE> l = new List<PerfilesBE>();
            try
            {
                l = (new PerfilesDA()).ListarPerfilesDisponibles(UsuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }



    }
}
