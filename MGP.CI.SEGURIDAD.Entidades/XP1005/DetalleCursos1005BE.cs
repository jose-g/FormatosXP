using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class DetalleCursos1005BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DetalleCursos1005";
        [DataMember]
        public int DetalleCursos1005Id { get; set; }
        [DataMember]
        public int ActividadesIntoPais1005Id { get; set; }
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
        public DetalleCursos1005BE() { }

        public DetalleCursos1005BE(
            int m_DetalleCursos1005Id,
            int m_ActividadesIntoPais1005Id,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DetalleCursos1005Id = m_DetalleCursos1005Id;
            ActividadesIntoPais1005Id = m_ActividadesIntoPais1005Id;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DetalleCursos1005BE(IDataReader Registro)
        {
            DetalleCursos1005Id = ValidarInt(Registro["DetalleCursos1005Id"]);
            ActividadesIntoPais1005Id = ValidarInt(Registro["ActividadesIntoPais1005Id"]);
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
