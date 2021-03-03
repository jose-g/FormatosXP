using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DatosFamiliares1003DA : BaseDA
    {
        const string Nombre_Clase = "DatosFamiliares1003DA";
        private string m_BaseDatos = string.Empty;

        public DatosFamiliares1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DatosFamiliares1003DA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DatosFamiliaresGetMaxId", connection);


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

        public int Insertar(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Insertar", connection);
                    ParametroSP("@FamiliarId", e_DatosFamiliares1003.FamiliarId);
                    ParametroSP("@DatosPersonalesId", e_DatosFamiliares1003.DatosPersonalesId);
                    ParametroSP("@ParentescoId", e_DatosFamiliares1003.ParentescoId);
                    ParametroSP("@Paterno", e_DatosFamiliares1003.Paterno);
                    ParametroSP("@Materno", e_DatosFamiliares1003.Materno);
                    ParametroSP("@Nombres1", e_DatosFamiliares1003.Nombres1);
                    ParametroSP("@Nombres2", e_DatosFamiliares1003.Nombres2);
                    ParametroSP("@Nombres3", e_DatosFamiliares1003.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosFamiliares1003.NacionalidadId);
                    ParametroSP("@FechaNamiento", e_DatosFamiliares1003.FechaNamiento);
                    ParametroSP("@PaisId", e_DatosFamiliares1003.PaisId);
                    ParametroSP("@LugarNacimiento", e_DatosFamiliares1003.LugarNacimiento);
                    ParametroSP("@GrupoSanguineoId", e_DatosFamiliares1003.GrupoSanguineoId);
                    ParametroSP("@EnfermedadTipoId", e_DatosFamiliares1003.EnfermedadTipoId);
                    ParametroSP("@EnfermedadId", e_DatosFamiliares1003.EnfermedadId);
                    ParametroSP("@ProfesionId", e_DatosFamiliares1003.ProfesionId);
                    ParametroSP("@Actividades", e_DatosFamiliares1003.Actividades);
                    ParametroSP("@EstadoId", e_DatosFamiliares1003.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DatosFamiliares1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1003.NroIpRegistro);
                    ParametroSP("@EsResidente", e_DatosFamiliares1003.EsResidente);
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

        public int Actualizar(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Actualizar", connection);
                    ParametroSP("@FamiliarId", e_DatosFamiliares1003.FamiliarId);
                    ParametroSP("@DatosPersonalesId", e_DatosFamiliares1003.DatosPersonalesId);
                    ParametroSP("@ParentescoId", e_DatosFamiliares1003.ParentescoId);
                    ParametroSP("@Paterno", e_DatosFamiliares1003.Paterno);
                    ParametroSP("@Materno", e_DatosFamiliares1003.Materno);
                    ParametroSP("@Nombres1", e_DatosFamiliares1003.Nombres1);
                    ParametroSP("@Nombres2", e_DatosFamiliares1003.Nombres2);
                    ParametroSP("@Nombres3", e_DatosFamiliares1003.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosFamiliares1003.NacionalidadId);
                    ParametroSP("@FechaNamiento", e_DatosFamiliares1003.FechaNamiento);
                    ParametroSP("@PaisId", e_DatosFamiliares1003.PaisId);
                    ParametroSP("@LugarNacimiento", e_DatosFamiliares1003.LugarNacimiento);
                    ParametroSP("@GrupoSanguineoId", e_DatosFamiliares1003.GrupoSanguineoId);
                    ParametroSP("@EnfermedadTipoId", e_DatosFamiliares1003.EnfermedadTipoId);
                    ParametroSP("@EnfermedadId", e_DatosFamiliares1003.EnfermedadId);
                    ParametroSP("@ProfesionId", e_DatosFamiliares1003.ProfesionId);
                    ParametroSP("@Actividades", e_DatosFamiliares1003.Actividades);
                    ParametroSP("@EstadoId", e_DatosFamiliares1003.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosFamiliares1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1003.NroIpRegistro);
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

        public int Anular(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Anular", connection);
                    ParametroSP("@FamiliarId", e_DatosFamiliares1003.FamiliarId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosFamiliares1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1003.NroIpRegistro);
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

        public List<DatosFamiliares1003BE> Consultar_Lista()
        {
            List<DatosFamiliares1003BE> lista = new List<DatosFamiliares1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosFamiliares1003BE(reader));
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

        public List<DatosFamiliares1003BE> Consultar_PK(int m_FamiliarId)
        {
            List<DatosFamiliares1003BE> lista = new List<DatosFamiliares1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Consultar_PK", connection);
                    ParametroSP("@FamiliarId", m_FamiliarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosFamiliares1003BE(reader));
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
        public List<DatosFamiliares1003BE> Consultar_FK(int m_DatosPersonalesId)
        {
            List<DatosFamiliares1003BE> lista = new List<DatosFamiliares1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1003Consultar_FK", connection);
                    ParametroSP("@DatosPersonalesId", m_DatosPersonalesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosFamiliares1003BE(reader));
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
