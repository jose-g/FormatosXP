using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class CargosDesempenadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CargosDesempenados";
        [DataMember]
        public int CargosDesempenadosId { get; set; }
        [DataMember]
        public int CargosMaestraId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public string SolvenciaEconomica { get; set; }
        [DataMember]
        public string ProblemasEconomicos { get; set; }
        [DataMember]
        public bool VidaDeHogar { get; set; }
        [DataMember]
        public string VidaDeHogarDescripcion { get; set; }
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
        public CargosDesempenadosBE() { }

        public CargosDesempenadosBE(
            int m_CargosDesempenadosId,
            int m_CargosMaestraId,
            int m_DatosGeneralesId,
            string m_SolvenciaEconomica,
            string m_ProblemasEconomicos,
            bool m_VidaDeHogar,
            string m_VidaDeHogarDescripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CargosDesempenadosId = m_CargosDesempenadosId;
            CargosMaestraId = m_CargosMaestraId;
            DatosGeneralesId = m_DatosGeneralesId;
            SolvenciaEconomica = m_SolvenciaEconomica;
            ProblemasEconomicos = m_ProblemasEconomicos;
            VidaDeHogar = m_VidaDeHogar;
            VidaDeHogarDescripcion = m_VidaDeHogarDescripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CargosDesempenadosBE(IDataReader Registro)
        {
            CargosDesempenadosId = ValidarInt(Registro["CargosDesempenadosId"]);
            CargosMaestraId = ValidarInt(Registro["CargosMaestraId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            SolvenciaEconomica = ValidarString(Registro["SolvenciaEconomica"]);
            ProblemasEconomicos = ValidarString(Registro["ProblemasEconomicos"]);
            VidaDeHogar = ValidarBool(Registro["VidaDeHogar"]);
            VidaDeHogarDescripcion = ValidarString(Registro["VidaDeHogarDescripcion"]);
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
