using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string User { get; set; }
        public string Password { get; set; }

    }
}
