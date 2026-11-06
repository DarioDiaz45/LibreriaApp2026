using LibreriaApp2026.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Windows.Helpers
{
    public record ItemCombo(int Id, string Texto)
    {
        public override string ToString() => Texto;
    }

    public static class CatalogosHelper
    {
       
        public static List<ItemCombo> Editoriales(IEditorialServicio servicio, string? primero = null)
        {
            var items = new List<ItemCombo>();
            if (primero != null) items.Add(new ItemCombo(0, primero));

            var resultado = servicio.ObtenerTodos();
            if (resultado.IsSuccess)
            {
                items.AddRange(resultado.Value!
                    .OrderBy(e => e.Nombre)
                    .Select(e => new ItemCombo(e.Id, e.Nombre)));
            }
            return items;
        }

        public static List<ItemCombo> Autores(IAutorServicio servicio, string? primero = null)
        {
            var items = new List<ItemCombo>();
            if (primero != null) items.Add(new ItemCombo(0, primero));

            var resultado = servicio.ObtenerTodos();
            if (resultado.IsSuccess)
            {
                items.AddRange(resultado.Value!
                    .OrderBy(a => a.Apellido).ThenBy(a => a.Nombre)
                    .Select(a => new ItemCombo(a.Id, $"{a.Apellido}, {a.Nombre}")));
            }
            return items;
        }

        public static List<ItemCombo> Temas(ITemaServicio servicio, string? primero = null)
        {
            var items = new List<ItemCombo>();
            if (primero != null) items.Add(new ItemCombo(0, primero));

            var resultado = servicio.ObtenerTodos();
            if (resultado.IsSuccess)
            {
                items.AddRange(resultado.Value!
                    .OrderBy(t => t.Nombre)
                    .Select(t => new ItemCombo(t.Id, t.Nombre)));
            }
            return items;
        }

        public static void CargarCombo(ComboBox cbo, List<ItemCombo> items)
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DisplayMember = nameof(ItemCombo.Texto);
            cbo.ValueMember = nameof(ItemCombo.Id);
            cbo.DataSource = items;
            if (items.Count > 0) cbo.SelectedIndex = 0;
        }
    }
}
