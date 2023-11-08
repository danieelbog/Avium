using Microsoft.EntityFrameworkCore;

//        Cmdlet                      Description
//        --------------------------  ---------------------------------------------------
//        Add-Migration		          Adds a new migration.
//        Remove- Migration           Removes the last migration.
//        Scaffold-DbContext	      Scaffolds a DbContext and entity type classes for a specified database.
//        Script-Migration	          Generates a SQL script from migrations.
//        Update-Database		      Updates the database to a specified migration.
//        Use-DbContext               Sets the default DbContext to use.

namespace Web.EntityFramework.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasDefaultSchema("");
            base.OnModelCreating(builder);
        }
    }
}
