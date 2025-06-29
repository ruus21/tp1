//using System.Text; tuve que usar esto para darle el tag necesario a un archivo .mp3
using EspacioId3v1Tag;


Console.WriteLine("Inserte ruta ruta y nombre del archivo completo.");
string? archivo = Console.ReadLine();
if (System.IO.File.Exists(archivo))
{
    try
    {
        var tag = Id3v1tag.LeerArchivo(archivo);
        Console.WriteLine($"Titulo: {tag.Titulo}");
        Console.WriteLine($"Artista: {tag.Artista}");
        Console.WriteLine($"Album: {tag.Album}");
        Console.WriteLine($"nio: {tag.Anio}");
        Console.WriteLine($"Comentario: {tag.Comentario}");
        Console.WriteLine($"Genero(codigo): {tag.Genero}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
else
{
    Console.WriteLine("El archivo no existe");
}