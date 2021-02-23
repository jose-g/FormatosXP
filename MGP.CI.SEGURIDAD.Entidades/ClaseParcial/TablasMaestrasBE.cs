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
    public class TablasMaestrasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "TablasMaestras";
        [DataMember]
        public int TablaId { get; set; }
        [DataMember]
        public string TablaNombre { get; set; }
        [DataMember]
        public string TablaDescripcion { get; set; }
        [DataMember]
        public int? SistemaId{ get; set; }
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
        public TablasMaestrasBE() { }

        public TablasMaestrasBE(
           int m_TablaId,
           string m_TablaNombre,
           string m_TablaDescripcion,
           int? m_SistemaId,
           int? m_EstadoId,
           string m_UsuarioRegistro,
           DateTime? m_FechaRegistro,
           string m_UsuarioModificacionRegistro,
           DateTime? m_FechaModificacionRegistro,
           string m_NroIpRegistro
       )
        {
            TablaId = m_TablaId;
            TablaNombre = m_TablaNombre;
            TablaDescripcion = m_TablaDescripcion;
            SistemaId = m_SistemaId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public TablasMaestrasBE(IDataReader Registro)
        {
            TablaId = ValidarInt(Registro["TablaId"]);
            TablaNombre = ValidarString(Registro["TablaNombre"]);
            TablaDescripcion = ValidarString(Registro["TablaDescripcion"]);
            SistemaId = ValidarIntNulos(Registro["SistemaId"]);
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
