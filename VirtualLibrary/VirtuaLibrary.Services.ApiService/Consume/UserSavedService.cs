using Newtonsoft.Json;
using RestSharp;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;
using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Consume
{
    public class UserSavedApiService : IUserSavedApiService
    {
        private readonly RestClient _client;

        public UserSavedApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<List<Book>> GetAllUserSavedBooks(int ID)
        {
            var request = new RestRequest("UserSaved/GetAllUserSavedBooks", Method.Get);
            request.AddParameter("ID", ID);

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

        public async Task<bool> UserSaveBook(UserSaved saved)
        {
            var request = new RestRequest("UserSaved/UserSaveBook", Method.Post);

            request.AddJsonBody(saved);

            var response = await this._client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

    }
}
