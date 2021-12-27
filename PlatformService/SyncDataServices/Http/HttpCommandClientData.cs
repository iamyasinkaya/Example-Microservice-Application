using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandClientData : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandClientData(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platformReadDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platformReadDto),
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}/api/c/platforms", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was Ok");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService wasn't Ok");
            }

        }
    }
}
