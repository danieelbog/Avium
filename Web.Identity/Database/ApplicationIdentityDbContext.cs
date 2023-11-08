using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Core.Models.User;

//        Cmdlet                      Description
//        --------------------------  ---------------------------------------------------
//        Add-Migration		          Adds a new migration.
//        Remove- Migration           Removes the last migration.
//        Scaffold-DbContext	      Scaffolds a DbContext and entity type classes for a specified database.
//        Script-Migration	          Generates a SQL script from migrations.
//        Update-Database		      Updates the database to a specified migration.
//        Use-DbContext               Sets the default DbContext to use.

namespace Web.IdentityFramework.Database
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>, IApplicationIdentityDbContext
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}