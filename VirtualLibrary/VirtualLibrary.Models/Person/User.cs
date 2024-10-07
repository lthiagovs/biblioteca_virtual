namespace VirtualLibrary.Domain.Models.Person
{
    public class User
    {

        public int ID { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Password {  get; set; } = String.Empty;

        public string Description {  get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

    }

}
