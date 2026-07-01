using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Computadora : Activo 
{
  public int Ram {get; set;}

   public Computadora(string marca,string modelo,string codigo,int ram) : base (marca,modelo,codigo){
    this.Ram = ram;
   }

  public override void MostrarInformacion (){
    Console.WriteLine("=====COMPUTADORA=====");
    base.MostrarInformacion();
    Console.WriteLine($"Ram: {Ram} GB");
  }
}
