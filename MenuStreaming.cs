namespace Streaming;

using Models;

public class MenuStreaming
{
    public const int OpcionSalir = 0;
    public const int UltimaOpcionValida = 5;
    List<Contenido> streaming;

    public MenuStreaming()
    {
        Pelicula pelicula1 = new Pelicula("Mi Vecino Toro", 120, "Toriyama");
        Pelicula pelicula2 = new Pelicula("One Piece Film Red", 150, "Eichiro Oda");

        Serie serie1 = new Serie("Aquí No Hay Quien Viva", 90, 5);
        Serie serie2 = new Serie("La que se Avecina", 90, 17);

        Documental documental = new Documental("La vida de los animales", 60, "Científico");

        streaming = [pelicula1, pelicula2, serie1, serie2, documental];
    }
    public void MostrarMenu()
    {
        int opcionMenu;

        do
        {
            Console.WriteLine("\r\n=== STREAMING ===");
            Console.WriteLine("1. Ver todas los contenidos");
            Console.WriteLine("2. Buscar contenido");
            Console.WriteLine("3. Filtrar por duración");
            Console.WriteLine("4. Mostrar películas");
            Console.WriteLine($"{UltimaOpcionValida}. Ver estadísticas");
            Console.WriteLine("0. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcionMenu) || opcionMenu < OpcionSalir || opcionMenu > UltimaOpcionValida)
            {
                Console.WriteLine($"Error: No se ha introducido una opción válida ({OpcionSalir}-{UltimaOpcionValida})");
                continue;
            }

            switch (opcionMenu)
            {
                case 1:
                    ListarContenido();
                    break;

                case 2:
                    BuscarContenido();
                    break;

                case 3:
                    FiltradoPorDuracion();
                    break;

                case 4:
                    MostrarPeliculas();
                    break;

                case UltimaOpcionValida:
                    EstadisticaContenidos();
                    break;

                case OpcionSalir:
                    Console.WriteLine("Menú cerrado");
                    break;
            }

        } while (opcionMenu != OpcionSalir);
    }

    public void ListarContenido()
    {
        Console.WriteLine("=== LISTADO STREAMING ===");
        foreach (var contenido in streaming)
        {
            contenido.ObtenerDescripcion();
        }
        Console.WriteLine();
    }

    public void BuscarContenido()
    {
        Console.WriteLine("Introduce el título a buscar: ");
        string tituloBusqueda = Console.ReadLine().ToLower().Trim();
        bool encontrado = false;

        foreach (var contenido in streaming)
        {
            if (contenido.Titulo.ToLower().Equals(tituloBusqueda))
            {
                Console.WriteLine("Contenido encontrado");
                contenido.ObtenerDescripcion();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine($"No se ha encontrado el contenido con el título {tituloBusqueda}");
        }
    }

    public void FiltradoPorDuracion()
    {
        try
        {
            Console.WriteLine("Introduce la duracion máxima del contenido: ");
            int duracionMaximaBusqueda;
            if (!int.TryParse(Console.ReadLine(), out duracionMaximaBusqueda))
            {
                throw new InvalidCastException("Error: Introduce un número entero.");
            }

            if (duracionMaximaBusqueda < 0)
            {
                throw new ArgumentOutOfRangeException("Error: No se pueden introducir duraciones negativas.");
            }

            List<Contenido> contenidoFiltrado = new List<Contenido>();
            foreach (var contenido in streaming)
            {
                if (contenido.DuracionMinutos <= duracionMaximaBusqueda)
                {
                    contenidoFiltrado.Add(contenido);
                }
            }

            if (contenidoFiltrado.Count() == 0)
            {
                Console.WriteLine($"No hay contenido cuya duración sea menor o igual a {duracionMaximaBusqueda}");
            }
            else
            {
                Console.WriteLine($"Contenido filtrado por {duracionMaximaBusqueda} minutos");
                foreach (var contenido in contenidoFiltrado)
                {
                    contenido.ObtenerDescripcion();
                }
            }
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
        catch (InvalidCastException ice)
        {
            Console.WriteLine(ice.ToString());
        }
    }

    public void MostrarPeliculas()
    {
        List<Contenido> contenidoFiltrado = new List<Contenido>();
        foreach (var contenido in streaming)
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

    public void EstadisticaContenidos()
    {
        int totalContenidos = streaming.Count();
        int totalPeliculas = 0;
        int totalSeries = 0;
        int totalDocumentales = 0;

        foreach (var contenido in streaming)
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
}