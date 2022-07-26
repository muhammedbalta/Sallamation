using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sallamation.Shared.DTOs;

namespace Sallamation.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterFormModel registerFormModel)
        {
            if (registerFormModel == null || !ModelState.IsValid) return BadRequest();
            var user = new IdentityUser { UserName = registerFormModel.UserName, Email = registerFormModel.Email };
            var result = await _userManager.CreateAsync(user, registerFormModel.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            return StatusCode(201);
        }

    }

}