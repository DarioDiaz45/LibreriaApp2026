using LibreriaApp2026.Servicios.DTOs.DetalleVenta;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Windows.Classes
{
    public class EditorVenta
    {
        private readonly VentaCreateDto _ventaDto;

        public EditorVenta(VentaCreateDto ventaDto)
        {
            _ventaDto = ventaDto;
        }

        public void AgregarLibro(DetalleVentaDto detalleDto)
        {
            if (detalleDto is null)
                throw new ArgumentNullException(nameof(detalleDto), "El detalle no puede ser nulo");

            
            var otraVersion = _ventaDto.Detalle.FirstOrDefault(d =>
                d.LibroId != detalleDto.LibroId &&
                string.Equals(d.Libro.Trim(), detalleDto.Libro.Trim(),
                              StringComparison.OrdinalIgnoreCase));

            if (otraVersion is not null)
                throw new InvalidOperationException(
                    $"\"{detalleDto.Libro}\" ya está en la venta en otra versión (físico o digital). " +
                    "No se puede agregar el mismo libro en los dos formatos.");

            var existente = _ventaDto.Detalle
                .FirstOrDefault(d => d.LibroId == detalleDto.LibroId);

            if (existente is null)
            {
                _ventaDto.Detalle.Add(detalleDto);
                return;
            }

            int nuevaCantidad = existente.Cantidad + detalleDto.Cantidad;
            if (existente.Stock.HasValue && nuevaCantidad > existente.Stock.Value)
                throw new InvalidOperationException(
                    $"No hay stock suficiente de \"{existente.Libro}\". " +
                    $"Disponible: {existente.Stock}, en la venta: {existente.Cantidad}.");

            existente.Cantidad = nuevaCantidad;
        }

        public void EliminarLibro(int libroId)
        {
            if (libroId <= 0)
                throw new ArgumentException("El ID del libro debe ser mayor a cero");

            var detalle = _ventaDto.Detalle.FirstOrDefault(d => d.LibroId == libroId);
            if (detalle is null)
                throw new InvalidOperationException($"El libro ID {libroId} no se encuentra en el detalle");

            _ventaDto.Detalle.Remove(detalle);
        }

        public void ModificarCantidad(int libroId, int cantidad)
        {
            if (libroId <= 0)
                throw new ArgumentException("El ID del libro debe ser mayor a cero");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero");

            var detalle = _ventaDto.Detalle.FirstOrDefault(d => d.LibroId == libroId);
            if (detalle is null)
                throw new InvalidOperationException($"El libro ID {libroId} no se encuentra en el detalle");

            if (detalle.Stock.HasValue && cantidad > detalle.Stock.Value)
                throw new InvalidOperationException(
                    $"La cantidad supera el stock disponible ({detalle.Stock}).");

            detalle.Cantidad = cantidad;
        }

        internal List<DetalleVentaDto> ObtenerDetalles() => _ventaDto.Detalle;

        internal (IReadOnlyCollection<DetalleVentaDto> Detalles, decimal Total) ObtenerResumen()
        {
            var detalles = _ventaDto.Detalle;
            return (detalles, detalles.Sum(d => d.Subtotal));
        }
    }
}
