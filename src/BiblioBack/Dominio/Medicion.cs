using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace proyecto
{
     class Medicion
    {

        private int CPU;
        private int Ram;

        private double Temperatura;

        private bool Conectada;

        private DateTime Fecha;
        public void setCPU(int procesador)
        {
            if(procesador < 0 || procesador > 100)
            {
               throw new  Exception("Procesador tiene que estar entre 0 y 100");
            }
               this.CPU = procesador;
            
        }

        public void setRam(int ram)
        {
            if(ram < 0 || ram > 100)
            {
                throw new Exception ("Ram debe estar entre 0 y 100");
            }
            this.Ram = ram;
        }

        public void setTemperatura(float temperatura)
        {
            if(temperatura < 0)
            {
                throw new Exception("Temperatura no debe ser negativo");
            }
            this.Temperatura = temperatura;
        }

        public void setConectada(string conectada)
        {
            if (!bool.TryParse(conectada, out bool resultado))
            {
                throw new Exception ("No debe estar vacio");
            }   
            this.Conectada = resultado;
        }
        
        public void setFecha(DateTime fecha)
        {
            if (fecha > DateTime.Now)
            
            {
             throw new Exception("La fecha no puede ser futura");   
            }
            this.Fecha = fecha;
        }


    }
}