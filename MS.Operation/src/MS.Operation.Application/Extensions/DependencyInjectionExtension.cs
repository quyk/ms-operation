using Microsoft.Extensions.DependencyInjection;
using MS.Operation.Application.IoC.Providers;
using MS.Operation.Infrastructure.IoC.Providers;

namespace MS.Operation.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void Core(this IServiceCollection serviceCollection)
        {
            #region Application
            ApplicationProvide.Register(serviceCollection);
            #endregion

            #region Infrastructure
            RepositoryProvide.Register(serviceCollection);
            #endregion
        }
    }
}