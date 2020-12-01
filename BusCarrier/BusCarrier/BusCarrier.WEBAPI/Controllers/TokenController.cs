using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusCarrier.WEBAPI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BusCarrier.WEBAPI.Controllers
{
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private readonly UserManager<IdentityUser<int>> userManager;

        public TokenController(UserManager<IdentityUser<int>> userManager)
        {
            this.userManager = userManager;
        }

        [Route("/token")]
        [HttpGet]
        public async Task<IActionResult> Create(string email, string password)
        {
            if (await IsValidUsernameAndPassword(email, password))
            {
                return new ObjectResult(await GenerateToken(email));
            }

            return BadRequest("Invalid username or password");
        }

        private async Task<bool> IsValidUsernameAndPassword(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            return await userManager.CheckPasswordAsync(user, password);
        }

        private async Task<IActionResult> GenerateToken(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) 
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: DateTime.UtcNow,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = email
            };

            return Json(response);
        }
    }
}
