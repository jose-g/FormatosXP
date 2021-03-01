using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class ActividadesViajeBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "ActividadesViaje";
        [DataMember]
        public int ActividadesViajeId { get; set; }
        [DataMember]
        public int ActividadesIntoPais1005Id { get; set; }
        [DataMember]
        public int MotivosViajeId { get; set; }
        [DataMember]
        public DateTime? FechaViaje { get; set; }
        [DataMember]
        public int PaisId { get; set; }
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
        public ActividadesViajeBE() { }

        public ActividadesViajeBE(
            int m_ActividadesViajeId,
            int m_ActividadesIntoPais1005Id,
            int m_MotivosViajeId,
            DateTime? m_FechaViaje,
            int m_PaisId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            ActividadesViajeId = m_ActividadesViajeId;
            ActividadesIntoPais1005Id = m_ActividadesIntoPais1005Id;
            MotivosViajeId = m_MotivosViajeId;
            FechaViaje = m_FechaViaje;
            PaisId = m_PaisId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public ActividadesViajeBE(IDataReader Registro)
        {
            ActividadesViajeId = ValidarInt(Registro["ActividadesViajeId"]);
            ActividadesIntoPais1005Id = ValidarInt(Registro["ActividadesIntoPais1005Id"]);
            MotivosViajeId = ValidarInt(Registro["MotivosViajeId"]);
            FechaViaje = ValidarDatetime(Registro["FechaViaje"]);
            PaisId = ValidarInt(Registro["PaisId"]);
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
