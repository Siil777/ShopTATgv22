using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Authorize]
    public class ChatHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
