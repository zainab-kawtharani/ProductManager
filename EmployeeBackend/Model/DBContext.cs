using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBackend.Model
{
    public class DBContext:IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) {
        }

        public DbSet<Product> Products { get; set;}

    }
}
