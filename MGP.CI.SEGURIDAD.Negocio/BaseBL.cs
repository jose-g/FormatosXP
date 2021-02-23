using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public class BaseBL
    {
        CultureInfo culture = new CultureInfo("es-PE");

        #region Enumeradores

        #endregion

        #region EventLog
        protected internal void RegistrarLogEventos(
            string sSource,
            string sEvent)
        {
            string m_RutaLog = ConfigurationManager.AppSettings["Ruta_Log"];
            DateTime dt = DateTime.Now;
            StreamWriter oSW = new StreamWriter(string.Concat(m_RutaLog, string.Format("Log_{0}.txt", dt.ToString("yyyyMMdd"))), true);
            // datos que se graban en el archivo log
            /* Codigo  : Codigo Generado en Base a Fecha Hora (se puede cambiar a otro)
             * Fecha   : Fecha y hora en formato es-PE (se puede cambiar a otro)
             * sSource : Origen
             * sEvent  : Descipcion del error
             */
            oSW.WriteLine(string.Format("{0}↔{1}↔{2}↔{3}", dt.ToString("yyyyMMddHHmmss"), dt.ToString("dd/MM/yyyy HH:mm:ss"), sSource, sEvent));
            oSW.Flush();
            oSW.Close();
        }
        #endregion
    }
}
