using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class FotosDeclarantesBL : BaseBL
    {
        const string Nombre_Clase = "FotosDeclarantesBL";
        private string m_BaseDatos = string.Empty;

        public FotosDeclarantesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public FotosDeclarantesBL() {  }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new FotosDeclarantesDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(FotosDeclarantesBE e_FotosDeclarantes)
        {
            try
            {
                FotosDeclarantesDA o_FotosDeclarantes = new FotosDeclarantesDA(m_BaseDatos);
                int resp = o_FotosDeclarantes.Insertar(e_FotosDeclarantes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(FotosDeclarantesBE e_FotosDeclarantes)
        {
            try
            {
                FotosDeclarantesDA o_FotosDeclarantes = new FotosDeclarantesDA(m_BaseDatos);
                int resp = o_FotosDeclarantes.Actualizar(e_FotosDeclarantes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(FotosDeclarantesBE e_FotosDeclarantes)
        {
            try
            {
                FotosDeclarantesDA o_FotosDeclarantes = new FotosDeclarantesDA(m_BaseDatos);
                int resp = o_FotosDeclarantes.Anular(e_FotosDeclarantes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotosDeclarantesBE> Consultar_Lista()
        {
            List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
            try
            {
                FotosDeclarantesDA o_FotosDeclarantes = new FotosDeclarantesDA(m_BaseDatos);
                return o_FotosDeclarantes.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotosDeclarantesBE> Consultar_PK(
                              int m_FotoDeclaranteId
                              )
        {
            List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
            try
            {
                FotosDeclarantesDA o_FotosDeclarantes = new FotosDeclarantesDA(m_BaseDatos);
                return o_FotosDeclarantes.Consultar_PK(
                                                            m_FotoDeclaranteId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
