using Lucas.Api.ToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lucas.Api.ToDo.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<TarefaModel> Tarefa { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
