using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CursosRealizadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CursosRealizados";
        [DataMember]
        public int CursosRealizadosId { get; set; }
        [DataMember]
        public int InformacionCastrenseId { get; set; }

        [DataMember]
        public int PaisId { get; set; }
        [DataMember]
        public int InstitucionMilitaresExtranjerasId { get; set; }
        [DataMember]
        public int EscuelaExtranjeraId { get; set; }
        [DataMember]
        public int CursoEscuelaExtranjeraId { get; set; }
        [DataMember]
        public int? Ano { get; set; }

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
        public CursosRealizadosBE() { }

        public CursosRealizadosBE(
            int m_CursosRealizadosId,
            int m_CursoEscuelaExtranjeraId,
            int m_InformacionCastrenseId,
            int m_PaisId,
             int m_InstitucionMilitaresExtranjerasId,
                int m_EscuelaExtranjeraId,
                      int m_Ano,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CursosRealizadosId = m_CursosRealizadosId;
            CursoEscuelaExtranjeraId = m_CursoEscuelaExtranjeraId;
            InformacionCastrenseId = m_InformacionCastrenseId;
            PaisId = m_PaisId;
            InstitucionMilitaresExtranjerasId = m_InstitucionMilitaresExtranjerasId;
            EscuelaExtranjeraId = m_EscuelaExtranjeraId;
            Ano = m_Ano;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CursosRealizadosBE(IDataReader Registro)
        {
            CursosRealizadosId = ValidarInt(Registro["CursosRealizadosId"]);
            CursoEscuelaExtranjeraId = ValidarInt(Registro["CursoEscuelaExtranjeraId"]);
            InformacionCastrenseId = ValidarInt(Registro["InformacionCastrenseId"]);

            PaisId = ValidarInt(Registro["PaisId"]);
            InstitucionMilitaresExtranjerasId = ValidarInt(Registro["InstitucionMilitaresExtranjerasId"]);
            EscuelaExtranjeraId = ValidarInt(Registro["EscuelaExtranjeraId"]);
            Ano = ValidarInt(Registro["Ano"]);

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
