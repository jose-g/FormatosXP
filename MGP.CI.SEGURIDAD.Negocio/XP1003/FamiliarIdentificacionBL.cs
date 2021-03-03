using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class FamiliarIdentificacionBL : BaseBL
    {
        const string Nombre_Clase = "FamiliarIdentificacionBL";
        private string m_BaseDatos = string.Empty;

        public FamiliarIdentificacionBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public FamiliarIdentificacionBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new FamiliarIdentificacionDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(FamiliarIdentificacionBE e_FamiliarIdentificacion)
        {
            try
            {
                FamiliarIdentificacionDA o_FamiliarIdentificacion = new FamiliarIdentificacionDA(m_BaseDatos);
                int resp = o_FamiliarIdentificacion.Insertar(e_FamiliarIdentificacion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        //public bool Actualizar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        //{
        //    try
        //    {
        //        DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
        //        int resp = o_DeclaranteIdentificaciones.Actualizar(e_DeclaranteIdentificaciones);
        //        return (resp > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //    }
        //}

        //public bool Anular(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        //{
        //    try
        //    {
        //        DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
        //        int resp = o_DeclaranteIdentificaciones.Anular(e_DeclaranteIdentificaciones);
        //        return (resp > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //    }
        //}

        //public List<DeclaranteIdentificacionesBE> Consultar_Lista()
        //{
        //    List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
        //    try
        //    {
        //        DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
        //        return o_DeclaranteIdentificaciones.Consultar_Lista();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //    }
        //}

        //public List<DeclaranteIdentificacionesBE> Consultar_PK(int m_DeclaranteIdentificacionId)
        //{
        //    List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
        //    try
        //    {
        //        DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
        //        return o_DeclaranteIdentificaciones.Consultar_PK(
        //                                                    m_DeclaranteIdentificacionId
        //                                                    );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //    }
        //}
        public List<FamiliarIdentificacionBE> Consultar_FK(int m_FamiliarId)
        {
            List<FamiliarIdentificacionBE> lista = new List<FamiliarIdentificacionBE>();
            try
            {
                FamiliarIdentificacionDA o_Identificacion = new FamiliarIdentificacionDA(m_BaseDatos);
                return o_Identificacion.Consultar_FK(m_FamiliarId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
    }
}
