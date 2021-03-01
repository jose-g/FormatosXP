using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class ActividadesIntoPais1005BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "ActividadesIntoPais1005";
        [DataMember]
        public int ActividadesIntoPais1005Id { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int CursoEscuelaExtranjeraId { get; set; }
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
        public ActividadesIntoPais1005BE() { }

        public ActividadesIntoPais1005BE(
            int m_ActividadesIntoPais1005Id,
            int m_FichaId,
            int m_CursoEscuelaExtranjeraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            ActividadesIntoPais1005Id = m_ActividadesIntoPais1005Id;
            FichaId = m_FichaId;
            CursoEscuelaExtranjeraId = m_CursoEscuelaExtranjeraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public ActividadesIntoPais1005BE(IDataReader Registro)
        {
            ActividadesIntoPais1005Id = ValidarInt(Registro["ActividadesIntoPais1005Id"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            CursoEscuelaExtranjeraId = ValidarInt(Registro["CursoEscuelaExtranjeraId"]);
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
