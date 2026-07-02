namespace proyecto;

public class ModeloPc
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Procesador { get; set; }
    public int Ram { get; set; }

    public ModeloPc(string marca, string modelo, int procesador, int ram)
    {
        ValidarModeloPc.ValidarMarca(marca);
        ValidarModeloPc.ValidarModelo(modelo);
        ValidarModeloPc.ValidarProcesador(procesador);
        ValidarModeloPc.ValidarRam(ram);

        Marca = marca;
        Modelo = modelo;
        Procesador = procesador;
        Ram = ram;
    }
}