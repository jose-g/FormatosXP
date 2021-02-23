using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class DatosPersonales1003BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DatosPersonales1003";
        [DataMember]
        public int DatosPersonalesId { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int? GradoExtranjeroId { get; set; }
        [DataMember]
        public int? EspecialidaIdExtranjeraId { get; set; }
        [DataMember]
        public string Paterno { get; set; }
        [DataMember]
        public string Materno { get; set; }
        [DataMember]
        public string Nombres1 { get; set; }
        [DataMember]
        public string Nombres2 { get; set; }
        [DataMember]
        public string Nombres3 { get; set; }
        [DataMember]
        public int? NacionalidadId { get; set; }
        [DataMember]
        public int PaisId { get; set; }
        [DataMember]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public DateTime? FechaNamiento { get; set; }
        [DataMember]
        public int? EstadoCivilId { get; set; }
        [DataMember]
        public int? GrupoSanguineoId { get; set; }
        [DataMember]
        public int? EnfermedadId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int SexoId { get; set; }
        [DataMember]
        public bool EstadoDatosPersonales { get; set; }
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
        public DatosPersonales1003BE() { }

        public DatosPersonales1003BE(
            int m_DatosPersonalesId,
            int m_FichaId,
            int? m_GradoExtranjeroId,
            int? m_EspecialidaIdExtranjeraId,
            string m_Paterno,
            string m_Materno,
            string m_Nombres1,
            string m_Nombres2,
            string m_Nombres3,
            int? m_NacionalidadId,
            int m_PaisId,
            string m_LugarNacimiento,
            DateTime? m_FechaNamiento,
            int? m_EstadoCivilId,
            int? m_GrupoSanguineoId,
            int m_EnfermedadId,
            int? m_EstadoId,
            int m_SexoId,
            bool m_EstadoDatosPersonales,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DatosPersonalesId = m_DatosPersonalesId;
            FichaId = m_FichaId;
            GradoExtranjeroId = m_GradoExtranjeroId;
            EspecialidaIdExtranjeraId = m_EspecialidaIdExtranjeraId;
            Paterno = m_Paterno;
            Materno = m_Materno;
            Nombres1 = m_Nombres1;
            Nombres2 = m_Nombres2;
            Nombres3 = m_Nombres3;
            NacionalidadId = m_NacionalidadId;
            PaisId = m_PaisId;
            LugarNacimiento = m_LugarNacimiento;
            FechaNamiento = m_FechaNamiento;
            EstadoCivilId = m_EstadoCivilId;
            GrupoSanguineoId = m_GrupoSanguineoId;
            EnfermedadId = m_EnfermedadId;
            EstadoId = m_EstadoId;
            SexoId = m_SexoId;
            EstadoDatosPersonales = m_EstadoDatosPersonales;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DatosPersonales1003BE(IDataReader Registro)
        {
            DatosPersonalesId = ValidarInt(Registro["DatosPersonalesId"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            GradoExtranjeroId = ValidarIntNulos(Registro["GradoExtranjeroId"]);
            EspecialidaIdExtranjeraId = ValidarIntNulos(Registro["EspecialidaIdExtranjeraId"]);
            Paterno = ValidarString(Registro["Paterno"]);
            Materno = ValidarString(Registro["Materno"]);
            Nombres1 = ValidarString(Registro["Nombres1"]);
            Nombres2 = ValidarString(Registro["Nombres2"]);
            Nombres3 = ValidarString(Registro["Nombres3"]);
            NacionalidadId = ValidarIntNulos(Registro["NacionalidadId"]);
            PaisId = ValidarInt(Registro["PaisId"]);
            LugarNacimiento = ValidarString(Registro["LugarNacimiento"]);
            FechaNamiento = ValidarDatetime(Registro["FechaNamiento"]);
            EstadoCivilId = ValidarIntNulos(Registro["EstadoCivilId"]);
            GrupoSanguineoId = ValidarIntNulos(Registro["GrupoSanguineoId"]);
            EnfermedadId = ValidarIntNulos(Registro["EnfermedadId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            SexoId = ValidarInt(Registro["SexoId"]);
            EstadoDatosPersonales = ValidarBool(Registro["EstadoDatosPersonales"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
