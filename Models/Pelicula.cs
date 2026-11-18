namespace Models;

public class Pelicula : Contenido
{
    public string Director {get;set;}

    public Pelicula()
    {
        
    }

    public Pelicula(string _titulo, int _duracionMinutos, string _director):base(_titulo, _duracionMinutos)
    {
        this.Director = _director;
    }

    public override void ObtenerDescripcion()
    {
        Console.WriteLine($"Pelicula {Titulo} - Duración {DuracionMinutos} minutos - Director {Director}");
    }
}