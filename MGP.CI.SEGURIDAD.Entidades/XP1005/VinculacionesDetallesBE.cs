using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class VinculacionesDetallesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "VinculacionesDetalles";
        [DataMember]
        public int VinculacionesDetallesId { get; set; }
        [DataMember]
        public int Vinculaciones1005d { get; set; }
        [DataMember]
        public int VinculoId { get; set; }
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
        public VinculacionesDetallesBE() { }

        public VinculacionesDetallesBE(
            int m_VinculacionesDetallesId,
            int m_Vinculaciones1005d,
            int m_VinculoId,
            string m_Descripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            VinculacionesDetallesId = m_VinculacionesDetallesId;
            Vinculaciones1005d = m_Vinculaciones1005d;
            VinculoId = m_VinculoId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public VinculacionesDetallesBE(IDataReader Registro)
        {
            VinculacionesDetallesId = ValidarInt(Registro["VinculacionesDetallesId"]);
            Vinculaciones1005d = ValidarInt(Registro["Vinculaciones1005d"]);
            VinculoId = ValidarInt(Registro["VinculoId"]);
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
