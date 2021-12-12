using Microsoft.EntityFrameworkCore;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public class UserEventsApiDbContext : DbContext
    {
        public UserEventsApiDbContext(DbContextOptions<UserEventsApiDbContext> options) : base(options)
        {

        }

        public DbSet<UserEvent> UserEvents { get; set; }

    }
}
