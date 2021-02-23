using MGP.CI.SEGURIDAD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class PermisoVistaVM
    {
        public bool NUEVO { get; set; } = false;
        public bool ELIMINAR { get; set; } = false;
        public bool MODIFICAR { get; set; } = false;
        public bool CONSULTAR { get; set; } = false;
        public bool REPORTE { get; set; } = false;
        public PermisoVistaVM CargarPermisos(List<PermisoPerfilModulosBE> LstPermisosAsociados, int m_perfilmodulosId)
        {
            foreach (PermisoPerfilModulosBE permisoPerfilModulos in LstPermisosAsociados)
            {
                if (permisoPerfilModulos.PerfilModuloId != m_perfilmodulosId)
                    continue;

                switch (permisoPerfilModulos.PermisoId)
                {
                    case 1:
                        NUEVO = true;
                        break;
                    case 2:
                        CONSULTAR = true;
                        break;
                    case 3:
                        MODIFICAR = true;
                        break;
                    case 4:
                        ELIMINAR = true;
                        break;
                    case 5:
                        REPORTE = true;
                        break;
                }
            }
            return this;
        }
    }
}