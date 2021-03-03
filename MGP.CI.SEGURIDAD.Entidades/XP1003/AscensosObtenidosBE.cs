using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class AscensosObtenidosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "AscensosObtenidos";
        [DataMember]
        public int AscensosObtenidosId { get; set; }
        [DataMember]
        public int GradoExtranjeroId { get; set; }
        [DataMember]
        public int? InformacionCastrenseId { get; set; }
        [DataMember]
        public int? PaisId { get; set; }
        [DataMember]
        public int? InstitucionMilitarExtranjeroId { get; set; }
        public int? GradoExtranjeroAno { get; set; }
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
        public AscensosObtenidosBE() { }

        public AscensosObtenidosBE(
            int m_AscensosObtenidosId,
            int m_GradoExtranjeroId,
            int? m_InformacionCastrenseId,
            int? m_PaisId,
            int? m_InstitucionMilitarExtranjeroId,
            int? m_GradoExtranjeroAno,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            AscensosObtenidosId = m_AscensosObtenidosId;
            GradoExtranjeroId = m_GradoExtranjeroId;
            InformacionCastrenseId = m_InformacionCastrenseId;
            PaisId = m_PaisId;
            InstitucionMilitarExtranjeroId = m_InstitucionMilitarExtranjeroId;
            GradoExtranjeroAno = m_GradoExtranjeroAno;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public AscensosObtenidosBE(IDataReader Registro)
        {
            AscensosObtenidosId = ValidarInt(Registro["AscensosObtenidosId"]);
            GradoExtranjeroId = ValidarInt(Registro["GradoExtranjeroId"]);
            InformacionCastrenseId = ValidarIntNulos(Registro["InformacionCastrenseId"]);
            PaisId = ValidarIntNulos(Registro["PaisId"]);
            InstitucionMilitarExtranjeroId = ValidarIntNulos(Registro["InstitucionMilitarExtranjeroId"]);
            GradoExtranjeroAno = ValidarIntNulos(Registro["GradoExtranjeroAno"]);
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
