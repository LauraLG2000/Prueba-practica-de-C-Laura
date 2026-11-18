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