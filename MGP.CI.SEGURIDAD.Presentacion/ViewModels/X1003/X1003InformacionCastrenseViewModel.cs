using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Negocio.XP1003;


namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003
{
    public class X1003InformacionCastrenseViewModel
    {
        public Int32 DeclaranteId { get; set; }
        public Int32 FichaId { get; set; }
        public Int32 X1003InformacionCastrenseId { get; set; }


        public void CargarTablasMaestras()
        {

        }
        public X1003InformacionCastrenseViewModel()
        {

        }
        public List<CondecoracionesExtranjerasBE> GetCondecoracionesPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new CondecoracionesExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }

        public List<GradosExtranjerosBE> GetGradosPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new GradosExtranjerosBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Descripcion).ToList();

        }

        public List<EscuelasExtranjerasBE> GetEscuelasPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return new EscuelasExtranjerasBL().Consultar_Lista().Where(x => x.InstitucionMilitarExtranjeraId.ToString().Equals(InstitucioneMilitarExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }

        public List<CursosEscuelasExtranjerasBE> GetCursosPorEscuelas(string EscuelaExtranjeraId)
        {
            return new CursosEscuelasExtranjerasBL().Consultar_Lista().Where(x => x.EscuelaExtranjeraId.ToString().Equals(EscuelaExtranjeraId)).OrderBy(x => x.Nombre).ToList();

        }



    }
}