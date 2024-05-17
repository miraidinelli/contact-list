using Microsoft.EntityFrameworkCore;
using Teste8Q.Models;

namespace Teste8Q.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
