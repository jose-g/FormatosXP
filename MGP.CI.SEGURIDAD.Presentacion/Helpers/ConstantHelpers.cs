using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public class ConstantHelpers
    {
        public static readonly Int32 DEFAULT_PAGE_SIZE = 10;
        public static readonly String RUTA_BASE_SERVICIOS = ConfigurationManager.AppSettings["RutaBaseServicios"];

        public class enum_PERMISOS {
            public static readonly Int32 NUEVO=1;
            public static readonly Int32 MODIFICAR = 2;
            public static readonly Int32 ELIMINAR = 3;
            public static readonly Int32 CONSULTAR = 4;
            public static readonly Int32 REPORTE = 5;
        }

        public class ESTADO
        {
            public static readonly String ACTIVO = "ACT";
            public static readonly String BLOQUEADO = "BLO";
            public static readonly String INACTIVO = "INA";
            public static readonly Int32 ACT = 1;
            public static readonly Int32 BLO = 2;
            public static readonly Int32 INA = 3;

        }
        public class SEXO
        {
            public static readonly String Masculino = "M";
            public static readonly String Femenino = "F";
        }

        public static class RESPONSE
        {
            public static class DESCRIPCION
            {
                public static readonly String OK = "Los datos se guardaron exitosamente";
                public static readonly String INTERNAL_SERVER_ERROR = "Sucedió un error al guardar los datos, intente más tarde";

            }
            public static class STATUS_CODE
            {
                public static readonly Int32 OK = 200;
                public static readonly Int32 INTERNAL_SERVER_ERROR = 500;
            }

        }
        
        public static class EntidadExterna
        {
            public static readonly String NADA = "404";
        }

        public static class MESSAGE_TYPE
        {
            public static readonly String SUCCESS = "success";
            public static readonly String INFO = "info";
            public static readonly String DANGER = "danger";
            public static readonly String WARNING = "warrning";
        }

        public static class GLOBAL_VARIABLES
        {
            public static readonly Int32 EntidadExternaNada = 1;
        }

        public static String GET_URL_SERVICIOS(String Action, String Controller)
        {

            return String.Format("{0}/{1}/{2}", RUTA_BASE_SERVICIOS, Controller, Action);
        }
    }
}