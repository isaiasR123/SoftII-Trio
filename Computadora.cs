using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto
{
     class Computadora
    {
       public string nombre {get; set;}
       public string sistemaOperativo {get; set;}

       public Laboratorio Laboratorio {get; set;}

       public ModeloPc Modelo{get; set;}

       public Computadora(string nombre, string sistemaOperativo, Laboratorio laboratorio, ModeloPc modelo)
      {
        this.nombre = nombre;
        this.sistemaOperativo = sistemaOperativo;
        this.Laboratorio = laboratorio;
        this.Modelo = modelo;
      }

    
    }
}
