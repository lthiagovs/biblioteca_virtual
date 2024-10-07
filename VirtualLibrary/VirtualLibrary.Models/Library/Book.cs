using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Domain.Models.Library
{
    public class Book
    {

        public int ID { get; set; }

        public string Title {  get; set; } = string.Empty;

        public string Description {  get; set; } = string.Empty;

        public string Category {  get; set; } = string.Empty;

        public int AuthorID { get; set; }

        public User? Author {  get; set; }
        

    }

}
