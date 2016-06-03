using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Taxes.Classes;
using Taxes.Models;


namespace Taxes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Con esto hago la emigración de los datos:
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaxesContext,Migrations.Configuration>());

            //Métodos para maneja roles:
            this.CheckRoles();

            //Método que mirea si existe un SuperUsuario:
            Utilities.CheckSuperUser();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

     

        private void CheckRoles()
        {
            Utilities.CheckRole("Admin");
            Utilities.CheckRole("Employee");
            Utilities.CheckRole("TaxPaer");
        }
    }
}
