namespace LibreriaApp2026.Entidades.TipoLibro
{
    public class LibroFisico : Libro
    {
        private string _isbn = null!;
        private int _stock;

        public string ISBN
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ISBN no puede estar vacío.", nameof(value));
                }
                _isbn = value;
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

        public override string TipoDescripcion => "Físico";

        public override bool TieneDisponibilidad()
        {
            return Stock > 0;
        }
    }
}
