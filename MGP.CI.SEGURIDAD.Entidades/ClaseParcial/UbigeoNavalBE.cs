using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class UbigeoNavalBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "UbigeoNaval";
        [DataMember]
        public int UbigeoNavalId { get; set; }
        [DataMember]
        public int? ZonaNavalId { get; set; }
        [DataMember]
        public string ZonaNavalDescCorta { get; set; }
        [DataMember]
        public string ZonaNavalDescLarga { get; set; }
        [DataMember]
        public int? DependenciaId { get; set; }
        [DataMember]
        public string DependenciaDescCorta { get; set; }
        [DataMember]
        public string DependenciaDescLarga { get; set; }
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
        [DataMember]
        public int? EstadoId { get; set; }

        #endregion

        #region Constructores
        public UbigeoNavalBE() { }

        public UbigeoNavalBE(
            int m_UbigeoNavalId,
            int? m_ZonaNavalId,
            string m_ZonaNavalDescCorta,
            string m_ZonaNavalDescLarga,
            int? m_DependenciaId,
            string m_DependenciaDescCorta,
            string m_DependenciaDescLarga,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            int? m_EstadoId,
            string m_NroIpRegistro
        )
        {
            UbigeoNavalId = m_UbigeoNavalId;
            ZonaNavalId = m_ZonaNavalId;
            ZonaNavalDescCorta = m_ZonaNavalDescCorta;
            ZonaNavalDescLarga = m_ZonaNavalDescLarga;
            DependenciaId = m_DependenciaId;
            DependenciaDescCorta = m_DependenciaDescCorta;
            DependenciaDescLarga = m_DependenciaDescLarga;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
            EstadoId = m_EstadoId;
        }

        public UbigeoNavalBE(IDataReader Registro)
        {
            UbigeoNavalId = ValidarInt(Registro["UbigeoNavalId"]);
            ZonaNavalId = ValidarIntNulos(Registro["ZonaNavalId"]);
            ZonaNavalDescCorta = ValidarString(Registro["ZonaNavalDescCorta"]);
            ZonaNavalDescLarga = ValidarString(Registro["ZonaNavalDescLarga"]);
            DependenciaId = ValidarIntNulos(Registro["DependenciaId"]);
            DependenciaDescCorta = ValidarString(Registro["DependenciaDescCorta"]);
            DependenciaDescLarga = ValidarString(Registro["DependenciaDescLarga"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);

        }
        #endregion

    }
}
