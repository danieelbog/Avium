using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.BFF.Core.Models;

//        Cmdlet                      Description
//        --------------------------  ---------------------------------------------------
//        Add-Migration		          Adds a new migration.
//        Remove- Migration           Removes the last migration.
//        Scaffold-DbContext	      Scaffolds a DbContext and entity type classes for a specified database.
//        Script-Migration	          Generates a SQL script from migrations.
//        Update-Database		      Updates the database to a specified migration.
//        Use-DbContext               Sets the default DbContext to use.

namespace WebApp.BFF.Database
{
    public class WebContext : IdentityDbContext<ApplicationUser>
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<LoggingData>()
            //    .Property(e => e.Id)
            //    .ValueGeneratedOnAdd();
        }
    }
}