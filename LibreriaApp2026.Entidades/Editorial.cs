namespace LibreriaApp2026.Entidades
{
    public class Editorial
    {
        private string _nombre = null!;
        private string _paisOrigen = null!;

        public int Id { get; set; }
      
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la editorial no puede estar vacío.");
                }
                _nombre = value;
            }
        }
        public string PaisOrigen
        {
            get => _paisOrigen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El país de origen no puede estar vacío.");
                }
                _paisOrigen = value;
            }

        }
        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
        public Editorial()
        {
        }

        
        public Editorial(string nombre, string paisOrigen)
        {
            Nombre = nombre;
            PaisOrigen = paisOrigen;
        }

    }
}
