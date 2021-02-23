using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class UbigeoBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Ubigeo";
        [DataMember]
        public int UbigeoId { get; set; }
        [DataMember]
        public string UbigeoCodigo { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }
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
        public UbigeoBE() { }

        public UbigeoBE(
            int m_UbigeoId,
            string m_UbigeoCodigo,
            string m_Departamento,
            string m_Provincia,
            string m_Distrito,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            UbigeoId = m_UbigeoId;
            UbigeoCodigo = m_UbigeoCodigo;
            Departamento = m_Departamento;
            Provincia = m_Provincia;
            Distrito = m_Distrito;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public UbigeoBE(IDataReader Registro)
        {
            UbigeoId = ValidarInt(Registro["UbigeoId"]);
            UbigeoCodigo = ValidarString(Registro["UbigeoCodigo"]);
            Departamento = ValidarString(Registro["Departamento"]);
            Provincia = ValidarString(Registro["Provincia"]);
            Distrito = ValidarString(Registro["Distrito"]);
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
