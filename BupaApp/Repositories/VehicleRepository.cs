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

namespace BupaApp.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public VehicleRepository(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;

            _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiSettings.ApiKey}");
        }

        [HttpGet]
        public async Task<Vehicle> GetVehicle(string plate)
        {
           var response = await _httpClient.GetAsync($"{plate}");

           if (response.IsSuccessStatusCode)
           {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Vehicle>(jsonResponse);
           }
           else 
           {
                throw new HttpRequestException($"Failed to fetch vehicle details: {response.ReasonPhrase}");
           }
        }
    }
}