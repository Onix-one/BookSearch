using BookSearch.Business.ExternalServices.Interfaces;
using BookSearch.Business.Services.Tests.Stubs;
using BookSearch.DataAccess.Database.Interfaces;
using Ninject.Modules;

namespace BookSearch.Business.Services.Tests.Configurations
{
    internal class ConfigBookRepository : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookRepository>().To<StubBookRepository>();
            Bind<IBookExternalService>().To<StubBookExternalService>();
        }
    }
}
