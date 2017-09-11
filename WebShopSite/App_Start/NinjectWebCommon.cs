[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebShopSite.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebShopSite.App_Start.NinjectWebCommon), "Stop")]

namespace WebShopSite.App_Start
{
    using Application.Categories.Commands;
    using Application.Categories.Queries.GetCategoriesList;
    using Application.GenderA.Commands;
    using Application.GenderA.Queries;
    using Application.ProductA.Commands;
    using Application.ProductA.Queries;
    using global::Ninject;
    using global::Ninject.Web.Common;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System;
    using System.Web;
    using WebShopSite.Utilities;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISaveFilesFromRequest>().To<SaveFilesFromRequest>();
            kernel.Bind<IGetFilesFromRequest>().To<GetFilesFromRequest>();
            kernel.Bind<IGetCategoriesListQuery>().To<GetCategoriesListQuery>();
            kernel.Bind<ICreateCategoryCommand>().To<CreateCategoryCommand>();
            kernel.Bind<IGenderListQuery>().To<GenderListQuery>();
            kernel.Bind<ICommandsGender>().To<CommandsGender>();
            kernel.Bind<IProductsQuery>().To<ProductsQuery>();
            kernel.Bind<ICommandProduct>().To<CommandProduct>();
        }
    }
}
