using EspacioArchivoCSV;

string? path;
do
{
    Console.WriteLine("Ingrese un path de directorio");
    path = Console.ReadLine();
    if (System.IO.Directory.Exists(path))
    {
        string[] listaDeDirectoriosDelDirectorio = System.IO.Directory.GetDirectories(path);//lista de directorios
        Console.WriteLine("------Carpetas del directorio-------");
        foreach (var direccion in listaDeDirectoriosDelDirectorio)
        {
            Console.WriteLine($"{Path.GetFileName(direccion)}");//codigo para solo poner el nombre sin la direccion completa
        }
        string[] listaDeArchivosDelDirectorio = System.IO.Directory.GetFiles(path);
        Console.WriteLine("-------Archivos del directorio-------");
        foreach (var archivo in listaDeArchivosDelDirectorio)
        {
            //para sacar el peso del archivo
            FileInfo archivoInfo = new FileInfo(archivo); //creo objetos con la clase FileInfo para sacar la informacion
            if (archivoInfo.Exists)//verifico que exista
            {
                Console.WriteLine($"{archivoInfo.Name} {Math.Round(archivoInfo.Length/1024.0,2)} Kb");//tambien me permite sacar su nombre directamente y saco su peso
            }
            else
            {
                Console.WriteLine("No existe");
            }
        }
        ArchivoCSV.GenerarCSV(path);
    }
    else
    {
        Console.WriteLine("Ingrese un path valido");
    }
} while (!System.IO.Directory.Exists(path));
