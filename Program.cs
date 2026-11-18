using Models;

Pelicula pelicula1 = new Pelicula("Mi Vecino Toro", 120, "Toriyama");
Pelicula pelicula2 = new Pelicula("One Piece Film Red", 150, "Eichiro Oda");

Serie serie1 = new Serie("Aquí No Hay Quien Viva", 90, 5);
Serie serie2 = new Serie("La que se Avecina", 90, 17);

Documental documental = new Documental("La vida de los animales", 60, "Científico");

List<Contenido> Streaming = [pelicula1, pelicula2, serie1, serie2, documental];

foreach (var contenido in Streaming)
{
    contenido.ObtenerDescripcion();
}

Console.WriteLine("Introduce el nombre del titulo del contenido a buscar: ");
string tituloContenidoBusqueda = Console.ReadLine().ToLower().Trim();
BuscarContenido(Streaming, tituloContenidoBusqueda);

void BuscarContenido(List<Contenido> listaContenido, string titulo)
{

    bool encontrado = false;

    foreach (var contenido in listaContenido)
    {
        if (contenido.Titulo.ToLower().Equals(tituloContenidoBusqueda))
        {
            Console.WriteLine("Contenido encontrado");
            contenido.ObtenerDescripcion();
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine($"No se ha encontrado el contenido con el título {tituloContenidoBusqueda}");
    }
}

Console.WriteLine("Introduce la duracion máxima del contenido: ");
int duracionMaximaBusqueda;
if(int.TryParse(Console.ReadLine(), out duracionMaximaBusqueda))
{
    FiltradoPorDuracion(Streaming, duracionMaximaBusqueda);
}

void FiltradoPorDuracion(List<Contenido> listaContenido, int duracionMaxima)
{
    List<Contenido> contenidoFiltrado = new List<Contenido>();
    foreach(var contenido in listaContenido)
    {
        if(contenido.DuracionMinutos <= duracionMaxima)
        {
            contenidoFiltrado.Add(contenido);
        }
    }

    if(contenidoFiltrado.Count() == 0)
    {
        Console.WriteLine($"No hay contenido cuya duración sea menor o igual a {duracionMaxima}");
    }
    else
    {
        foreach(var contenido in contenidoFiltrado)
        {
            contenido.ObtenerDescripcion();
        }
    }
}

FiltradoPorPelicula(Streaming);

void FiltradoPorPelicula(List<Contenido> listaContenido)
{
    List<Contenido> contenidoFiltrado = new List<Contenido>();
    foreach(var contenido in listaContenido)
    {
        if(contenido is Pelicula)
        {
            contenidoFiltrado.Add(contenido);
        }
    }

    if(contenidoFiltrado.Count() == 0)
    {
        Console.WriteLine($"No hay peliculas registradas en la lista.");
    }
    else
    {
        foreach(var contenido in contenidoFiltrado)
        {
            contenido.ObtenerDescripcion();
        }
    }
}