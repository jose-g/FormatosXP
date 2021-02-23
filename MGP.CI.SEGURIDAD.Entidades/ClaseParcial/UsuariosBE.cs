using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class UsuariosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Usuarios";
        [DataMember]
        public int UsuarioId { get; set; }
        //[DataMember]
        public int TipoUsuarioId { get; set; }

        //[DataMember]
        public int? CIP{ get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PasswordOld { get; set; }
        [DataMember]
        public bool ResetPassword { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public int? DocumentoIdentidadId { get; set; }
        [DataMember]
        public string NumeroDoc { get; set; }
        [DataMember]
        public DateTime? FechaNacimiento { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string DocReferencia { get; set; }
        [DataMember]
        public short? CargoTipoId { get; set; }
        [DataMember]
        public string Cargo { get; set; }
        [DataMember]
        public DateTime? FinVigencia { get; set; }
        [DataMember]
        public DateTime? FechaUltimoLogueo { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int? UbigeoNavalId { get; set; }

        [DataMember]
        public string AvatarPath { get; set; }
        [DataMember]
        public int? UsuarioNivel { get; set; }
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
        public UsuariosBE() { }

        public UsuariosBE(
            int m_UsuarioId,
            int m_TipoUsuarioId,
            string m_Login,
            string m_Password,
            string m_PasswordOld,
            string m_ApePaterno,
            string m_ApeMaterno,
            string m_Nombres,
            int? m_DocumentoIdentidadId,
            string m_NumeroDoc,
            int? m_cip,
            DateTime? m_FechaNacimiento,
            string m_Email,
            string m_Telefono,
            string m_DocReferencia,
            short? m_CargoTipoId,
            string m_Cargo,
            DateTime? m_FinVigencia,
            DateTime? m_FechaUltimoLogueo,
            int? m_EstadoId,
            int? m_UbigeNavalId,
            bool m_ResetPassword,
            string m_AvatarPath,
            int? m_UsuarioNivel,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            UsuarioId = m_UsuarioId;
            TipoUsuarioId = m_TipoUsuarioId;
            Login = m_Login;
            Password = m_Password;
            PasswordOld = m_PasswordOld;
            ApePaterno = m_ApePaterno;
            ApeMaterno = m_ApeMaterno;
            Nombres = m_Nombres;
            DocumentoIdentidadId = m_DocumentoIdentidadId ;
            NumeroDoc = m_NumeroDoc;
            CIP = m_cip;
            FechaNacimiento = m_FechaNacimiento;
            Email = m_Email;
            Celular = m_Telefono;
            DocReferencia = m_DocReferencia;
            CargoTipoId = m_CargoTipoId;
            Cargo = m_Cargo;
            FinVigencia = m_FinVigencia;
            FechaUltimoLogueo = m_FechaUltimoLogueo;
            EstadoId = m_EstadoId;
            UbigeoNavalId = m_UbigeNavalId;
            ResetPassword = m_ResetPassword;
            AvatarPath = m_AvatarPath;
            UsuarioNivel = m_UsuarioNivel;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public UsuariosBE(IDataReader Registro)
        {
            UsuarioId = ValidarInt(Registro["UsuarioId"]);
            TipoUsuarioId = ValidarInt(Registro["TipoUsuarioId"]);
            Login = ValidarString(Registro["Login"]);
            Password = ValidarString(Registro["Password"]);
            PasswordOld = ValidarString(Registro["PasswordOld"]);
            ResetPassword = ValidarBool(Registro["ResetPassword"]);
            ApePaterno = ValidarString(Registro["ApePaterno"]);
            ApeMaterno = ValidarString(Registro["ApeMaterno"]);
            Nombres = ValidarString(Registro["Nombres"]);
            DocumentoIdentidadId = ValidarIntNulos(Registro["DocumentoIdentidadId"]);
            NumeroDoc = ValidarString(Registro["NumeroDoc"]);
            FechaNacimiento = ValidarDatetime(Registro["FechaNacimiento"]);
            Email = ValidarString(Registro["Email"]);
            Celular = ValidarString(Registro["Telefono"]);
            DocReferencia = ValidarString(Registro["DocReferencia"]);
            CargoTipoId = ValidarShortNulos(Registro["CargoTipoId"]);
            Cargo = ValidarString(Registro["Cargo"]);
            FinVigencia = ValidarDatetime(Registro["FinVigencia"]);
            FechaUltimoLogueo = ValidarDatetime(Registro["FechaUltimoLogueo"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UbigeoNavalId = ValidarIntNulos(Registro["UbigeoNavalId"]);
            AvatarPath = ValidarString(Registro["AvatarPath"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            UsuarioNivel = ValidarIntNulos(Registro["UsuarioNivel"]);
        }
        #endregion

    }
}
