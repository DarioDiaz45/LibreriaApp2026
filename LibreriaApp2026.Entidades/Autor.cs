namespace LibreriaApp2026.Entidades
{
    public class Autor
    {
        private string _nombre = null!;
        private string _apellido = null!;
        private string _nacionalidad = null!;
        private DateTime _fechaNacimiento;
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del autor no puede estar vacío.");
                }
                _nombre = value;
            }
        }
        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido del autor no puede estar vacío.");
                }
                _apellido = value;
            }
        }
        public string Nacionalidad
        {
            get => _nacionalidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La nacionalidad del autor no puede estar vacía.");
                }
                _nacionalidad = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La fecha de nacimiento no puede ser una fecha futura.");
                }

                _fechaNacimiento = value;
            }
        } 
        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();

        public Autor()
        {

        }
        public Autor(string nombre, string apellido, string nacionalidad, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
        }
    }
    
}
