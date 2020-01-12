using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers
{
    public class LegacyController : Controller
    {
        public ViewResult GetLegacyUrl(string legacyUrl)
            => View((object)legacyUrl);
    }
}
