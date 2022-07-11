using BookSearch.Business.Services.Interfaces;
using BookSearch.WebApi.Tests.Stubs;
using Ninject.Modules;

namespace BookSearch.WebApi.Tests.Configurations
{
    internal class ConfigBookService : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<StubBookService>();
        }
    }
}
