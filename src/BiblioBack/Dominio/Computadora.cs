namespace BiblioBack.Dominio;
public class Computadora : Activo, IActivo
{
  public int Ram {get; set;}

   public Computadora(string marca, string modelo, string codigo, int ram) : base(marca, modelo, codigo)
   {
      if (ram <= 0)
      throw new Exception("La memoria RAM debe ser mayor que cero.");
      
      this.Ram = ram;
   }

  public override void MostrarInformacion (){
    Console.WriteLine("=====COMPUTADORA=====");
    base.MostrarInformacion();
    Console.WriteLine($"Ram: {Ram} GB");
  }

  public bool EstaActivo()
  {
    return true;
  }
}
