using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BupaApp.Interfaces;
using BupaApp.Data;
using Microsoft.Extensions.Options;
using BupaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http.Headers;

namespace BupaApp.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly string _baseUrl;

        public VehicleRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;

            _baseUrl = _apiSettings.BaseUrl;
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiSettings.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        [HttpGet]
        public async Task<List<Vehicle>> GetVehicle(string plate)
        {
            var requestUrl = _baseUrl + plate;
            var response = await _httpClient.GetAsync(requestUrl);            

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                try 
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    // Deserialize as a list of Vehicle objects
                    return JsonSerializer.Deserialize<List<Vehicle>>(jsonResponse, options);
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message, ex);
                }
                
            }
            else 
            {
                throw new HttpRequestException($"Failed to fetch vehicle details: {response.ReasonPhrase}");
            }
        }
    }
}