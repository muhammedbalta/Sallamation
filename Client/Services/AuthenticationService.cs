using System.Text;
using System.Text.Json;
using Sallamation.Shared.DTOs;

namespace Sallamation.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public AuthenticationService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<RegistrationResponseDto> RegisterUser(RegisterFormModel registerFormModel)
        {
            var content = JsonSerializer.Serialize(registerFormModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var registrationResult = await _client.PostAsync("http://localhost:7108/api/accounts/registration", bodyContent);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();
            if (!registrationResult.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
                return result;
            }

            return new RegistrationResponseDto { IsSuccessfulRegistration = true };

        }
    }

}