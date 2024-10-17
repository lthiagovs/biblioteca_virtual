using System.ComponentModel.DataAnnotations;

namespace VirtualLibrary.Domain.Models.Library
{
    public class Category
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

    }
}
