using Newtonsoft.Json;
using RestSharp;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Person;

namespace VirtuaLibrary.Services.ApiService.Consume
{
    public class UserApiService : IUserApiService
    {

        private readonly RestClient _client;

        public UserApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateUser(User user)
        {
            var request = new RestRequest("User/CreateUser", Method.Post);
            var userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("user", userSerialized);

            var response = await this._client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<bool> DeleteUser(User user)
        {
            var request = new RestRequest("User/DeleteUser", Method.Delete);

            var userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("user", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<User?> GetUserByID(int ID)
        {
            var request = new RestRequest("User/GetUserByID", Method.Get);
            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            User? getUser = JsonConvert.DeserializeObject<User?>(response.Content);

            if (getUser == null)
                throw new Exception("Something went wrong");

            return getUser;
        }

        public async Task<User> GetUserByLogin(string email, string password)
        {
            var request = new RestRequest("User/GetUserByLogin", Method.Get);
            request.AddParameter("email", email);
            request.AddParameter("password", password);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            User? getUser = JsonConvert.DeserializeObject<User>(response.Content);

            if (getUser == null)
                throw new Exception("Failed to deserialize user from response.");

            return getUser;
        }

        public async Task<List<User>> GetUsers()
        {
            var request = new RestRequest("User/GetUsers", Method.Get);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<User>? getUsers = JsonConvert.DeserializeObject<List<User>>(response.Content);

            if (getUsers == null)
                throw new Exception("Something went wrong");

            return getUsers;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var request = new RestRequest("User/UpdateUser", Method.Put); // 

            var userSerialized = JsonConvert.SerializeObject(user);

            request.AddParameter("user", userSerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<bool> UserExist(int ID)
        {
            var request = new RestRequest("User/UserExist", Method.Get);
            request.AddParameter("ID", ID);

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
