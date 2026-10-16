using LibreriaApp2026.Datos;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class EditorialServicio:IEditorialServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditorialServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EditorialListDto> ObtenerTodas()
        {
            var lista = _unitOfWork.Editoriales.ObtenerTodos();
            return lista.Select(EditorialMapper.ToEditorialListDto).ToList();
        }

        public void Guardar(EditorialCreateDto editorialDto)
        {
            var editorial = EditorialMapper.ToEditorial(editorialDto);
            _unitOfWork.Editoriales.Agregar(editorial);
            _unitOfWork.SaveChanges();
        }

        public void Editar(EditorialUpdateDto editorialDto)
        {
            var editorial = EditorialMapper.ToEditorial(editorialDto);
            _unitOfWork.Editoriales.Editar(editorial, editorial.Id);
            _unitOfWork.SaveChanges();
        }

        public void Borrar(int id)
        {
            
            if (_unitOfWork.Editoriales.TieneLibrosAsociados(id))
            {
                throw new InvalidOperationException("No se puede eliminar una editorial que tiene libros asociados.");
            }

            _unitOfWork.Editoriales.Borrar(id);
            _unitOfWork.SaveChanges();
        }

        public bool Existe(EditorialCreateDto editorialDto)
        {
            return _unitOfWork.Editoriales.Existe(e => e.Nombre.ToLower() == editorialDto.Nombre.ToLower());
        }
    }
}
