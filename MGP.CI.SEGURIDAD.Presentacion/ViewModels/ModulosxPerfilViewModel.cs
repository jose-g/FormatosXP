using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using Microsoft.Ajax.Utilities;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class ModulosxPerfilViewModel
    {
        public String ErrorSms { get; set; } = "";
        #region Propiedades

        public List<SistemasBE> LstSistemas;
        public List<ModulosBE> LstModulosxSistema;
        public List<PermisosBE> LstPermisos;
        public List<PerfilModulosBE> LstModulosxPerfil;
        public List<PermisoPerfilModulosBE> LstPermisoPerfilModulosBE;

        #endregion

        #region Constructores
        public ModulosxPerfilViewModel()
        {
            LstSistemas = new List<SistemasBE>();
        }
        #endregion

        #region Operaciones

        public void CargarxPerfil(int m_perfilId)
        {
            SistemasxPerfil(m_perfilId);
            ModulosxPerfil(m_perfilId);
            ModulosxSistema(m_perfilId);
            PermisosdeModulosxPerfil(m_perfilId);
            CargarPermisos();
        }

        public void  CargarPermisos()
        {
            LstPermisos = new PermisosBL().Consultar_Lista();
        }

        public void SistemasxPerfil(int m_perfilId)
        {
            LstSistemas = new PerfilModulosBL().Consultar_Lista()
                .Join(new ModulosBL().Consultar_Lista(), PM => PM.ModuloId, M => M.ModuloId, (PM, M) => new { pm = PM, m = M })
                .Join(new SistemasBL().Consultar_Lista(), MO => MO.m.SistemaId, S => S.SistemaId, (MO, S) => new { s = S, mo = MO })
                .Where(PEM => PEM.mo.pm.PerfilId == m_perfilId).Select(sistema => sistema.s).DistinctBy(x => x.SistemaId).ToList();
        }
        public List<PerfilModulosBE> ModulosxPerfil(int m_perfilId)
        {
            LstModulosxPerfil = new PerfilModulosBL().Consultar_Lista()
                .Join(new ModulosBL().Consultar_Lista(), PM => PM.ModuloId, M => M.ModuloId, (PM, M) => new { pm = PM, m = M })
                .Where(PEM => PEM.pm.PerfilId == m_perfilId).Select(sistema => sistema.pm).ToList();

            return LstModulosxPerfil;
        }
        public List<ModulosBE> ModulosxSistema(int m_perfilId)
        {
            LstModulosxSistema = new PerfilModulosBL().Consultar_Lista()
                .Join(new ModulosBL().Consultar_Lista(), PM => PM.ModuloId, M => M.ModuloId, (PM, M) => new { pm = PM, m = M })
                .Join(new SistemasBL().Consultar_Lista(), PM_M => PM_M.m.SistemaId, S => S.SistemaId, (PM_M, S) => new { pm_m = PM_M, s = S })
                .Where(PEM => PEM.pm_m.pm.PerfilId == m_perfilId).Select(modulos => modulos.pm_m.m).ToList();

            return LstModulosxSistema;
        }
        public List<PermisoPerfilModulosBE> PermisosdeModulosxPerfil(int m_perfilId)
        {
            //LstPermisoPerfilModulosBE = new PerfilModulosBL().Consultar_Lista().Where(x => x.PerfilId == m_perfilId)
            //    .Join(new PerfilesBL().Consultar_Lista(), PM => PM.ModuloId, P => P.PerfilesId, (PM, P) => new { pm = PM, p = P })
            //    .Join(new PermisoPerfilModulosBL().Consultar_Lista(), PE => PE.pm.PerfilModuloId, PPM => PPM.PerfilModuloId, (PE, PPM) => new { pe = PE, ppm = PPM })
            //    .Where(JPPM => JPPM.pe.p.PerfilesId == m_perfilId).Select(permisoperfilmodulo => permisoperfilmodulo.ppm).ToList();

            //var rpta1 = new PerfilModulosBL().Consultar_Lista().Where(x=>x.PerfilId==1)
            //    .Join(new PerfilesBL().Consultar_Lista(), PM => PM.ModuloId, P => P.PerfilesId, (PM, P) => new { pm = PM, p = P })
            //   .Select(PerfilModulos => PerfilModulos.pm).ToList();

            LstPermisoPerfilModulosBE = new PerfilModulosBL().Consultar_Lista().Where(x => x.PerfilId == m_perfilId)
               .Join(new PerfilesBL().Consultar_Lista(), PM => PM.ModuloId, P => P.PerfilesId, (PM, P) => new { pm = PM, p = P })
               .Join(new PermisoPerfilModulosBL().Consultar_Lista(), PE => PE.pm.PerfilModuloId, PPM => PPM.PerfilModuloId, (PE, PPM) => new { pe = PE, ppm = PPM })
              .Select(PerfilModulos => PerfilModulos.ppm).ToList();



            return LstPermisoPerfilModulosBE;
        }
        #endregion


    }
}