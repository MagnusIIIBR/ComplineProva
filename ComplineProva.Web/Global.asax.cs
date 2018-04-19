using ComplineProva.Data.Context;
using System;
using System.Web;

namespace ComplineProva.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new ComplineDataContext();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as ComplineDataContext;
            if (entityContext != null)
                entityContext.Dispose();
        }
    }
}
