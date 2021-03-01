using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class AtencionesMedicasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "AtencionesMedicas";
        [DataMember]
        public int AtencionesMedicasId { get; set; }
        [DataMember]
        public int ActividadesIntoPais1005Id { get; set; }
        [DataMember]
        public int CentrosMedicosId { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
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
        public AtencionesMedicasBE() { }

        public AtencionesMedicasBE(
            int m_AtencionesMedicasId,
            int m_ActividadesIntoPais1005Id,
            int m_CentrosMedicosId,
            string m_Motivo,
            DateTime? m_Fecha,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            AtencionesMedicasId = m_AtencionesMedicasId;
            ActividadesIntoPais1005Id = m_ActividadesIntoPais1005Id;
            CentrosMedicosId = m_CentrosMedicosId;
            Motivo = m_Motivo;
            Fecha = m_Fecha;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public AtencionesMedicasBE(IDataReader Registro)
        {
            AtencionesMedicasId = ValidarInt(Registro["AtencionesMedicasId"]);
            ActividadesIntoPais1005Id = ValidarInt(Registro["ActividadesIntoPais1005Id"]);
            CentrosMedicosId = ValidarInt(Registro["CentrosMedicosId"]);
            Motivo = ValidarString(Registro["Motivo"]);
            Fecha = ValidarDatetime(Registro["Fecha"]);
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
