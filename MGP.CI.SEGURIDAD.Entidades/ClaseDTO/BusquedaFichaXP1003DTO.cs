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

    public partial class BusquedaFichaXP1003DTO : BaseBE
    {
        #region Propiedades
        [DataMember]
        public int Ficha1003Id { get; set; }
        [DataMember]
        public int DatosPersonalesId { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        #endregion

        #region Constructores
        public BusquedaFichaXP1003DTO() { }

        public BusquedaFichaXP1003DTO(
            int m_Ficha1003Id,
            int m_DatosPersonalesId,
            DateTime? m_FechaRegistro
)
        {
            Ficha1003Id = m_Ficha1003Id;
            DatosPersonalesId = m_DatosPersonalesId;
            FechaRegistro = m_FechaRegistro;
        }

        public BusquedaFichaXP1003DTO(IDataReader Registro)
        {
            Ficha1003Id = ValidarInt(Registro["FichaId"]);
            DatosPersonalesId = ValidarInt(Registro["DatosPersonalesId"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            
        }

        #endregion



    }
}
