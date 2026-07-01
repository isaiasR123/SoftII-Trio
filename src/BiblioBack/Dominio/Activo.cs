using System;
class Activo
{
   public string Marca {get; set;}
   public string Modelo {get; set;}
   public string Codigo {get; set;}

 public Activo(string marca,string modelo,string codigo){
    this.Marca = marca;
    this.Modelo = modelo;
    this.Codigo = codigo;
 } 

 public virtual void MostrarInformacion(){
    Console.writeLine($"Codigo: {Codigo}");
    Console.WriteLine($"Marca: {Marca}");
    Console.WriteLine($"Modelo: {Modelo}");
 }

     
    
     
}