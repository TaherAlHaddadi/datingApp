using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext//used as service
    {
        // to create a connection string to the database, need to create a constructor
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }// inject this datacontext into other class, then have an access to all methods

        public DbSet<AppUser> Users { get; set; }// create a table with given name User
    }
}