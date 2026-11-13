namespace LibreriaApp2026.Entidades
{
    public class DetalleVenta
    {
        public int VentaId { get; private set; }
        public Venta Venta { get; private set; } = null!;

        public int LibroId { get; private set; }
        public Libro Libro { get; private set; } = null!;

        public decimal Precio { get; private set; }
        public int Cantidad { get; private set; }

        public decimal Subtotal => Precio * Cantidad;

        private DetalleVenta() { } 

        public DetalleVenta(int libroId, int cantidad, decimal precio)
        {
            if (libroId <= 0)
                throw new ArgumentOutOfRangeException(nameof(libroId));

            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad));

            if (precio < 0)
                throw new ArgumentOutOfRangeException(nameof(precio));

            LibroId = libroId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
