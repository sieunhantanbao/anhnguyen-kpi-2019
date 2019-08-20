using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SD2411.KPI2019.Infrastructure.Configurations;
using SD2411.KPI2019.Module.Core.Model;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Core.Controllers
{
    [Route("authentication")]
    public class AuthenticateController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("generate-token")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            // Find user bt Email
            var user = await _userManager.FindByEmailAsync(model.Email);
            // Check if correct password - then process
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtAuthenticateOptions.SecurityKey));

                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                        issuer: JwtAuthenticateOptions.Issuser,
                        audience: JwtAuthenticateOptions.Audience,
                        expires: DateTime.Now.AddHours(6),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            // If not
            return Unauthorized();
        }
    }
}
