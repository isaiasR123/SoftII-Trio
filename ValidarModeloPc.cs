namespace proyecto;

public static class ValidarModeloPc
{
    public ValidarMarca(string marca){
       if(string.IsNullOrWhiteSpace(marca)){
         throw new Exception("La marca no puede ser vacia");
       }
    }

    public ValidarModelo(string modelo){
        if(string.IsNullOrWhiteSpace(modelo)){
            throw new Exception("El modelo no puede estar vacio");
        }
    }

    public ValidarProcesador(int procesador){
        if(procesador < 0 || procesador > 100 ){
            throw new Exception("Procesador tiene que ser mayor que 0 y menor que 100");
        }
    }

    public ValidarRam(int ram){
        if(ram < 0 || ram > 32){
            throw new Exception("Ram debe ser mayor que 0 y menor que 32");
        }
    }

    public ValidarTemperatura(int temperatura){
        if(temperatura < 0 || temperatura > 50){
            throw new Exception("Temperatura debe ser mayor que 0 y menor que 50");
        }
    }


    public ValidarConectada(bool conectada){
        if(!conectada){
            throw new Exception("Error: debe estar conectado");
        }
    }
    
    public ValidarFechaHora(DateTime fechahora){
         if (fechahora == DateTime.MinValue)
    {
        throw new Exception("La fecha y hora no pueden estar vacías.");
    }

    if (fechahora > DateTime.Now)
    {
        throw new Exception("La fecha no puede ser futura.");
    }
    }
}
