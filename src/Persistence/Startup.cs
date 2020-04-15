using Application.Query.Transaction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Command.Contexts;
using Persistence.Command.Repositories;
using Persistence.Queries.Transaction;

namespace Persistence
{
    public static class Startup
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<AppTransactionContext>();
            services.AddSingleton<AppAccountContext>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountQuery, AccountQuery>();
        }
    }
}
