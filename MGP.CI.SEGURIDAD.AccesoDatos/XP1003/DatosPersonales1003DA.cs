using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DatosPersonales1003DA : BaseDA
    {
        const string Nombre_Clase = "DatosPersonales1003DA";
        private string m_BaseDatos = string.Empty;

        public DatosPersonales1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DatosPersonales1003DA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DatosPersonalesGetMaxId", connection);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!DBNull.Value.Equals(reader["CodigoMaxId"])) { maxId = Convert.ToInt32(reader["CodigoMaxId"]); }
                        }
                    }
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
            return maxId;
        }



        public int Insertar(DatosPersonales1003BE e_DatosPersonales1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Insertar", connection);
                    ParametroSP("@DatosPersonalesId", e_DatosPersonales1003.DatosPersonalesId);
                    ParametroSP("@FichaId", e_DatosPersonales1003.FichaId);
                    ParametroSP("@GradoExtranjeroId", e_DatosPersonales1003.GradoExtranjeroId);
                    ParametroSP("@EspecialidaId", e_DatosPersonales1003.EspecialidaIdExtranjeraId);
                    ParametroSP("@Paterno", e_DatosPersonales1003.Paterno);
                    ParametroSP("@Materno", e_DatosPersonales1003.Materno);
                    ParametroSP("@Nombres1", e_DatosPersonales1003.Nombres1);
                    ParametroSP("@Nombres2", e_DatosPersonales1003.Nombres2);
                    ParametroSP("@Nombres3", e_DatosPersonales1003.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosPersonales1003.NacionalidadId);
                    ParametroSP("@PaisId", e_DatosPersonales1003.PaisId);
                    ParametroSP("@PaisInstitucionId", e_DatosPersonales1003.PaisInstitucionId);
                    ParametroSP("@InstitucionMilitarExtranjeroId", e_DatosPersonales1003.InstitucionMilitarExtranjeroId);
                    ParametroSP("@EnfermedadTipoId", e_DatosPersonales1003.EnfermedadTipoId);
                    ParametroSP("@LugarNacimiento", e_DatosPersonales1003.LugarNacimiento);
                    ParametroSP("@FechaNamiento", e_DatosPersonales1003.FechaNamiento);
                    ParametroSP("@EstadoCivilId", e_DatosPersonales1003.EstadoCivilId);
                    ParametroSP("@GrupoSanguineoId", e_DatosPersonales1003.GrupoSanguineoId);
                    ParametroSP("@EnfermedadId", e_DatosPersonales1003.EnfermedadId);
                    ParametroSP("@EstadoId", e_DatosPersonales1003.EstadoId);
                    ParametroSP("@SexoId", e_DatosPersonales1003.SexoId);
                    ParametroSP("@EstadoDatosPersonales", e_DatosPersonales1003.EstadoDatosPersonales);
                    ParametroSP("@UsuarioRegistro", e_DatosPersonales1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosPersonales1003.NroIpRegistro);
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

        public int Actualizar(DatosPersonales1003BE e_DatosPersonales1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Actualizar", connection);
                    ParametroSP("@DatosPersonalesId", e_DatosPersonales1003.DatosPersonalesId);
                    ParametroSP("@FichaId", e_DatosPersonales1003.FichaId);
                    ParametroSP("@GradoExtranjeroId", e_DatosPersonales1003.GradoExtranjeroId);
                    ParametroSP("@EspecialidaId", e_DatosPersonales1003.EspecialidaIdExtranjeraId);
                    ParametroSP("@Paterno", e_DatosPersonales1003.Paterno);
                    ParametroSP("@Materno", e_DatosPersonales1003.Materno);
                    ParametroSP("@Nombres1", e_DatosPersonales1003.Nombres1);
                    ParametroSP("@Nombres2", e_DatosPersonales1003.Nombres2);
                    ParametroSP("@Nombres3", e_DatosPersonales1003.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosPersonales1003.NacionalidadId);
                    ParametroSP("@PaisId", e_DatosPersonales1003.PaisId);
                    ParametroSP("@LugarNacimiento", e_DatosPersonales1003.LugarNacimiento);
                    ParametroSP("@FechaNamiento", e_DatosPersonales1003.FechaNamiento);
                    ParametroSP("@EstadoCivilId", e_DatosPersonales1003.EstadoCivilId);
                    ParametroSP("@GrupoSanguineoId", e_DatosPersonales1003.GrupoSanguineoId);
                    ParametroSP("@EnfermedadId", e_DatosPersonales1003.EnfermedadId);
                    ParametroSP("@EstadoId", e_DatosPersonales1003.EstadoId);
                    ParametroSP("@SexoId", e_DatosPersonales1003.SexoId);
                    ParametroSP("@EstadoDatosPersonales", e_DatosPersonales1003.EstadoDatosPersonales);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosPersonales1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosPersonales1003.NroIpRegistro);
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

        public int Anular(DatosPersonales1003BE e_DatosPersonales1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Anular", connection);
                    ParametroSP("@DatosPersonalesId", e_DatosPersonales1003.DatosPersonalesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosPersonales1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosPersonales1003.NroIpRegistro);
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

        public List<DatosPersonales1003BE> Consultar_Lista()
        {
            List<DatosPersonales1003BE> lista = new List<DatosPersonales1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosPersonales1003BE(reader));
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

        public List<DatosPersonales1003BE> Consultar_PK(
                int m_DatosPersonalesId)
        {
            List<DatosPersonales1003BE> lista = new List<DatosPersonales1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Consultar_PK", connection);
                    ParametroSP("@DatosPersonalesId", m_DatosPersonalesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosPersonales1003BE(reader));
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
        public List<DatosPersonales1003BE> Consultar_FK(
        int m_FichaId)
        {
            List<DatosPersonales1003BE> lista = new List<DatosPersonales1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosPersonales1003Consultar_FK", connection);
                    ParametroSP("@FichaId", m_FichaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosPersonales1003BE(reader));
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
    }
}
