using Sallamation.Shared.DTOs;

namespace Sallamation.Client.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(RegisterFormModel registerFormModel);
    }

}