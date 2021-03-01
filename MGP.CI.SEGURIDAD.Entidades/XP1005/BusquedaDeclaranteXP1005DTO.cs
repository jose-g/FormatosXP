using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    public class BusquedaDeclaranteXP1005DTO : BaseBE
    {
        #region Propiedades
        [DataMember]
        public int DeclaranteId { get; set; }
        [DataMember]
        public string Paterno { get; set; }
        [DataMember]
        public string Materno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public int TipoDocumento { get; set; }
        [DataMember]
        public string NroDocumento { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        #endregion


        #region Constructores
        public BusquedaDeclaranteXP1005DTO() { }

        public BusquedaDeclaranteXP1005DTO(
            string m_Paterno,
            string m_Materno,
            string m_Nombres,
            int m_TipoDocumento,
            int m_DeclaranteId,
            string m_NroDocumento,
            DateTime? m_FechaRegistro
)
        {
            Paterno = m_Paterno;
            Materno = m_Materno;
            Nombres = m_Nombres;
            TipoDocumento = m_TipoDocumento;
            DeclaranteId = m_DeclaranteId;
            NroDocumento = m_NroDocumento;
            FechaRegistro = FechaRegistro;
        }

        public BusquedaDeclaranteXP1005DTO(IDataReader Registro)
        {
            Paterno = ValidarString(Registro["Paterno"]);
            Materno = ValidarString(Registro["Materno"]);
            Nombres = ValidarString(Registro["Nombres"]);
            DeclaranteId = ValidarInt(Registro["DeclaranteId"]);
        }

        #endregion
    }
}
