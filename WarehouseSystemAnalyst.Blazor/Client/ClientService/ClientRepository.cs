using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Blazor.Client.ClientService
{

    public class ClientRepository<TDto> : IClientRepository<TDto>
        where TDto : class, IBaseDto, new()
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerSettings serializerSettings;
        public ClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public string ControllerName { get; set; }

        public async Task<SingleResponse<TDto>> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"{ControllerName}/{id}");

            result.EnsureSuccessStatusCode();
            var responseBody = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SingleResponse<TDto>>(responseBody, serializerSettings);
        }

        public async Task<ListResponse<TDto>> GetAllAsync()
        {
            try
            {

                var result = await _httpClient.GetAsync(ControllerName);
                result.EnsureSuccessStatusCode();

                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ListResponse<TDto>>(responseBody, serializerSettings);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SingleResponse<TDto>> GetByIdAsync(string id)
        {
            var result = await _httpClient.GetAsync($"{ControllerName}/{id}");

            result.EnsureSuccessStatusCode();
            var responseBody = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SingleResponse<TDto>>(responseBody, serializerSettings);
        }

        public async Task<SingleResponse<TDto>> PostAsync(TDto createdObject)
        {
            var result = await _httpClient.PostAsJsonAsync(ControllerName, createdObject);
            result.EnsureSuccessStatusCode();
            var responseBody = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SingleResponse<TDto>>(responseBody, serializerSettings);
        }

        public async Task<SingleResponse<TDto>> PutAsync(string id, TDto updatedObject)
        {
            var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/{id}", updatedObject);

            result.EnsureSuccessStatusCode();
            var responseBody = await result.Content.ReadAsStringAsync();


            var response = JsonConvert.DeserializeObject<SingleResponse<TDto>>(responseBody, serializerSettings);

            return response;
        }
    }
}
