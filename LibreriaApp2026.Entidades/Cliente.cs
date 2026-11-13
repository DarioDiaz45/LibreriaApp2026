using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LibreriaApp2026.Entidades
{
    public class Cliente
    {
        private string _nombre = null!;
        private string _apellido = null!;
        private string? _telefono;
        private string? _email;
       

        public int ClienteId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre no puede superar los 50 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El apellido no puede superar los 50 caracteres.", nameof(value));
                }

                _apellido = value.Trim();
            }
        }

       

        public string? Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _telefono = null;
                    return;
                }

                string tel = value.Trim();

                if (tel.Length > 30)
                {
                    throw new ArgumentException("El teléfono no puede superar los 30 caracteres.", nameof(value));
                }

                _telefono = tel;
            }
        }

        public string? Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _email = null;
                    return;
                }

                string emailLimpio = value.Trim();

                if (emailLimpio.Length > 100)
                {
                    throw new ArgumentException("El email no puede superar los 100 caracteres.", nameof(value));
                }

                
                if (!Regex.IsMatch(emailLimpio, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("El formato del email no es válido.", nameof(value));
                }

                _email = emailLimpio;
            }
        }

       

       
       

        
        

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;
        public List<Venta> Ventas { get; set; } = new();
    }
}
