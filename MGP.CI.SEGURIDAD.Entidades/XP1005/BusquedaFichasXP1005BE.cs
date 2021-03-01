using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades.XP1005
{
    public class BusquedaFichasXP1005BE : BaseBE
    {
        #region Propiedades
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int TipoFichaId { get; set; }
        [DataMember]
        public int NroFamiliares{ get; set; }
        [DataMember]
        public int NroIdentificaciones{ get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        #endregion


        #region Constructores
        public BusquedaFichasXP1005BE() { }

        public BusquedaFichasXP1005BE(
            int m_FichaId,
            int m_TipoFichaId,
            int m_NroFamiliares,
            int m_NroIdentificaciones,
            DateTime? m_FechaRegistro
        )
        {
            FichaId = m_FichaId;
            TipoFichaId = m_TipoFichaId;
            NroFamiliares = m_NroFamiliares;
            NroIdentificaciones = m_NroIdentificaciones;
            FechaRegistro = m_FechaRegistro;

        }

        public BusquedaFichasXP1005BE(IDataReader Registro)
        {
            FichaId = ValidarInt(Registro["FichaId"]);
            TipoFichaId = ValidarInt(Registro["TipoFichaId"]);
            FechaRegistro = ValidarDateTime(Registro["FechaFicha"]);
            NroFamiliares = ValidarInt(Registro["NroFamiliares"]);
            NroIdentificaciones = ValidarInt(Registro["NroIdentificaciones"]);
        }

        #endregion


    }
}
