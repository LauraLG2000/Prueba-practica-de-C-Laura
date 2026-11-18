namespace Models;

public abstract class Contenido
{
    public string Titulo{get;set;}
    public int DuracionMinutos {get;set;}

    public Contenido()
    {
        
    }

    public Contenido(string _titulo, int _duracionMinutos)
    {
        this.Titulo = _titulo;
        this.DuracionMinutos = _duracionMinutos;
    }
}