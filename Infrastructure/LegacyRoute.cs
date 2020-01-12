using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace webapp.Infrastructure {


    public class LegacyRoute : IRouter {

        private string[] urls;
        private IRouter mvcRoute;

        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            //public LegacyRoute(params string[] targetUrls) {
            this.urls = targetUrls;
            //mvcRoute = services.GetRequiredService<MvcRouteHandler>();
        }

        //public Task RouteAsync(RouteContext context) {
        public async Task RouteAsync(RouteContext context)
        {

            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');

            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);
            }

            //if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase)) {
            // context.Handler = async ctx => {
            //  HttpResponse response = ctx.Response;
            //  byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
            //  await response.Body.WriteAsync(bytes, 0, bytes.Length);
            // };
            //}
            //return Task.CompletedTask;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context) {
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }
            return null;
        }

    }

}