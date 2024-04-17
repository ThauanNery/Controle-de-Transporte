using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Transporte.Controllers
{
    public class SwaggerController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("/swagger/index.html");
        }
    }
}
