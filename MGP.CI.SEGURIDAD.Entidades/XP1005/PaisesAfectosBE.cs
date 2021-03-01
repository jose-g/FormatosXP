using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class PaisesAfectosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PaisesAfectos";
        [DataMember]
        public int PaisesAfectosId { get; set; }
        [DataMember]
        public int Vinculaciones1005d { get; set; }
        [DataMember]
        public int InstitucionMilitarExtranjeraId { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
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
        public PaisesAfectosBE() { }

        public PaisesAfectosBE(
            int m_PaisesAfectosId,
            int m_Vinculaciones1005d,
            int m_InstitucionMilitarExtranjeraId,
            string m_Descripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PaisesAfectosId = m_PaisesAfectosId;
            Vinculaciones1005d = m_Vinculaciones1005d;
            InstitucionMilitarExtranjeraId = m_InstitucionMilitarExtranjeraId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PaisesAfectosBE(IDataReader Registro)
        {
            PaisesAfectosId = ValidarInt(Registro["PaisesAfectosId"]);
            Vinculaciones1005d = ValidarInt(Registro["Vinculaciones1005d"]);
            InstitucionMilitarExtranjeraId = ValidarInt(Registro["InstitucionMilitarExtranjeraId"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
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
