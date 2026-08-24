using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using MyBookShelf.WebForms.Helpers;
using MyBookShelf.WebForms.Infrastructure.DI;

namespace MyBookShelf.WebForms
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        #region Fields

        static IContainerProvider _containerProvider;

        #endregion

        #region Properties

        public IContainerProvider ContainerProvider => _containerProvider;

        #endregion

        #region Start

        void Application_Start(object sender, EventArgs e)
        {
            // DI by Autofac
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new DependencyModule());
            _containerProvider = new ContainerProvider(builder.Build());

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = Request.AppRelativeCurrentExecutionFilePath;
            if (path == $"~/") Response.NavigateTo(AppPages.Default);
        }

        #endregion
    }
}