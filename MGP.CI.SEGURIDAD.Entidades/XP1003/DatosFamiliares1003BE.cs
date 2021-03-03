using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class DatosFamiliares1003BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DatosFamiliares1003";
        [DataMember]
        public int FamiliarId { get; set; }
        [DataMember]
        public int DatosPersonalesId { get; set; }
        [DataMember]
        public int? ParentescoId { get; set; }
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
        public int? NacionalidadId { get; set; } = -1;
        [DataMember]
        public DateTime? FechaNamiento { get; set; }
        [DataMember]
        public int? PaisId { get; set; } = -1;
        [DataMember]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public int? GrupoSanguineoId { get; set; } = -1;
        [DataMember]
        public int EnfermedadTipoId { get; set; } = -1;
        [DataMember]
        public int EnfermedadId { get; set; } = -1;
        [DataMember]
        public int? ProfesionId { get; set; } = -1;
        [DataMember]
        public string Actividades { get; set; }
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
        [DataMember]
        public int? EsResidente { get; set; }
        #endregion

        #region Constructores
        public DatosFamiliares1003BE() { }

        public DatosFamiliares1003BE(
            int m_FamiliarId,
            int m_DatosPersonalesId,
            int? m_ParentescoId,
            string m_Paterno,
            string m_Materno,
            string m_Nombres1,
            string m_Nombres2,
            string m_Nombres3,
            int? m_NacionalidadId,
            DateTime? m_FechaNamiento,
            int? m_PaisId,
            string m_LugarNacimiento,
            int? m_GrupoSanguineoId,
            int m_EnfermedadId,
            int m_EnfermedadTipoId,
            int? m_ProfesionId,
            string m_Actividades,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro,
            int m_EsResidente
        )
        {
            FamiliarId = m_FamiliarId;
            DatosPersonalesId = m_DatosPersonalesId;
            ParentescoId = m_ParentescoId;
            Paterno = m_Paterno;
            Materno = m_Materno;
            Nombres1 = m_Nombres1;
            Nombres2 = m_Nombres2;
            Nombres3 = m_Nombres3;
            NacionalidadId = m_NacionalidadId;
            FechaNamiento = m_FechaNamiento;
            PaisId = m_PaisId;
            LugarNacimiento = m_LugarNacimiento;
            GrupoSanguineoId = m_GrupoSanguineoId;
            EnfermedadId = m_EnfermedadId;
            EnfermedadTipoId = m_EnfermedadTipoId;
            ProfesionId = m_ProfesionId;
            Actividades = m_Actividades;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
            EsResidente = m_EsResidente;
        }

        public DatosFamiliares1003BE(IDataReader Registro)
        {
            FamiliarId = ValidarInt(Registro["FamiliarId"]);
            DatosPersonalesId = ValidarInt(Registro["DatosPersonalesId"]);
            ParentescoId = ValidarIntNulos(Registro["ParentescoId"]);
            Paterno = ValidarString(Registro["Paterno"]);
            Materno = ValidarString(Registro["Materno"]);
            Nombres1 = ValidarString(Registro["Nombres1"]);
            Nombres2 = ValidarString(Registro["Nombres2"]);
            Nombres3 = ValidarString(Registro["Nombres3"]);
            NacionalidadId = ValidarIntNulos(Registro["NacionalidadId"]);
            FechaNamiento = ValidarDatetime(Registro["FechaNamiento"]);
            PaisId = ValidarIntNulos(Registro["PaisId"]);
            LugarNacimiento = ValidarString(Registro["LugarNacimiento"]);
            GrupoSanguineoId = ValidarIntNulos(Registro["GrupoSanguineoId"]);
            EnfermedadTipoId = ValidarInt(Registro["EnfermedadTipoId"]);
            EnfermedadId = ValidarInt(Registro["EnfermedadId"]);
            ProfesionId = ValidarIntNulos(Registro["ProfesionId"]);
            Actividades = ValidarString(Registro["Actividades"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            EsResidente = ValidarIntNulos(Registro["EsResidente"]);
        }
        #endregion

    }
}
