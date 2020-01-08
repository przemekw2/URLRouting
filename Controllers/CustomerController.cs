using Microsoft.AspNetCore.Mvc;
using webapp.Models;

namespace webapp.Controllers
{
    [Route("app/[controller]/actions/[action]/{id?}")]
    public class CustomerController : Controller {
        
        public ViewResult Index() => View("Result",
            new Result {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
        public ViewResult List(string id) {
            Result r = new Result {
                Controller = nameof(HomeController),
                Action = nameof(List),
            };
            r.Data["id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }

    }

}