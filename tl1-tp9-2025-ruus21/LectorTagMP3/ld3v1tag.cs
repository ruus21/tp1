namespace EspacioId3v1Tag
{
    public class Id3v1tag
    {
        public string? Titulo { get; private set; }//puedo colocarle el valor desde fuera pero solo se puede modificar desde dentro de la clase
        public string? Artista { get; private set; }
        public string? Album { get; private set; }
        public string? Anio { get; private set; }
        public string? Comentario { get; private set; }
        public byte Genero { get; private set; }
        
        //constructor
        public Id3v1tag(byte[] tagBytes)
        {
            Titulo = System.Text.Encoding.GetEncoding("latin1").GetString(tagBytes, 3, 30).TrimEnd('\0');//llamo el get encoding para poder leer los datos de tag bytes y uso get string para pasar bytes a string, trim end para borrar lo que marca
            Artista = System.Text.Encoding.GetEncoding("latin1").GetString(tagBytes, 33, 30).TrimEnd('\0');
            Album = System.Text.Encoding.GetEncoding("latin1").GetString(tagBytes, 63, 30).TrimEnd('\0');//el primer numero es el indice donde esta el byte en la tabla
            Anio = System.Text.Encoding.GetEncoding("latin1").GetString(tagBytes, 93, 4).TrimEnd('\0');
            Comentario = System.Text.Encoding.GetEncoding("latin1").GetString(tagBytes, 97, 30).TrimEnd('\0');
            Genero = tagBytes[127];
        }

            public static Id3v1tag LeerArchivo(string rutaArchivo) {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length > 128)
                    {
                        byte[] tagByte = new byte[128];
                        fs.Seek(-128, SeekOrigin.End);
                        fs.Read(tagByte, 0, 128);

                        string header = System.Text.Encoding.GetEncoding("latin1").GetString(tagByte, 0, 3);
                        if (header == "TAG")
                        {
                            return new Id3v1tag(tagByte);
                        }
                        else
                        {
                            throw new Exception("El archivo no contiene un tag ID3v1 válido.");
                        }
                    }
                    else
                    {
                        throw new Exception("El archivo es demasiado pequeño para contener un tag ID3v1.");
                    }
                }
            }
    }

}