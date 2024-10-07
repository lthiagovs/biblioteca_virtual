using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.Context
{
    public class DataContext : DbContext
    {

        public required DbSet<User> User { get; set; }

        public required DbSet<Book> Book {  get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }

}
