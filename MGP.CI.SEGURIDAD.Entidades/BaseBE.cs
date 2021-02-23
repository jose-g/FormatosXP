using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Web;

namespace MGP.CI.SEGURIDAD.Entidades
{ 
    [Serializable]
    public class BaseBE
    {
        #region Propiedades Base
        public CultureInfo culture = new CultureInfo("es-PE");
        [DataMember]
        public string Row_New { get; set; }//manejo de registros nuevos
        [DataMember]
        public string Row_Color { get; set; }//manejo de colores para una grilla
        [DataMember]
        public int Row_Count { get; set; }//manejo de cantidad
        #endregion
        #region Validacion de Booleanos
        protected internal Boolean ValidarBoolean(Object valor)
        {
            Boolean vRespuesta = false;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Boolean)valor; }
            return vRespuesta;
        }
        protected internal bool ValidarBool(Object valor)
        {
            bool vRespuesta = false;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (bool)valor; }
            return vRespuesta;
        }
        #endregion
        #region Validacion de Cadenas
        protected internal string ValidarString(Object valor)
        {
            string vRespuesta = null;// string.Empty;
            if (!DBNull.Value.Equals(valor)) {
                
                vRespuesta = (string)Convert.ToString(valor).Trim();
//                vRespuesta = vRespuesta.Replace("\"", "").Replace("\\", "").Trim();

//                vRespuesta = vRespuesta.Replace(@"\", @"\");
////                vRespuesta = vRespuesta.Replace("\\", "\");
            }
            return vRespuesta;
        }
        #endregion
        #region Validacion de Enteros
        protected internal int ValidarInt(Object valor)
        {
            int vRespuesta = 0;
            if (!DBNull.Value.Equals(valor))
            {
                vRespuesta = (int)valor;
            }
            return vRespuesta;
        }    
        protected internal Int16 ValidarInt16(Object valor)
        {
            Int16 vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int16)valor; }
            return vRespuesta;
        }
        protected internal Int32 ValidarInt32(Object valor)
        {
            Int32 vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int32)valor; }
            return vRespuesta;
        }
        protected internal Int64 ValidarInt64(Object valor)
        {
            Int64 vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int64)valor; }
            return vRespuesta;
        }
        protected internal Int16 ValidarShort(Object valor)
        {
            short vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int16)valor; }
            return vRespuesta;
        }
        protected internal Int64 ValidarLong(Object valor)
        {
            long vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int64)valor; }
            return vRespuesta;
        }
        //validacion con nulos
        protected internal int? ValidarIntNulos(Object valor)
        {
            int? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (int)valor; }
            return vRespuesta;
        }
        protected internal Int16? ValidarInt16Nulos(Object valor)
        {
            Int16? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int16)valor; }
            return vRespuesta;
        }
        protected internal Int32? ValidarInt32Nulos(Object valor)
        {
            Int32? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int32)valor; }
            return vRespuesta;
        }
        protected internal Int64? ValidarInt64Nulos(Object valor)
        {
            Int64? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int64)valor; }
            return vRespuesta;
        }
        protected internal Int16? ValidarShortNulos(Object valor)
        {
            short? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int16)valor; }
            return vRespuesta;
        }
        protected internal Int64? ValidarLongNulos(Object valor)
        {
            long? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (Int64)valor; }
            return vRespuesta;
        }
        #endregion
        #region Validacion de Decimales
        protected internal double ValidarDouble(Object valor)
        {
            double vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = Convert.ToDouble(valor, culture); }
            return vRespuesta;
        }
        protected internal decimal ValidarDecimal(Object valor)
        {
            decimal vRespuesta = 0;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = Convert.ToDecimal(valor, culture); }
            return vRespuesta;
        }
        //validacion de nulos
        protected internal double? ValidarDoubleNulos(Object valor)
        {
            double? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = Convert.ToDouble(valor, culture); }
            return vRespuesta;
        }
        protected internal decimal? ValidarDecimalNulos(Object valor)
        {
            decimal? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = Convert.ToDecimal(valor, culture); }
            return vRespuesta;
        }
        #endregion
        #region Validacion de Fechas
        protected internal DateTime? ValidarDate(Object valor)
        {
            DateTime? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (DateTime)valor; }
            return vRespuesta;
        }
        protected internal DateTime? ValidarDateTime(Object valor)
        {
            DateTime? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (DateTime)valor; }
            return vRespuesta;
        }
        protected internal DateTime? ValidarSmallDateTime(Object valor)
        {
            DateTime? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (DateTime)valor; }
            return vRespuesta;
        }
        protected internal DateTime? ValidarDatetime(Object valor)
        {
            DateTime? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (DateTime)valor; }
            return vRespuesta;
        }
        protected internal DateTime? ValidarSmalldatetime(Object valor)
        {
            DateTime? vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (DateTime)valor; }
            return vRespuesta;
        }
        #endregion
        #region Validacion de Arreglos
        protected internal byte[] ValidarByte(Object valor)
        {
            byte[] vRespuesta = null;
            if (!DBNull.Value.Equals(valor)) { vRespuesta = (byte[])valor; }
            return vRespuesta;
        }
        #endregion

        #region Enumeradores
        public enum Enum_Tipo_Lista
        {
            Lista_PK,
            Lista_Todo,
            Lista_Filtro,
            Lista_Listar,
            lista_Seleccion
        }

        public enum Enum_Tipo_Operacion
        {
            Insertar,
            Actualizar,
            Eliminar,
            Consultar
        }
        #endregion
        #region Constantes
        //ESTADO DE REGISTRO
        public bool GC_ESTADO_ACTIVO = true;
        public bool GC_ESTADO_INACTIVO = false;
        public string GC_ESTADO_ACTIVO_DESCRIPCION = "Activo";
        public string GC_ESTADO_INACTIVO_DESCRIPCION = "Inactivo";
        //public string GC_FLAG_ACTIVO_DESCRIPCION = "Si";
        //public string GC_FLAG_INACTIVO_DESCRIPCION = "No";
        public string GC_CULTURE_FORMATO_FECHA = "dd/MM/yyyy";
        public string GC_CULTURE_FORMATO_HORA = "HH:mm:ss";

        #endregion

        /// <summary>
        /// Convierte el Objeto arreglo HttpPostedFileBase[] a byte[]
        /// </summary>
        /// <param name="File">arreglo de tipo HttpPostedFileBase</param>
        /// <returns>Devuelve un arreglo de tipo byte</returns>
        public byte[] ToBytes(HttpPostedFileBase[] File)
        {
            byte[] _ToBytes = null;
            using (var binaryReader = new BinaryReader(File[0].InputStream))
            {
                _ToBytes = binaryReader.ReadBytes(File[0].ContentLength);
            }
            return _ToBytes;
        }
        public byte[] ToBytes(string File)
        {
            string imageDataParsed = File.Substring(File.IndexOf(',') + 1);
            byte[] imageBytes = Convert.FromBase64String(imageDataParsed);
            var imageStream = new MemoryStream(imageBytes, false);
            return imageBytes;
        }
    }
}
