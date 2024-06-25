using WebApplication1.Models;

namespace WebApplication1.Services
{
    public static class AdminService
    {
        private static Usuario admin = new Usuario
        {
            User = "admin",
            Password = "pass", // Aquí deberías usar una forma segura de almacenar contraseñas en producción
        };

        public static Usuario ObtenerAdmin()
        {
            return admin;
        }
    }
}
