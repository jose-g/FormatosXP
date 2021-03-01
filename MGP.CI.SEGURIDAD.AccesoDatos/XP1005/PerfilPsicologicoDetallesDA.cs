using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PerfilPsicologicoDetallesDA : BaseDA
    {
        const string Nombre_Clase = "PerfilPsicologicoDetallesDA";
        private string m_BaseDatos = string.Empty;

        public PerfilPsicologicoDetallesDA() {  }

        public int Insertar(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesInsertar", connection);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PerfilPsicologicoDetalles.PerfilPsicologicoDetallesId);
                    ParametroSP("@PerfilPsicologico1005Id", e_PerfilPsicologicoDetalles.PerfilPsicologico1005Id);
                    ParametroSP("@FisicaEdad", e_PerfilPsicologicoDetalles.FisicaEdad);
                    ParametroSP("@FisicaTalla", e_PerfilPsicologicoDetalles.FisicaTalla);
                    ParametroSP("@FisicaPeso", e_PerfilPsicologicoDetalles.FisicaPeso);
                    ParametroSP("@ContexturaId", e_PerfilPsicologicoDetalles.ContexturaId);
                    ParametroSP("@Fisicaaspectoscronico", e_PerfilPsicologicoDetalles.Fisicaaspectoscronico);
                    ParametroSP("@AparienciaExpresionRostro", e_PerfilPsicologicoDetalles.AparienciaExpresionRostro);
                    ParametroSP("@AparienciaVestido", e_PerfilPsicologicoDetalles.AparienciaVestido);
                    ParametroSP("@AparienciaModales", e_PerfilPsicologicoDetalles.AparienciaModales);
                    ParametroSP("@PensamientoCapacidad", e_PerfilPsicologicoDetalles.PensamientoCapacidad);
                    ParametroSP("@PensamientoCoherencia", e_PerfilPsicologicoDetalles.PensamientoCoherencia);
                    ParametroSP("@PensamientoNivelInteligencia", e_PerfilPsicologicoDetalles.PensamientoNivelInteligencia);
                    ParametroSP("@PensamientoExpresionVerbal", e_PerfilPsicologicoDetalles.PensamientoExpresionVerbal);
                    ParametroSP("@PensamientoCulturaGeneral", e_PerfilPsicologicoDetalles.PensamientoCulturaGeneral);
                    ParametroSP("@ActitudesSocioPolitico", e_PerfilPsicologicoDetalles.ActitudesSocioPolitico);
                    ParametroSP("@ActitudesImagenDeSiMismo", e_PerfilPsicologicoDetalles.ActitudesImagenDeSiMismo);
                    ParametroSP("@ActitudesFrenteAlEjercicio", e_PerfilPsicologicoDetalles.ActitudesFrenteAlEjercicio);
                    ParametroSP("@ActitudesObservacionesAdicionales", e_PerfilPsicologicoDetalles.ActitudesObservacionesAdicionales);
                    ParametroSP("@EstadoId", e_PerfilPsicologicoDetalles.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PerfilPsicologicoDetalles.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologicoDetalles.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public int Actualizar(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesActualizar", connection);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PerfilPsicologicoDetalles.PerfilPsicologicoDetallesId);
                    ParametroSP("@PerfilPsicologico1005Id", e_PerfilPsicologicoDetalles.PerfilPsicologico1005Id);
                    ParametroSP("@FisicaEdad", e_PerfilPsicologicoDetalles.FisicaEdad);
                    ParametroSP("@FisicaTalla", e_PerfilPsicologicoDetalles.FisicaTalla);
                    ParametroSP("@FisicaPeso", e_PerfilPsicologicoDetalles.FisicaPeso);
                    ParametroSP("@ContexturaId", e_PerfilPsicologicoDetalles.ContexturaId);
                    ParametroSP("@Fisicaaspectoscronico", e_PerfilPsicologicoDetalles.Fisicaaspectoscronico);
                    ParametroSP("@AparienciaExpresionRostro", e_PerfilPsicologicoDetalles.AparienciaExpresionRostro);
                    ParametroSP("@AparienciaVestido", e_PerfilPsicologicoDetalles.AparienciaVestido);
                    ParametroSP("@AparienciaModales", e_PerfilPsicologicoDetalles.AparienciaModales);
                    ParametroSP("@PensamientoCapacidad", e_PerfilPsicologicoDetalles.PensamientoCapacidad);
                    ParametroSP("@PensamientoCoherencia", e_PerfilPsicologicoDetalles.PensamientoCoherencia);
                    ParametroSP("@PensamientoNivelInteligencia", e_PerfilPsicologicoDetalles.PensamientoNivelInteligencia);
                    ParametroSP("@PensamientoExpresionVerbal", e_PerfilPsicologicoDetalles.PensamientoExpresionVerbal);
                    ParametroSP("@PensamientoCulturaGeneral", e_PerfilPsicologicoDetalles.PensamientoCulturaGeneral);
                    ParametroSP("@ActitudesSocioPolitico", e_PerfilPsicologicoDetalles.ActitudesSocioPolitico);
                    ParametroSP("@ActitudesImagenDeSiMismo", e_PerfilPsicologicoDetalles.ActitudesImagenDeSiMismo);
                    ParametroSP("@ActitudesFrenteAlEjercicio", e_PerfilPsicologicoDetalles.ActitudesFrenteAlEjercicio);
                    ParametroSP("@ActitudesObservacionesAdicionales", e_PerfilPsicologicoDetalles.ActitudesObservacionesAdicionales);
                    ParametroSP("@EstadoId", e_PerfilPsicologicoDetalles.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilPsicologicoDetalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologicoDetalles.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public int Anular(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesAnular", connection);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PerfilPsicologicoDetalles.PerfilPsicologicoDetallesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilPsicologicoDetalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologicoDetalles.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public List<PerfilPsicologicoDetallesBE> Consultar_Lista()
        {
            List<PerfilPsicologicoDetallesBE> lista = new List<PerfilPsicologicoDetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilPsicologicoDetallesBE(reader));
                        }
                    }
                    return lista;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public List<PerfilPsicologicoDetallesBE> Consultar_PK(
                int m_PerfilPsicologicoDetallesId)
        {
            List<PerfilPsicologicoDetallesBE> lista = new List<PerfilPsicologicoDetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesConsultar_PK", connection);
                    ParametroSP("@PerfilPsicologicoDetallesId", m_PerfilPsicologicoDetallesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilPsicologicoDetallesBE(reader));
                        }
                    }
                    return lista;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologicoDetallesGetMaxId", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        if (!DBNull.Value.Equals(reader["CodigoMaxId"]))
                            {
                             maxId = Convert.ToInt32(reader["CodigoMaxId"]);
                            }
                        }
                }
            }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
            return maxId;
        }

    }
}


