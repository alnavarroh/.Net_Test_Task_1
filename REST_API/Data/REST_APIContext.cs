using Microsoft.EntityFrameworkCore;
using REST_API.Model;

namespace REST_API.Data
{
    public class REST_APIContext : DbContext
    {
        public REST_APIContext (DbContextOptions<REST_APIContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
