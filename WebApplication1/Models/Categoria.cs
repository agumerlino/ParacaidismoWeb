namespace WebApplication1.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string nombre { get; set; } 
        public string descripcion { get; set; }
        public ICollection<Producto> productos { get; set; }
    }
}
