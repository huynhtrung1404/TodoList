using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Backend.Controllers
{
    public class HomeController : ApiBaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok("AAAAAAA");
        }
    }
}
