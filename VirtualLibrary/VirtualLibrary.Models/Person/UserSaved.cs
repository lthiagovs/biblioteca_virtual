using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualLibrary.Domain.Models.Library;

namespace VirtualLibrary.Domain.Models.Person
{
    public class UserSaved
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID {  get; set; }

        [ForeignKey(nameof(Book))]
        public int BookID {  get; set; }

        public User? User {  get; set; }

        public Book? Book {  get; set; }

    }
}
