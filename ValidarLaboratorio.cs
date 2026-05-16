using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto
{
    public static class ValidarLaboratorio
    {
        public static void ValidarNombre(string nombre){
        if (string.IsNullOrWhiteSpace(nombre))
        {
        throw new  Exception("El nombre no puede estar vacio");     
        } 
       }

        public static void  ValidarUbicacion(string ubicacion){
            if(string.IsNullOrWhiteSpace(ubicacion)){
                throw new Exception("La ubicacion no puede estar vacio");
            }
        }
        
    }
}
