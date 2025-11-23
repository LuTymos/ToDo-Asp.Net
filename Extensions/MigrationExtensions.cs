using Microsoft.EntityFrameworkCore;
using Lucas.Api.ToDo.Data;
using MySqlConnector;
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

                Console.WriteLine("Esperando 5 segundos para o banco de dados iniciar...");
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

                try
                {
                    Console.WriteLine("Tentando conectar e criar o banco de dados (Retry logic)...");

                    int tentativas = 10;
                    TimeSpan tempoEspera = TimeSpan.FromSeconds(3);

                    for (int i = 0; i < tentativas; i++)
                    {
                        try
                        {
                            dbContext.Database.CanConnect();
                            dbContext.Database.EnsureCreated();
                            Console.WriteLine("Banco de dados conectado e tabelas criadas com sucesso!");
                            break;
                        }
                        catch (MySqlException)
                        {
                            if (i == tentativas - 1) throw;

                            Console.WriteLine($"Tentativa {i + 1} de {tentativas}. Banco indisponível. Esperando 3 segundos...");
                            System.Threading.Thread.Sleep(tempoEspera);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro na conexão (não-MySQL). Tentativa {i + 1}. Erro: {ex.Message}");
                            if (i == tentativas - 1) throw;
                            System.Threading.Thread.Sleep(tempoEspera);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO FATAL: Falha crítica ao iniciar o banco de dados. {ex.Message}");
                }
            }
            return host;
        }
    }
}