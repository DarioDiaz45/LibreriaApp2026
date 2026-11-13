namespace LibreriaApp2026.Entidades
{
    public abstract class Libro
    {
        private string _titulo = null!;
        private int _anioPublicacion;
        private decimal _precio;
        private int _editorialId;

        public int Id { get; set; }

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El título no puede estar vacío.", nameof(value));
                }
                _titulo = value;
            }
        }

        public string? Descripcion { get; set; }

        public int AnioPublicacion
        {
            get => _anioPublicacion;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El año de publicación no puede ser negativo.");
                }
                _anioPublicacion = value;
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");
                }
                _precio = value;
            }
        }

        public int EditorialId
        {
            get => _editorialId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El ID de la editorial debe ser un número positivo.");
                }
                _editorialId = value;
            }
        }

        public bool Activo { get; set; } = true;
        public byte[] RowVersion { get; set; } = null!;

        public virtual Editorial Editorial { get; set; } = null!;
        public virtual ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
        public List<DetalleVenta> DetalleVentas { get; set; } = new();


        public abstract string TipoDescripcion { get; }
        public abstract bool TieneDisponibilidad();


        public bool SePuedeVender()
        {
            return Activo && Editorial is { Activo: true } && TieneDisponibilidad();
        }
    }
}
