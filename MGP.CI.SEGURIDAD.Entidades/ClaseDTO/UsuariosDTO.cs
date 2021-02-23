using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    public class UsuariosDTO : UsuariosBE
    {
        [DataMember]
        public string EstadoNombre;
        [DataMember]
        public string ZonaNaval;
        [DataMember]
        public string Dependencia;

        #region Constructores
        public UsuariosDTO() { }

        public UsuariosDTO(
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
           DateTime? m_FechaNacimiento,
           string m_Email,
           string m_Telefono,
           string m_DocReferencia,
           short? m_CargoTipoId,
           string m_Cargo,
           DateTime? m_FinVigencia,
           DateTime? m_FechaUltimoLogueo,
           int? m_EstadoId,
           string m_ZonaNaval,
           string m_Dependencia,
           int? m_DependenciaId,
           bool m_ResetPassword,
           string m_AvatarPath,
           string m_UsuarioRegistro,
           DateTime? m_FechaRegistro,
           string m_UsuarioModificacionRegistro,
           DateTime? m_FechaModificacionRegistro,
           string m_NroIpRegistro,
           string m_EstadoNombre
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
            DocumentoIdentidadId = m_DocumentoIdentidadId;
            NumeroDoc = m_NumeroDoc;
            FechaNacimiento = m_FechaNacimiento;
            Email = m_Email;
            Celular = m_Telefono;
            DocReferencia = m_DocReferencia;
            CargoTipoId = m_CargoTipoId;
            Cargo = m_Cargo;
            FinVigencia = m_FinVigencia;
            FechaUltimoLogueo = m_FechaUltimoLogueo;
            EstadoId = m_EstadoId;
            ZonaNaval = m_ZonaNaval;
            Dependencia = m_Dependencia;
            ResetPassword = m_ResetPassword;
            AvatarPath = m_AvatarPath;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
            EstadoNombre = m_EstadoNombre;
        }

        public UsuariosDTO(IDataReader Registro)
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
            ZonaNaval = ValidarString(Registro["ZonanavalDescCorta"]);
            Dependencia = ValidarString(Registro["DependenciaDescCorta"]);
            AvatarPath = ValidarString(Registro["AvatarPath"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            EstadoNombre = ValidarString(Registro["EstadoNombre"]);
        }


        #endregion

    }
}
