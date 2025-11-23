using Microsoft.EntityFrameworkCore;
using Lucas.Api.ToDo.Data.Contexts;

namespace Lucas.Api.ToDo.Extensions
{
    public static class MigrationExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<DatabaseContext>();

                try
                {
                    Console.WriteLine("Tentando conectar e criar o banco de dados (Retry logic)...");

                    int tentativas = 10;
                    TimeSpan tempoEspera = TimeSpan.FromSeconds(3);

                    for (int i = 0; i < tentativas; i++)
                    {
                        try
                        {
                            if (dbContext.Database.CanConnect())
                            {
                                dbContext.Database.EnsureCreated();
                                Console.WriteLine("Banco de dados conectado e tabelas criadas com sucesso!");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            if (i == tentativas - 1) throw; 

                            Console.WriteLine($"Tentativa {i + 1} de {tentativas}. Banco indisponível. Esperando 3 segundos...");
                            System.Threading.Thread.Sleep(tempoEspera);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO FATAL: Falha ao conectar/criar o banco de dados. {ex.Message}");
                }
            }
            return host;
        }
    }
}