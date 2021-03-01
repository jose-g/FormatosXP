using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Negocio.X1005;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005
{
    public class X1005PerfilPsicologicoViewModel
    {
        public string ErrorSMS { get; set; }

        #region PropiedadesBE
        public Int32 FichaId { get; set; }
        public Int32 DeclaranteId { get; set; }
        public Int32 PerfilPsicologicoId { get; set; }

        // Apariencia Fisica
        [Display(Name = "Edad")]
        public Int32? Edad { get; set; }
        [Display(Name = "Talla")]
        public Int32? Talla { get; set; }
        [Display(Name = "Peso")]
        public Int32? Peso { get; set; }
        [Display(Name = "Contextura")]
        public Int32 ContexturaId { get; set; }
        [Display(Name = "Aspecto Fisico / Enfermedades o Padecimiento Cronico")]
        public string EnfermedadesPadecimientoCronico{ get; set; }
        public List<ContexturaBE> LstContextura;

        // Apariencia Personal
        [Display(Name = "Expresion del Rostro")]
        public string AparienciaExpresionRostro { get; set; }
        [Display(Name = "Vestido")]
        public string AparienciaVestido { get; set; }
        [Display(Name = "Modales")]
        public string AparienciaModales { get; set; }

        // Intereses, Habitos y Vicios
        [Display(Name = "Talla")]
        public Int32? InteresHabitoVicioId{ get; set; }
        public Int32? NivelMadurezId { get; set; }
        public List<InteresesHabitosViciosBE> LstInteresesHabitosVicios { get; set; }
        public string InteresesHabitosViciosDescripcion { get; set; }
        public List<NivelesMadurez1005BE> LstNivelesDeMadurez { get; set; }

        // Pensamiento, Inteligencia y Formacion
        [Display(Name = "Capacidad de Pensamiento y Toma de Decisiones")]
        public string PensamientoCapacidad { get; set; }
        [Display(Name = "Coherencia en Organizaciones y Expresion de sus Respuestas")]
        public string PensamientoCoherencia { get; set; }
        [Display(Name = "Nivel de Inteligencia Estimado")]
        public string PensamientoNivelInteligencia { get; set; }
        [Display(Name = "Expresion Verbal")]
        public string PensamientoExpresionVerbal { get; set; }
        [Display(Name = "Cultura General y Profesional")]
        public string PensamientoCulturaGeneral { get; set; }

        //ACTITUDES MANIFIESTAS 
        [Display(Name = "Socio Politico")]
        public string ActitudesSocioPolitico { get; set; }
        [Display(Name = "Imagen de Si Mismo")]
        public string ActitudesImagenDeSiMismo { get; set; }
        [Display(Name = "Frente al Ejercicio de la Autoridad")]
        public string ActitudesFrenteAlEjercicio { get; set; }
        [Display(Name = "Observaciones Adicionales")]
        public string ActitudesObservacionesAdicionales { get; set; }

        //Relaciones Interpersonales
        public string RelacionesInterpersonalesDescripcion { get; set; }

        public List<RelacionesInterpersonalesBE> LstRelacionesInterpersonales { get; set; }
        public List<NivelesNumericos1005BE> LstNivelesNumericos{ get; set; }
        public string NivelDeComportamientoDescripcion{ get; set; }


        #endregion

        public X1005PerfilPsicologicoViewModel()
        {
            LstContextura = new List<ContexturaBE>();
            LstInteresesHabitosVicios = new List<InteresesHabitosViciosBE>();
            LstNivelesDeMadurez = new List<NivelesMadurez1005BE>();
            LstRelacionesInterpersonales = new List<RelacionesInterpersonalesBE>();
            LstNivelesNumericos = new List<NivelesNumericos1005BE>();
            CargarTablasMaestras();
        }


        public void CargarTablasMaestras()
        {
            LstContextura = new ContexturaBL().Consultar_Lista();
            LstInteresesHabitosVicios = new InteresesHabitosViciosBL().Consultar_Lista();
            LstNivelesDeMadurez = new NivelesMadurez1005BL().Consultar_Lista();
            LstRelacionesInterpersonales = new RelacionesInterpersonalesBL().Consultar_Lista();
            LstNivelesNumericos = new NivelesNumericos1005BL().Consultar_Lista();
        }

    }
}
