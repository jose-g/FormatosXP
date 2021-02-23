using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class GrupoSanguineoBL : BaseBL
    {
        const string Nombre_Clase = "GrupoSanguineoBL";
        private string m_BaseDatos = string.Empty;

        public GrupoSanguineoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public GrupoSanguineoBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(GrupoSanguineoBE e_GrupoSanguineo)
        {
            try
            {
                GrupoSanguineoDA o_GrupoSanguineo = new GrupoSanguineoDA(m_BaseDatos);
                int resp = o_GrupoSanguineo.Insertar(e_GrupoSanguineo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(GrupoSanguineoBE e_GrupoSanguineo)
        {
            try
            {
                GrupoSanguineoDA o_GrupoSanguineo = new GrupoSanguineoDA(m_BaseDatos);
                int resp = o_GrupoSanguineo.Actualizar(e_GrupoSanguineo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(GrupoSanguineoBE e_GrupoSanguineo)
        {
            try
            {
                GrupoSanguineoDA o_GrupoSanguineo = new GrupoSanguineoDA(m_BaseDatos);
                int resp = o_GrupoSanguineo.Anular(e_GrupoSanguineo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GrupoSanguineoBE> Consultar_Lista()
        {
            List<GrupoSanguineoBE> lista = new List<GrupoSanguineoBE>();
            try
            {
                GrupoSanguineoDA o_GrupoSanguineo = new GrupoSanguineoDA(m_BaseDatos);
                return o_GrupoSanguineo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GrupoSanguineoBE> Consultar_PK(
                              int m_GrupoSanguineoId
                              )
        {
            List<GrupoSanguineoBE> lista = new List<GrupoSanguineoBE>();
            try
            {
                GrupoSanguineoDA o_GrupoSanguineo = new GrupoSanguineoDA(m_BaseDatos);
                return o_GrupoSanguineo.Consultar_PK(
                                                            m_GrupoSanguineoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
