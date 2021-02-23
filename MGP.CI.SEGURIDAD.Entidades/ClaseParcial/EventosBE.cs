using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class EventosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Estados";
        [DataMember]
        public int EventoId { get; set; }
        [DataMember]
        public int UsuarioId { get; set; }
        [DataMember]
        public string UsuarioLogin { get; set; }
        [DataMember]
        public Boolean OperacionSatisfactorio { get; set; }
        [DataMember]
        public DateTime? GFH { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public int SistemaId { get; set; }
        [DataMember]
        public int EstadoId { get; set; }
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
        public EventosBE() { }

        public EventosBE(
            int m_EventoId,
            int m_UsuarioId,
            string m_UsuarioLogin,
            DateTime? m_GFH,
            string m_Accion,
            string m_Mensaje,
            int m_SistemaId,
            int m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            this.EventoId = m_EventoId;
            this.UsuarioId = m_UsuarioId;
            this.UsuarioLogin = m_UsuarioLogin;
            this.GFH = m_GFH;
            this.Accion = m_Accion;
            this.Mensaje = m_Mensaje;
            this.SistemaId = m_SistemaId;
            this.EstadoId = m_EstadoId;
            this.UsuarioRegistro = m_UsuarioRegistro;
            this.FechaRegistro = m_FechaRegistro;
            this.UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            this.FechaModificacionRegistro = m_FechaModificacionRegistro;
            this.NroIpRegistro = m_NroIpRegistro;
        }
        public EventosBE(IDataReader Registro)
        {
            EstadoId = ValidarInt(Registro["EventoId"]);
            UsuarioId = ValidarInt(Registro["UsuarioId"]);
            UsuarioLogin = ValidarString(Registro["m_UsuarioLogin"]);
            GFH = ValidarDatetime(Registro["GFH"]);
            Accion = ValidarString(Registro["Accion"]);
            Mensaje = ValidarString(Registro["Mensaje"]);
            SistemaId = ValidarInt(Registro["SistemaId"]);
            EstadoId = ValidarInt(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }

        #endregion

    }
}

/*

using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class EstadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Estados";
        [DataMember]
        public int EstadoId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int Estado { get; set; }
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
        public EstadosBE() { }

        public EstadosBE(
            int m_EstadoId,
            string m_Nombre,
            string m_Descripcion,
            int m_Estado,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            EstadoId = m_EstadoId;
            Nombre = m_Nombre;
            Descripcion = m_Descripcion;
            Estado = m_Estado;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public EstadosBE(IDataReader Registro)
        {
            EstadoId = ValidarInt(Registro["EstadoId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            Estado = ValidarInt(Registro["Estado"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}*/