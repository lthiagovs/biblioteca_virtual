using Newtonsoft.Json;
using RestSharp;
using VirtuaLibrary.Services.ApiService.Interface;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Consume
{
    public class BookApiService : IBookApiService
    {

        private readonly RestClient _client;

        public BookApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateBook(Book book)
        {
            var request = new RestRequest("Book/CreateBook", Method.Post);
            var bookSerialized = JsonConvert.SerializeObject(book);

            request.AddParameter("book", bookSerialized);

            var response = await this._client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<bool> DeleteBook(Book book)
        {
            var request = new RestRequest("Book/DeleteBook", Method.Delete);

            var bookSerialized = JsonConvert.SerializeObject(book);

            request.AddParameter("book", bookSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var request = new RestRequest("Book/GetAllBooks", Method.Get);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<Book>? getBooks = JsonConvert.DeserializeObject<List<Book>>(response.Content);

            if (getBooks == null)
                throw new Exception("Something went wrong");

            return getBooks;
        }

        public async Task<Book?> GetBookByID(int ID)
        {
            var request = new RestRequest("Book/GetBookByID", Method.Get);
            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            Book? getBook = JsonConvert.DeserializeObject<Book?>(response.Content);

            if (getBook == null)
                throw new Exception("Something went wrong");

            return getBook;
        }

        public async Task<List<Book>> GetBooksByAuthor(User user)
        {
            var request = new RestRequest("Book/GetAllBooksByAuthor", Method.Get);

            string userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("author", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<Book>? getBooks = JsonConvert.DeserializeObject<List<Book>>(response.Content);

            if (getBooks == null)
                throw new Exception("Something went wrong");

            return getBooks;
        }

        public async Task<List<Book>> GetBooksByTitle(string title)
        {

            var request = new RestRequest("Book/GetBooksByTitle", Method.Get);

            request.AddParameter("title", title);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<Book>? getBooks = JsonConvert.DeserializeObject<List<Book>>(response.Content);

            if (getBooks == null)
                throw new Exception("Something went wrong");

            return getBooks;
            
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var request = new RestRequest("Book/UpdateBook", Method.Put); // 

            var bookSerialized = JsonConvert.SerializeObject(book);

            request.AddParameter("book", bookSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }
    }

}
