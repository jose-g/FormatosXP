using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public class ServiceHelpers
    {
        /// <summary>
        /// Funcion que permite realizar el consumo del servicio web, ingresando solo el controlador y la acción
        /// </summary>
        /// <typeparam name="T">Tipo de Dato que vas a querer que retorne</typeparam>
        /// <param name="Action">Nombre de la acción</param>
        /// <param name="Controller">Nombre del Controlador</param>
        /// <returns></returns>
        public static T GetData<T>(String Action, String Controller)
        {
            return GetData<T>(Action, Controller, null);
        }

        /// <summary>
        /// Funcion que permite realizar el consumo del servicio web, ingresando solo el controlador y la acción
        /// </summary>
        /// <typeparam name="T">Tipo de Dato que vas a querer que retorne</typeparam>
        /// <param name="Action">Nombre de la acción</param>
        /// <param name="Controller">Nombre del Controlador</param>
        /// <param name="ParametrosValores">Parametros y valores que vas a enviar al servicio, dividido por '_' EJ: Parametro1_Valor1, Parametro2_Valor2 </param>
        /// <returns></returns>
        public static T GetData<T>(String Action, String Controller, params String[] ParametrosValores)
        {
            try
            {
                var RutaBaseServicio = String.Format("{0}/{1}/{2}", ConstantHelpers.RUTA_BASE_SERVICIOS, Controller, Action);
                var cont = 0;
                if (ParametrosValores != null)
                {
                    RutaBaseServicio = String.Format("{0}?", RutaBaseServicio);
                    foreach (var item in ParametrosValores)
                    {
                        var paramValue = item.Split('_');

                        if (cont >= 1)
                            RutaBaseServicio += "&";
                        RutaBaseServicio += paramValue[0] + '=' + paramValue[1];
                        cont++;
                    }
                }

                var client = new HttpClient();
                var result = default(T);
                var URI = new Uri(RutaBaseServicio);

                client.BaseAddress = URI;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(URI).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = (T)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, typeof(T));

                }

                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion que permite realizar el consumo del servicio web, ingresando solo el controlador y la acción
        /// </summary>
        /// <typeparam name="T">Tipo de Dato que vas a querer que retorne</typeparam>
        /// <param name="Action">Nombre de la acción</param>
        /// <param name="Controller">Nombre del Controlador</param>
        /// <param name="Objeto">Objeto que se va a enviar por el servicio</param>
        /// <returns></returns>
        //public static T PostData<T>(String Action, String Controller, object Objeto)
        //{
        //    try
        //    {
        //        var result = default(T);
        //        var RutaBaseServicio = String.Format("{0}/{1}/{2}", ConstantHelpers.RUTA_BASE_SERVICIOS, Controller, Action);
        //        var client = new HttpClient();
        //        var URI = new Uri(RutaBaseServicio);

        //        client.BaseAddress = URI;
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = client.PostAsJsonAsync(URI, Objeto).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            result = (T)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, typeof(T));

        //        }

        //        return (T)Convert.ChangeType(result, typeof(T));
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}
    }
}