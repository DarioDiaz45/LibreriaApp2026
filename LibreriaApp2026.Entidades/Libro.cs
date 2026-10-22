namespace LibreriaApp2026.Entidades
{
    public class Libro
    {
        private string _isbn = null!;
        private string _titulo = null!;
        private int _anioPublicacion;
        private int _stock;
        private decimal _precio;
        private int _editorialId;
        public byte[] RowVersion { get; set; } = null!;
        public int Id { get; set; }
        public string ISBN
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ISBN no puede estar vacío.",nameof(value));
                }
                _isbn = value;
            }
        }
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El título no puede estar vacío.",nameof(value));
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
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }
                _stock = value;
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
        public virtual Editorial Editorial { get; set; } = null!;
        public virtual ICollection<Autor> Autores { get; set; } = new List<Autor>();
        public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
        public Libro()
        {

        }
        public Libro(string isbn, string titulo, int anioPublicacion, int stock, decimal precio, int editorialId, string? descripcion = null)
        {
            ISBN = isbn;
            Titulo = titulo;
            AnioPublicacion = anioPublicacion;
            Stock = stock;
            Precio = precio;
            EditorialId = editorialId;
            Descripcion = descripcion;
        }
        public string MostrarDatos()
        {
            return $"ISBN: {ISBN}, Título: {Titulo}, Año de Publicación: {AnioPublicacion}, Stock: {Stock}, Precio: {Precio:C}, Editorial: {Editorial?.Nombre ?? "N/A"}, Descripción: {Descripcion ?? "N/A"}";
        }
    }
}
