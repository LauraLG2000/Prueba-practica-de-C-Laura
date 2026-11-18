using Models;
using Streaming;

MenuStreaming menuStreaming = new MenuStreaming();
menuStreaming.MostrarMenu();

Pelicula pelicula1 = new Pelicula("Mi Vecino Toro", 120, "Toriyama");
Pelicula pelicula2 = new Pelicula("One Piece Film Red", 150, "Eichiro Oda");

Serie serie1 = new Serie("Aquí No Hay Quien Viva", 90, 5);
Serie serie2 = new Serie("La que se Avecina", 90, 17);

Documental documental = new Documental("La vida de los animales", 60, "Científico");

List<Contenido> Streaming = [pelicula1, pelicula2, serie1, serie2, documental];

Console.WriteLine("=== LISTADO STREAMING DESDE PROGRAM ===");
foreach (var contenido in Streaming)
{
    contenido.ObtenerDescripcion();
}
Console.WriteLine();

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
try
{
    if (!int.TryParse(Console.ReadLine(), out duracionMaximaBusqueda))
    {
        throw new InvalidCastException("Error: Introduce un número entero.");
    }

    if (duracionMaximaBusqueda < 0)
    {
        throw new ArgumentOutOfRangeException("Error: No se pueden introducir duraciones negativas.");
    }

    FiltradoPorDuracion(Streaming, duracionMaximaBusqueda);
}
catch (ArgumentOutOfRangeException aoore)
{
    Console.WriteLine(aoore.ToString());
}
catch (InvalidCastException ice)
{
    Console.WriteLine(ice.ToString());
}


void FiltradoPorDuracion(List<Contenido> listaContenido, int duracionMaxima)
{
    List<Contenido> contenidoFiltrado = new List<Contenido>();
    foreach (var contenido in listaContenido)
    {
        if (contenido.DuracionMinutos <= duracionMaxima)
        {
            contenidoFiltrado.Add(contenido);
        }
    }

    if (contenidoFiltrado.Count() == 0)
    {
        Console.WriteLine($"No hay contenido cuya duración sea menor o igual a {duracionMaxima}");
    }
    else
    {
        foreach (var contenido in contenidoFiltrado)
        {
            contenido.ObtenerDescripcion();
        }
    }
}

FiltradoPorPelicula(Streaming);

void FiltradoPorPelicula(List<Contenido> listaContenido)
{
    List<Contenido> contenidoFiltrado = new List<Contenido>();
    foreach (var contenido in listaContenido)
    {
        if (contenido is Pelicula)
        {
            contenidoFiltrado.Add(contenido);
        }
    }

    if (contenidoFiltrado.Count() == 0)
    {
        Console.WriteLine($"No hay peliculas registradas en la lista.");
    }
    else
    {
        Console.WriteLine("=== LISTADO DE PELÍCULAS ===");
        foreach (var contenido in contenidoFiltrado)
        {
            contenido.ObtenerDescripcion();
        }
    }
}

EstadisticaContenidos(Streaming);

void EstadisticaContenidos(List<Contenido> listaContenido)
{
    int totalContenidos = listaContenido.Count();
    int totalPeliculas = 0;
    int totalSeries = 0;
    int totalDocumentales = 0;

    foreach (var contenido in listaContenido)
    {
        if (contenido is Pelicula) totalPeliculas++;

        if (contenido is Serie) totalSeries++;

        if (contenido is Documental) totalDocumentales++;
    }

    Console.WriteLine("=== ESTADISTICAS ===");
    Console.WriteLine($"Total contenidos: {totalContenidos}");
    Console.WriteLine($"Películas: {totalPeliculas}");
    Console.WriteLine($"Series: {totalSeries}");
    Console.WriteLine($"Documentales: {totalDocumentales}");
}