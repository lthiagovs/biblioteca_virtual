using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Domain.Models.Library
{
    public class Book
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title {  get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description {  get; set; } = string.Empty;

        [ForeignKey(nameof(Category))]
        public int CategoryID {  get; set; }

        public Category Category {  get; set; }


        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }

        public User? Author {  get; set; }
        

    }

}
