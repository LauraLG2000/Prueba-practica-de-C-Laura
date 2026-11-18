namespace Models;

public class Serie : Contenido
{
    public int NumeroTemporadas {get;set;}

    public Serie()
    {
        
    }

    public Serie(string _titulo, int _duracionMinutos, int _numeroTemporadas):base(_titulo, _duracionMinutos)
    {
        this.NumeroTemporadas = _numeroTemporadas;
    }

    public override void ObtenerDescripcion()
    {
        Console.WriteLine($"Serie {Titulo} - Duración ${DuracionMinutos} - Número de Temporadas {NumeroTemporadas}");
    }
}