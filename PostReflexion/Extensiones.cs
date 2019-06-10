using System;
using System.Collections.Generic;
using System.Text;

namespace PostReflexion
{
    static class Extensiones
    {
        public static bool? EsVehiculoLargo(this BaseClass clase)
        {
            //Obtenemos todas las propiedades de la clase que nos pasan
            var properties = clase.GetType().GetProperties();
            //Iteramos las propiedades
            foreach(var propertyInfo in properties)
            {
                //Si alguna se llama 
                if(propertyInfo.Name == "EsVehiculoLargo")
                {
                    //Retornamos el valor
                    return Convert.ToBoolean(propertyInfo.GetValue(clase));
                }
            }
            //Si ninguna coincide, retornamos null
            return null;
        }
    }
}

