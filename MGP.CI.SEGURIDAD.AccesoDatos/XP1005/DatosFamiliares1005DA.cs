using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DatosFamiliares1005DA : BaseDA
    {
        const string Nombre_Clase = "DatosFamiliares1005DA";
        private string m_BaseDatos = string.Empty;

        public DatosFamiliares1005DA() {  }

        public int Insertar(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1005Insertar", connection);
                    ParametroSP("@DatosFamiliares1005Id", e_DatosFamiliares1005.DatosFamiliares1005Id);
                    ParametroSP("@DatosGeneralesId", e_DatosFamiliares1005.DatosGeneralesId);
                    ParametroSP("@ParentescoId", e_DatosFamiliares1005.ParentescoId);
                    ParametroSP("@Paterno", e_DatosFamiliares1005.Paterno);
                    ParametroSP("@Materno", e_DatosFamiliares1005.Materno);
                    ParametroSP("@Nombres1", e_DatosFamiliares1005.Nombres1);
                    ParametroSP("@Nombres2", e_DatosFamiliares1005.Nombres2);
                    ParametroSP("@Nombres3", e_DatosFamiliares1005.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosFamiliares1005.NacionalidadId);
                    ParametroSP("@FechaNamiento", e_DatosFamiliares1005.FechaNamiento);
                    ParametroSP("@PaisId", e_DatosFamiliares1005.PaisId);
                    ParametroSP("@LugarNacimiento", e_DatosFamiliares1005.LugarNacimiento);
                    ParametroSP("@GrupoSanguineoId", e_DatosFamiliares1005.GrupoSanguineoId);
                    ParametroSP("@Enfermedades", e_DatosFamiliares1005.Enfermedades);
                    ParametroSP("@Alergias", e_DatosFamiliares1005.Alergias);
                    ParametroSP("@ProfesionId", e_DatosFamiliares1005.ProfesionId);
                    ParametroSP("@Actividades", e_DatosFamiliares1005.Actividades);
                    ParametroSP("@check1005", e_DatosFamiliares1005.check1005);
                    ParametroSP("@Registrado1005", e_DatosFamiliares1005.Registrado1005);
                    ParametroSP("@EstadoId", e_DatosFamiliares1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DatosFamiliares1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1005.NroIpRegistro);
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

        public int Actualizar(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1005Actualizar", connection);
                    ParametroSP("@DatosFamiliares1005Id", e_DatosFamiliares1005.DatosFamiliares1005Id);
                    ParametroSP("@DatosGeneralesId", e_DatosFamiliares1005.DatosGeneralesId);
                    ParametroSP("@ParentescoId", e_DatosFamiliares1005.ParentescoId);
                    ParametroSP("@Paterno", e_DatosFamiliares1005.Paterno);
                    ParametroSP("@Materno", e_DatosFamiliares1005.Materno);
                    ParametroSP("@Nombres1", e_DatosFamiliares1005.Nombres1);
                    ParametroSP("@Nombres2", e_DatosFamiliares1005.Nombres2);
                    ParametroSP("@Nombres3", e_DatosFamiliares1005.Nombres3);
                    ParametroSP("@NacionalidadId", e_DatosFamiliares1005.NacionalidadId);
                    ParametroSP("@FechaNamiento", e_DatosFamiliares1005.FechaNamiento);
                    ParametroSP("@PaisId", e_DatosFamiliares1005.PaisId);
                    ParametroSP("@LugarNacimiento", e_DatosFamiliares1005.LugarNacimiento);
                    ParametroSP("@GrupoSanguineoId", e_DatosFamiliares1005.GrupoSanguineoId);
                    ParametroSP("@Enfermedades", e_DatosFamiliares1005.Enfermedades);
                    ParametroSP("@Alergias", e_DatosFamiliares1005.Alergias);
                    ParametroSP("@ProfesionId", e_DatosFamiliares1005.ProfesionId);
                    ParametroSP("@Actividades", e_DatosFamiliares1005.Actividades);
                    ParametroSP("@check1005", e_DatosFamiliares1005.check1005);
                    ParametroSP("@Registrado1005", e_DatosFamiliares1005.Registrado1005);
                    ParametroSP("@EstadoId", e_DatosFamiliares1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosFamiliares1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1005.NroIpRegistro);
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

        public int Anular(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1005Anular", connection);
                    ParametroSP("@DatosFamiliares1005Id", e_DatosFamiliares1005.DatosFamiliares1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosFamiliares1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosFamiliares1005.NroIpRegistro);
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

        public List<DatosFamiliares1005BE> Consultar_Lista()
        {
            List<DatosFamiliares1005BE> lista = new List<DatosFamiliares1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosFamiliares1005BE(reader));
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

        public List<DatosFamiliares1005BE> Consultar_PK(
                int m_DatosFamiliares1005Id)
        {
            List<DatosFamiliares1005BE> lista = new List<DatosFamiliares1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosFamiliares1005Consultar_PK", connection);
                    ParametroSP("@DatosFamiliares1005Id", m_DatosFamiliares1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosFamiliares1005BE(reader));
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
                    ComandoSP("usp_DatosFamiliares1005GetMaxId", connection);
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


