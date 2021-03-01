using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class PsicologicoRelacionesInterpersonalesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PsicologicoRelacionesInterpersonales";
        [DataMember]
        public int PsicologicoRelacionesInterpersonales { get; set; }
        [DataMember]
        public int PerfilPsicologicoDetallesId { get; set; }
        [DataMember]
        public int NivelesNumericosId { get; set; }
        [DataMember]
        public int RelacionesInterpersonalesId { get; set; }
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
        public PsicologicoRelacionesInterpersonalesBE() { }

        public PsicologicoRelacionesInterpersonalesBE(
            int m_PsicologicoRelacionesInterpersonales,
            int m_PerfilPsicologicoDetallesId,
            int m_NivelesNumericosId,
            int m_RelacionesInterpersonalesId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PsicologicoRelacionesInterpersonales = m_PsicologicoRelacionesInterpersonales;
            PerfilPsicologicoDetallesId = m_PerfilPsicologicoDetallesId;
            NivelesNumericosId = m_NivelesNumericosId;
            RelacionesInterpersonalesId = m_RelacionesInterpersonalesId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PsicologicoRelacionesInterpersonalesBE(IDataReader Registro)
        {
            PsicologicoRelacionesInterpersonales = ValidarInt(Registro["PsicologicoRelacionesInterpersonales"]);
            PerfilPsicologicoDetallesId = ValidarInt(Registro["PerfilPsicologicoDetallesId"]);
            NivelesNumericosId = ValidarInt(Registro["NivelesNumericosId"]);
            RelacionesInterpersonalesId = ValidarInt(Registro["RelacionesInterpersonalesId"]);
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
