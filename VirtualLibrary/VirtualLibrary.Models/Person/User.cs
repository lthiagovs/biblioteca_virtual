using System.ComponentModel.DataAnnotations;

namespace VirtualLibrary.Domain.Models.Person
{
    public class User
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Password {  get; set; } = String.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description {  get; set; } = String.Empty;

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; } = String.Empty;

    }

}
