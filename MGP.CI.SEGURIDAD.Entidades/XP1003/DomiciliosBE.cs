using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class DomiciliosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Domicilios";
        [DataMember]
        public int DomicilioId { get; set; }
        [DataMember]
        public int CargosFuncionesX1003Id { get; set; }
        [DataMember]
        public int UbigeoId { get; set; }
        [DataMember]
        public string LugardeResidencia { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
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
        public DomiciliosBE() { }

        public DomiciliosBE(
            int m_DomicilioId,
            int m_CargosFuncionesX1003Id,
            int m_UbigeoId,
            string m_LugardeResidencia,
            string m_Referencia,
            string m_Telefono,
            string m_Email,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DomicilioId = m_DomicilioId;
            CargosFuncionesX1003Id = m_CargosFuncionesX1003Id;
            UbigeoId = m_UbigeoId;
            LugardeResidencia = m_LugardeResidencia;
            Referencia = m_Referencia;
            Telefono = m_Telefono;
            Email = m_Email;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DomiciliosBE(IDataReader Registro)
        {
            DomicilioId = ValidarInt(Registro["DomicilioId"]);
            CargosFuncionesX1003Id = ValidarInt(Registro["CargosFuncionesX1003Id"]);
            UbigeoId = ValidarInt(Registro["UbigeoId"]);
            LugardeResidencia = ValidarString(Registro["LugardeResidencia"]);
            Referencia = ValidarString(Registro["Referencia"]);
            Telefono = ValidarString(Registro["Telefono"]);
            Email = ValidarString(Registro["Email"]);
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
