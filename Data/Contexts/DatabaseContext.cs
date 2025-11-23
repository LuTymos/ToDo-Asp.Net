using Microsoft.EntityFrameworkCore;

namespace Lucas.Api.ToDo.Data.Contexts
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
