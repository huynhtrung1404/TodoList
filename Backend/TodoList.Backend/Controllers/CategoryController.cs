using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Backend.Controllers
{
    public class CategoryController : ApiBaseController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }
    }
}
