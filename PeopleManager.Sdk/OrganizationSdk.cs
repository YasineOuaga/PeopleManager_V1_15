using System.Net.Http.Json;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.Model;
using Vives.Services.Model.Extensions;

namespace PeopleManager.Sdk
{
    public class OrganizationSdk(IHttpClientFactory httpClientFactory)
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        //Find
        public async Task<ServiceResult<IList<OrganizationResult>>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = "Organizations";
            var response = await httpClient.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<IList<OrganizationResult>>>();
            if (result is null)
            {
                return new ServiceResult<IList<OrganizationResult>>() { Data = new List<OrganizationResult>() };
            }

            return result;
        }

        //Get

        //Create

        //Update
        public async Task<ServiceResult<OrganizationResult>> Update(int id, OrganizationRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = $"Organizations/{id}";
            var response = await httpClient.PutAsJsonAsync(route, request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                result = new ServiceResult<OrganizationResult>();
                result.NotFound(nameof(OrganizationResult), id);
            }

            return result;
        }

        //Delete
    }
}
