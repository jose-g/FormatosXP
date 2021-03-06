using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public class SessionManager
    {
        public static T Obtener<T>(string key)
        {
            try
            {
                object sessionObject = HttpContext.Current.Session[key];
                if (sessionObject == null)
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return (T)HttpContext.Current.Session[key];
        }

        public static T Get<T>(string key, T defaultValue)
        {
            object sessionObject = HttpContext.Current.Session[key];
            if (sessionObject == null)
            {
                HttpContext.Current.Session[key] = defaultValue;
            }

            return (T)HttpContext.Current.Session[key];
        }

        public static void Guardar<T>(string key, T entity)
        {
            try
            {
                HttpContext.Current.Session[key] = entity;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void Remove(string key)
        {
            try
            {
                HttpContext.Current.Session.Remove(key);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}