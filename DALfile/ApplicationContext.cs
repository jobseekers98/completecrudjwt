using Microsoft.EntityFrameworkCore;
using MODELfile;
using System;

namespace DALfile
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<UserModel> Users { get; set; }

    }
}
