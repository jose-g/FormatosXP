using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public class BaseDA
    {
        #region Conexion
        protected internal SqlCommand comando = null;
        protected internal SqlConnection Conectar()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connexion"].ToString());
        }

        protected internal SqlConnection Conectar(string m_BaseDatos)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connexion"].ToString());
        }
        protected internal void ComandoSP(string m_Procedimiento, SqlConnection conn)
        {
            conn.Open();
            comando = new SqlCommand(m_Procedimiento, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
        }
        protected internal void ParametroSP(string m_Parametro,
                                            object m_Valor)
        {
            SqlParameter m_SqlParametro = new SqlParameter();
            m_SqlParametro.ParameterName = m_Parametro;
            if (m_Valor != null) { m_Valor = m_Valor.GetType().Name.ToString().ToLower().Contains("string") ? m_Valor.ToString() : m_Valor; }
            m_SqlParametro.Value = m_Valor;
            comando.Parameters.Add(m_SqlParametro);
        }
        protected internal void ParametroSP(string m_Parametro,
                                            object m_Valor,
                                            ParameterDirection m_Direccion,
                                            SqlDbType m_TipoDato,
                                            int m_Size
                                            )
        {
            SqlParameter m_SqlParametro = new SqlParameter();
            m_SqlParametro.ParameterName = m_Parametro;
            m_SqlParametro.SqlDbType = m_TipoDato;
            m_SqlParametro.Size = m_Size;
            m_SqlParametro.Direction = m_Direccion;
            if (m_Valor != null) { m_Valor = m_Valor.GetType().Name.ToString().ToLower().Contains("string") ? m_Valor.ToString() : m_Valor; }
            if (m_Direccion != ParameterDirection.Output) { m_SqlParametro.Value = m_Valor; }
            comando.Parameters.Add(m_SqlParametro);
        }
        #endregion

        #region EventLog
        //protected internal void RegistrarLogEventos(
        //    string sSource,
        //    string sLog,
        //    string sEvent,
        //    EventLogEntryType sEventType)
        //{
        //    if (!EventLog.SourceExists(sSource))
        //    { EventLog.CreateEventSource(sSource, sLog); }

        //    EventLog.WriteEntry(sSource, sEvent, sEventType);
        //}

        //protected internal void RegistrarLogEventos(
        //    string sSource,
        //    string sEvent)
        //{
        //    DateTime dt = DateTime.Now;
        //    StreamWriter oSW = new StreamWriter(string.Format(@"C:\\inetpub\\wwwroot\\Retail_Log\\Log_{0}.txt", dt.ToString("yyyyMMdd")), true);
        //    string scomando = String.Empty;
        //    oSW.WriteLine(string.Format("{0}↔{1}↔{2}", dt.ToString("dd/MM/yyyy HH:mm:ss"), sSource, sEvent));
        //    oSW.Flush();
        //    oSW.Close();
        //}
        #endregion
    }
}
