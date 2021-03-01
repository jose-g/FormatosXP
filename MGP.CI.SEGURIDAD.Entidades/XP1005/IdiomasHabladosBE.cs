using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class IdiomasHabladosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "IdiomasHablados";
        [DataMember]
        public int IdiomasHabladosId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int IdiomaId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public string UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public string UsuarioModificacionRegistro { get; set; }
        [DataMember]
        public DateTime? FechaModificacionRegistro { get; set; }
        [DataMember]
        public string NroIpRegistro { get; set; }
        #endregion

        #region Constructores
        public IdiomasHabladosBE() { }

        public IdiomasHabladosBE(
            int m_IdiomasHabladosId,
            int m_DatosGeneralesId,
            int m_IdiomaId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            IdiomasHabladosId = m_IdiomasHabladosId;
            DatosGeneralesId = m_DatosGeneralesId;
            IdiomaId = m_IdiomaId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public IdiomasHabladosBE(IDataReader Registro)
        {
            IdiomasHabladosId = ValidarInt(Registro["IdiomasHabladosId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            IdiomaId = ValidarInt(Registro["IdiomaId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
