using Newtonsoft.Json;
using RestSharp;
using VirtuaLibrary.Services.ApiService.Interfaces;
using VirtualLibrary.Domain.Models.Library;

namespace VirtuaLibrary.Services.ApiService.Consume
{
    public class CategoryApiService : ICategoryApiService
    {

        private readonly RestClient _client;

        public CategoryApiService(RestClient client)
        {
            this._client = client;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            var request = new RestRequest("Category/CreateCategory", Method.Post);
            var categorySerialized = JsonConvert.SerializeObject(category);

            request.AddParameter("category", categorySerialized);

            var response = await this._client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            var request = new RestRequest("Category/DeleteCategory", Method.Delete);

            var categorySerialized = JsonConvert.SerializeObject(category);

            request.AddParameter("category", categorySerialized);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            bool result = JsonConvert.DeserializeObject<bool>(response.Content);

            return result;
        }

        public async Task<Category?> GetCategoryByID(int ID)
        {
            var request = new RestRequest("Category/GetCategoryByID", Method.Get);
            request.AddParameter("ID", ID);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            Category? getCategory = JsonConvert.DeserializeObject<Category>(response.Content);

            if (getCategory == null)
                throw new Exception("Something went wrong");

            return getCategory;
        }

        public async Task<Category?> GetCategoryByName(string name)
        {
            var request = new RestRequest("User/GetUserByLogin", Method.Get);
            request.AddParameter("name", name);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            Category? getCategory = JsonConvert.DeserializeObject<Category>(response.Content);

            if (getCategory == null)
                throw new Exception("Failed to deserialize category from response.");

            return getCategory;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var request = new RestRequest("Category/GetAllCategories", Method.Get);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            if (response.Content == null)
                throw new Exception("Something went wrong.");

            List<Category>? getCategories = JsonConvert.DeserializeObject<List<Category>>(response.Content);

            if (getCategories == null)
                throw new Exception("Something went wrong");

            return getCategories;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var request = new RestRequest("Category/UpdateCategory", Method.Put); // 

            var categorySerialized = JsonConvert.SerializeObject(category);

            request.AddParameter("category", categorySerialized);

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
