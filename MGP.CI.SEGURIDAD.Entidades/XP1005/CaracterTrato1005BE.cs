using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class CaracterTrato1005BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CaracterTrato1005";
        [DataMember]
        public int CaracterTrato1005Id { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int? NivelDesarrolloProfesional { get; set; }
        [DataMember]
        public string DescripcionDesarrolloProfesional { get; set; }
        [DataMember]
        public int? NivelCI { get; set; }
        [DataMember]
        public string DescripcionCI { get; set; }
        [DataMember]
        public string RelacionConCompaneros { get; set; }
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
        public CaracterTrato1005BE() { }

        public CaracterTrato1005BE(
            int m_CaracterTrato1005Id,
            int m_FichaId,
            int? m_NivelDesarrolloProfesional,
            string m_DescripcionDesarrolloProfesional,
            int? m_NivelCI,
            string m_DescripcionCI,
            string m_RelacionConCompaneros,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CaracterTrato1005Id = m_CaracterTrato1005Id;
            FichaId = m_FichaId;
            NivelDesarrolloProfesional = m_NivelDesarrolloProfesional;
            DescripcionDesarrolloProfesional = m_DescripcionDesarrolloProfesional;
            NivelCI = m_NivelCI;
            DescripcionCI = m_DescripcionCI;
            RelacionConCompaneros = m_RelacionConCompaneros;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CaracterTrato1005BE(IDataReader Registro)
        {
            CaracterTrato1005Id = ValidarInt(Registro["CaracterTrato1005Id"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            NivelDesarrolloProfesional = ValidarIntNulos(Registro["NivelDesarrolloProfesional"]);
            DescripcionDesarrolloProfesional = ValidarString(Registro["DescripcionDesarrolloProfesional"]);
            NivelCI = ValidarIntNulos(Registro["NivelCI"]);
            DescripcionCI = ValidarString(Registro["DescripcionCI"]);
            RelacionConCompaneros = ValidarString(Registro["RelacionConCompaneros"]);
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
