using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class PerfilPsicologicoDetallesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PerfilPsicologicoDetalles";
        [DataMember]
        public int PerfilPsicologicoDetallesId { get; set; }
        [DataMember]
        public int PerfilPsicologico1005Id { get; set; }
        [DataMember]
        public int? FisicaEdad { get; set; }
        [DataMember]
        public decimal? FisicaTalla { get; set; }
        [DataMember]
        public decimal? FisicaPeso { get; set; }
        [DataMember]
        public int ContexturaId { get; set; }
        [DataMember]
        public string Fisicaaspectoscronico { get; set; }
        [DataMember]
        public string AparienciaExpresionRostro { get; set; }
        [DataMember]
        public string AparienciaVestido { get; set; }
        [DataMember]
        public string AparienciaModales { get; set; }
        [DataMember]
        public string PensamientoCapacidad { get; set; }
        [DataMember]
        public string PensamientoCoherencia { get; set; }
        [DataMember]
        public string PensamientoNivelInteligencia { get; set; }
        [DataMember]
        public string PensamientoExpresionVerbal { get; set; }
        [DataMember]
        public string PensamientoCulturaGeneral { get; set; }
        [DataMember]
        public string ActitudesSocioPolitico { get; set; }
        [DataMember]
        public string ActitudesImagenDeSiMismo { get; set; }
        [DataMember]
        public string ActitudesFrenteAlEjercicio { get; set; }
        [DataMember]
        public string ActitudesObservacionesAdicionales { get; set; }
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
        public PerfilPsicologicoDetallesBE() { }

        public PerfilPsicologicoDetallesBE(
            int m_PerfilPsicologicoDetallesId,
            int m_PerfilPsicologico1005Id,
            int? m_FisicaEdad,
            decimal? m_FisicaTalla,
            decimal? m_FisicaPeso,
            int m_ContexturaId,
            string m_Fisicaaspectoscronico,
            string m_AparienciaExpresionRostro,
            string m_AparienciaVestido,
            string m_AparienciaModales,
            string m_PensamientoCapacidad,
            string m_PensamientoCoherencia,
            string m_PensamientoNivelInteligencia,
            string m_PensamientoExpresionVerbal,
            string m_PensamientoCulturaGeneral,
            string m_ActitudesSocioPolitico,
            string m_ActitudesImagenDeSiMismo,
            string m_ActitudesFrenteAlEjercicio,
            string m_ActitudesObservacionesAdicionales,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PerfilPsicologicoDetallesId = m_PerfilPsicologicoDetallesId;
            PerfilPsicologico1005Id = m_PerfilPsicologico1005Id;
            FisicaEdad = m_FisicaEdad;
            FisicaTalla = m_FisicaTalla;
            FisicaPeso = m_FisicaPeso;
            ContexturaId = m_ContexturaId;
            Fisicaaspectoscronico = m_Fisicaaspectoscronico;
            AparienciaExpresionRostro = m_AparienciaExpresionRostro;
            AparienciaVestido = m_AparienciaVestido;
            AparienciaModales = m_AparienciaModales;
            PensamientoCapacidad = m_PensamientoCapacidad;
            PensamientoCoherencia = m_PensamientoCoherencia;
            PensamientoNivelInteligencia = m_PensamientoNivelInteligencia;
            PensamientoExpresionVerbal = m_PensamientoExpresionVerbal;
            PensamientoCulturaGeneral = m_PensamientoCulturaGeneral;
            ActitudesSocioPolitico = m_ActitudesSocioPolitico;
            ActitudesImagenDeSiMismo = m_ActitudesImagenDeSiMismo;
            ActitudesFrenteAlEjercicio = m_ActitudesFrenteAlEjercicio;
            ActitudesObservacionesAdicionales = m_ActitudesObservacionesAdicionales;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PerfilPsicologicoDetallesBE(IDataReader Registro)
        {
            PerfilPsicologicoDetallesId = ValidarInt(Registro["PerfilPsicologicoDetallesId"]);
            PerfilPsicologico1005Id = ValidarInt(Registro["PerfilPsicologico1005Id"]);
            FisicaEdad = ValidarIntNulos(Registro["FisicaEdad"]);
            FisicaTalla = ValidarDecimalNulos(Registro["FisicaTalla"]);
            FisicaPeso = ValidarDecimalNulos(Registro["FisicaPeso"]);
            ContexturaId = ValidarInt(Registro["ContexturaId"]);
            Fisicaaspectoscronico = ValidarString(Registro["Fisicaaspectoscronico"]);
            AparienciaExpresionRostro = ValidarString(Registro["AparienciaExpresionRostro"]);
            AparienciaVestido = ValidarString(Registro["AparienciaVestido"]);
            AparienciaModales = ValidarString(Registro["AparienciaModales"]);
            PensamientoCapacidad = ValidarString(Registro["PensamientoCapacidad"]);
            PensamientoCoherencia = ValidarString(Registro["PensamientoCoherencia"]);
            PensamientoNivelInteligencia = ValidarString(Registro["PensamientoNivelInteligencia"]);
            PensamientoExpresionVerbal = ValidarString(Registro["PensamientoExpresionVerbal"]);
            PensamientoCulturaGeneral = ValidarString(Registro["PensamientoCulturaGeneral"]);
            ActitudesSocioPolitico = ValidarString(Registro["ActitudesSocioPolitico"]);
            ActitudesImagenDeSiMismo = ValidarString(Registro["ActitudesImagenDeSiMismo"]);
            ActitudesFrenteAlEjercicio = ValidarString(Registro["ActitudesFrenteAlEjercicio"]);
            ActitudesObservacionesAdicionales = ValidarString(Registro["ActitudesObservacionesAdicionales"]);
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
