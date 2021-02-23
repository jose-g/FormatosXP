using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades.ClaseDTO
{
    [DataContract]
    [Serializable]

    public partial class BusquedaDeclaranteXP1003DTO : BaseBE
    {
        #region Propiedades

        [DataMember]
        public string Paterno { get; set; }
        [DataMember]
        public string Materno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public int Ficha1003Id { get; set; }
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        #endregion

        #region Constructores
        public BusquedaDeclaranteXP1003DTO() { }

        public BusquedaDeclaranteXP1003DTO(
            string m_Paterno,
            string m_Materno,
            string m_Nombres,
            int m_TipoDocumento,
            int m_Ficha1003Id,
            string m_NroDocumento,
            DateTime? m_FechaRegistro
)
        {
            Paterno = m_Paterno;
            Materno = m_Materno;
            Nombres = m_Nombres;
            TipoDocumento = m_TipoDocumento;
            Ficha1003Id = m_Ficha1003Id;
            NroDocumento = m_NroDocumento;
            FechaRegistro = FechaRegistro;
        }

        public BusquedaDeclaranteXP1003DTO(IDataReader Registro)
        {
            Paterno = ValidarString(Registro["Paterno"]);
            Materno = ValidarString(Registro["Materno"]);
            Nombres = ValidarString(Registro["Nombres"]);
            Ficha1003Id = ValidarInt(Registro["Ficha1003Id"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            TipoDocumento = ValidarInt(Registro["DocumentoIdentidadTipoId"]);
            NroDocumento = ValidarString(Registro["DeclaranteNumeroDocumento"]);
        }

        #endregion



    }
}
