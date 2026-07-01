using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Computadora : activo 
{
  public int Ram {get; set;}

   public Computadora(string codigo,string marca,string modelo,int ram) : base (codigo,marca,modelo){
     this.Ram = ram;
   }

  public override void MostrarInformacion (){
    Console.WriteLine("=====COMPUTADORA=====");
    base.MostrarInformacion();
    Console.WriteLine($"Ram: {ram} GB");
  }
}
