using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto
{
    public class ValidarLaboratorio
    {
       public void ValidarNombre(nombre){
        if (string.IsNullOrWhiteSpace(nombre)){
        throw new  Exception("El nombre no puede estar vacio");     
        } 
       }

        public void  ValidarUbicacion(ubicacion){
            if(string.IsNullOrWhiteSpace(ubicacion){
                throw new Exception("La ubicacion no puede estar vacio");
            }
        }
        
    }
}
