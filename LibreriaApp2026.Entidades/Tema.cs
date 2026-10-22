namespace LibreriaApp2026.Entidades
{
    public class Tema
    {
        private string _nombre = null!;
        public byte[] RowVersion { get; set; } = null!;
        public int Id { get; set; }
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del tema no puede estar vacío.");
                }
                _nombre = value;
            }
        }
        public string? Descripcion { get; set; } 
        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
        public Tema()
        {
           
        }
        public Tema(string nombre, string? descripcion = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
