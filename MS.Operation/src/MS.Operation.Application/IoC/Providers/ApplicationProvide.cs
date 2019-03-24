using Microsoft.Extensions.DependencyInjection;
using MS.Operation.Application.Interfaces;
using MS.Operation.Application.Services;

namespace MS.Operation.Application.IoC.Providers
{
    public class ApplicationProvide
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<ITransferService, TransferService>();
        }
    }
}
