﻿namespace WebApplication1.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set;}
        public int precio { get; set;}
        public Categoria? categoria { get; set; }
        public string? marca { get; set; }
        public string? foto { get; set; }

    }
}
