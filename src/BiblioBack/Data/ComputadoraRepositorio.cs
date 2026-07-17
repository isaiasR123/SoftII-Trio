using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class ComputadoraRepositorio
{
    private List<Computadora> computadoras = new();

    public void Agregar(Computadora computadora)
    {
        computadoras.Add(computadora);
    }

    public List<Computadora> ObtenerTodas()
    {
        return computadoras;
    }

    public Computadora? BuscarPorCodigo(string codigo)
    {
        return computadoras.FirstOrDefault(c => c.Codigo == codigo);
    }

    public void Actualizar(Computadora computadora)
    {
        Computadora? existente = BuscarPorCodigo(computadora.Codigo);

        if (existente == null)
            throw new Exception("La computadora no existe.");

        existente.Marca = computadora.Marca;
        existente.Modelo = computadora.Modelo;
        existente.Ram = computadora.Ram;
    }

    public void Eliminar(string codigo)
    {
        Computadora? pc = BuscarPorCodigo(codigo);

        if (pc != null)
            computadoras.Remove(pc);
    }
}