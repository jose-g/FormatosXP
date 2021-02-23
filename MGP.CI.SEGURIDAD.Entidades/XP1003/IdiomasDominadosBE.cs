using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class IdiomasDominadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "IdiomasDominados";
        [DataMember]
        public int IdiomasDominadosId { get; set; }
        [DataMember]
        public int IdiomaId { get; set; }
        [DataMember]
        public int? Hablado { get; set; }
        [DataMember]
        public int? Escrito { get; set; }
        [DataMember]
        public int? Leido { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int InformacionCastrenseId { get; set; }
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
        public IdiomasDominadosBE() { }

        public IdiomasDominadosBE(
            int m_IdiomasDominadosId,
            int m_IdiomaId,
            int? m_Hablado,
            int? m_Escrito,
            int? m_Leido,
            int? m_EstadoId,
            int m_InformacionCastrenseId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            IdiomasDominadosId = m_IdiomasDominadosId;
            IdiomaId = m_IdiomaId;
            Hablado = m_Hablado;
            Escrito = m_Escrito;
            Leido = m_Leido;
            EstadoId = m_EstadoId;
            InformacionCastrenseId = m_InformacionCastrenseId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public IdiomasDominadosBE(IDataReader Registro)
        {
            IdiomasDominadosId = ValidarInt(Registro["IdiomasDominadosId"]);
            IdiomaId = ValidarInt(Registro["IdiomaId"]);
            Hablado = ValidarIntNulos(Registro["Hablado"]);
            Escrito = ValidarIntNulos(Registro["Escrito"]);
            Leido = ValidarIntNulos(Registro["Leido"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            InformacionCastrenseId = ValidarInt(Registro["InformacionCastrenseId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
