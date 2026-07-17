using BiblioBack.Dominio;

namespace BiblioBack.Data;

public class LaboratorioRepositorio
{
    private List<Laboratorio> laboratorios = new();

    public void Agregar(Laboratorio laboratorio)
    {
        laboratorios.Add(laboratorio);
    }

    public List<Laboratorio> ObtenerTodos()
    {
        return laboratorios;
    }

    public Laboratorio? BuscarPorId(int id)
    {
        return null;
    }

    public void Actualizar(Laboratorio laboratorio)
    {
    }

    public void Eliminar(int id)
    {
    }
}