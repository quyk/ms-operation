using Microsoft.Extensions.DependencyInjection;
using MS.Operation.Infrastructure.Interfaces;
using MS.Operation.Infrastructure.Repositories;

namespace MS.Operation.Infrastructure.IoC.Providers
{
    public static class RepositoryProvide
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISetupRepository, SetupRepository>();
        }
    }
}
