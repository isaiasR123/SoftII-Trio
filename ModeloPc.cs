namespace proyecto;
public class ModeloPc
{
    private string marca { get; set; }

    private string modelo { get; set; }

    private int procesador { get; set; }

    private int ram { get; set; }

    private int temperatura { get; set; }

    private string conectada { get; set; }

    private DateTime fechahora { get; set; }

    private DateTime Hora { get; set; }

    public ModeloPc() { }


    public ModeloPc(string marca, string modelo, int procesador, int ram)

    {

        marca = marca;

        modelo = modelo;

        procesador = procesador;

        ram = ram;

    }
}