namespace Streaming;

using Models;

public class MenuStreaming
{
    public const int OpcionSalir = 0;
    public const int UltimaOpcionValida = 5;
    List<Contenido> Streaming;

    public MenuStreaming()
    {
        Pelicula pelicula1 = new Pelicula("Mi Vecino Toro", 120, "Toriyama");
        Pelicula pelicula2 = new Pelicula("One Piece Film Red", 150, "Eichiro Oda");

        Serie serie1 = new Serie("Aquí No Hay Quien Viva", 90, 5);
        Serie serie2 = new Serie("La que se Avecina", 90, 17);

        Documental documental = new Documental("La vida de los animales", 60, "Científico");

        Streaming = [pelicula1, pelicula2, serie1, serie2, documental];
    }
    public void MostrarMenu()
    {
        int opcionMenu;

        do
        {
            Console.WriteLine("=== STREAMING ===");
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
                    break;

                case 4:
                    break;

                case UltimaOpcionValida:
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
        foreach (var contenido in Streaming)
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

        foreach (var contenido in Streaming)
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
}