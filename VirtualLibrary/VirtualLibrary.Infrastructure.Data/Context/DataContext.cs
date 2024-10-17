using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;


namespace VirtualLibrary.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {

        public required DbSet<User> User { get; set; }

        public required DbSet<Book> Book { get; set; }

        public required DbSet<Category> Category { get; set; }

        public required DbSet<UserSaved> UserSaved {  get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


    }

}
