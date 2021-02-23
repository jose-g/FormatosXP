using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Negocio
{
    public class EnumBL
    {
        public enum COD_ERROR : int
        {
            OK_RESET_PASWORD = 1,//obligar cambiar contraseña
            OK_SUCCESS = 0,//OK
            ERR_LOGIN_EMPTY = -1,//login en blanco
            ERR_PASS_EMPTY = -2,//clave en blanco
            ERR_LOGIN_NOT_EXIST = -3,//login no existe
            ERR_USER_INACTIVE = -4,//usuario inactivo
            ERR_VIGENCIA_CADUCADO = -5,//fecha de vigencia del usuario caducado
            ERR_PASS_INCORECTO = -6,//contraseña incorrecta
            ERR_DESCONOCIDO = -7,//error desconocido
            ERR_NEW_PASS_EMPTY = -8,//clave nueva en blanco
            ERR_LONGITUD_PASS = -9,//Contraseña menor al permitido (6 caracteres minimo)
            ERR_PASS_SIN_NUMERO = -10,//La contraseña debe contener al menos un numero
            ERR_PASS_NO_COINCIDE = -11,//La contraseña no coinciden
            ERR_PASS_SIN_LETRA = -12//Contraseña sin letras
        }
    }
    }
