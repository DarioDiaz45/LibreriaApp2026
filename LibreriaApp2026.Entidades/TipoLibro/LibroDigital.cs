namespace LibreriaApp2026.Entidades.TipoLibro
{
    public class LibroDigital:Libro
    {
        private string _identificador = null!;
        private string _formato = null!;
        private long _tamanoArchivo;
        private string _urlDescarga = null!;

        public string Identificador
        {
            get => _identificador;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El identificador no puede estar vacío.", nameof(value));
                }
                _identificador = value;
            }
        }

        public string Formato
        {
            get => _formato;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El formato no puede estar vacío.", nameof(value));
                }
                _formato = value;
            }
        }

        
        public long TamanoArchivo
        {
            get => _tamanoArchivo;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El tamaño del archivo debe ser mayor a cero.");
                }
                _tamanoArchivo = value;
            }
        }

        public string UrlDescarga
        {
            get => _urlDescarga;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La URL de descarga no puede estar vacía.", nameof(value));
                }
                _urlDescarga = value;
            }
        }

        public override string TipoDescripcion => "Digital";

        
        public override bool TieneDisponibilidad()
        {
            return true;
        }
    }
}
