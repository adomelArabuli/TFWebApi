using Ninject.Modules;
using Ninject.Web.Common;
using TFWebApi.Data;
using TFWebApi.Interfaces;
using TFWebApi.Services;

namespace TFWebApi
{
    public class DependencyModule : NinjectModule
    {
        private readonly IConfiguration _configuration;

        public DependencyModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Load()
        {
            Bind<IConfiguration>().ToConstant(_configuration);
            Bind<ILectorService>().To<LectorService>();
            Bind<IDatabaseService>().To<DatabaseService>().InSingletonScope();
            Bind<ApplicationDbContext>().ToSelf().InRequestScope();
        }
    }
}
