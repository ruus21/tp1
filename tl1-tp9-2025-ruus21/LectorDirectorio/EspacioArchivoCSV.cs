namespace EspacioArchivoCSV
{
    public class ArchivoCSV
    {//utilizo static si quiero solo llamar la funcion y que haga su tarea sin necesidad de crear objetos para poder usarlo
        public static void GenerarCSV(string direccion)//si no tuviera static tendria que crear un nuevo objeto archivoCSV para poder usarlo pero como necesito guardar datos, solo ejecuto la accion
        {
            if (!System.IO.Directory.Exists(direccion))
            {
                Console.WriteLine("El directorio no existe");
                return;
            }
            string[] archivos = System.IO.Directory.GetFiles(direccion); //obtengo los directorios de la direccion
            string rutaCSV = System.IO.Path.Combine(direccion, "reporte.csv"); //creo la direccion donde estara el archivo
            try//try sirve para intentar algo que puede fallar
            {
                using (StreamWriter sw = new StreamWriter(rutaCSV))
                {//es la clase StreamWriter para escribir, debo asignarle la ruta donde se escribira el archivo
                    sw.WriteLine("Nombre del archivo, Tamanio en kb y Fecha de ultima modificacion:");
                    foreach (var archivo in archivos)//recorro los archivos buscaods en la direccion
                    {
                        FileInfo info = new FileInfo(archivo);//crea una nueva instancia de la clase FileInfo, vinculada a un archivo especificado por la variable archivo. archivo debe ser una cadena de texto que representa la ruta completa o el nombre del archivo. 

                        string nombreArchivo = info.Name;
                        double tamanioKB = Math.Round(info.Length / 1024.0, 2); //me devuelve el dato en bytes y lo paso a kb
                        string fechaUltMod = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"); //obtengo el dato en date time y uso la funcion tostring para poder escribirlo

                        sw.WriteLine($"Archivo nombre: {nombreArchivo} {tamanioKB}Kb, Ultima vez modificado:{fechaUltMod}");//escribo el contenido del CSV
                    }
                }
                Console.WriteLine($"Se creo exitosamente el CSV en la direccion: {rutaCSV}");
            }
            catch(Exception ex)// ex no es necesario pero sirve para poner el error por si lo necesito
            {
                Console.WriteLine("Hubo un error al generar el reporte:" + ex.Message);
            }
        }
    }
}