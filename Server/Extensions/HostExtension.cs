using Microsoft.EntityFrameworkCore;
using Npgsql;
using Sallamation.Server.Data;

namespace Sallamation.Server.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    using (var context = services.GetRequiredService<SallamationContext>())
                    {
                        context.Database.Migrate();
                    }
                }
                catch (NpgsqlException ex)
                {

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }

            return host;
        }
    }

}