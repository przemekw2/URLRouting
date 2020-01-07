using Microsoft.AspNetCore.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    public class CustomerController : Controller {
        public ViewResult Index() => View("Result",
            new Result {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
        public ViewResult List() => View("Result",
            new Result {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            });

    }

}