using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correoElectronico { get; set; }
        public string contraseña { get; set; }
        public string nombreCompleto => $"{nombre} {apellido}";
        public int telefono { get; set; }

    }
}
