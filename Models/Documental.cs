namespace Models;

public class Documental : Contenido
{
    public string Tematica {get;set;}

    public Documental()
    {
        
    }

    public Documental(string _titulo, int _duracionMinutos, string _tematica):base(_titulo, _duracionMinutos)
    {
        this.Tematica = _tematica;
    }

    public override void ObtenerDescripcion()
    {
        Console.WriteLine($"Documental {Titulo} - Duración ${DuracionMinutos} - Temática {Tematica}");
    }
}