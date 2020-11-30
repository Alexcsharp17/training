using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace BusCarrier.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        protected readonly UserManager<IdentityUser<int>> userManager;

        protected readonly SignInManager<IdentityUser<int>> signInManager;
        protected readonly IMessageService messageService;

        public  AccountController(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager, IMessageService messageService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.messageService = messageService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromQuery] IdentityUser<int> user)
        {
           var res = await userManager.CreateAsync(user);
           try
           {
               await messageService.RegisterEmailConfirm(user, Url, HttpContext, "PleaseConfirmEmail", "ConfirmEmail");
               if (res.Succeeded)
               {
                   await messageService.RegisterEmailConfirm(user, Url, HttpContext, "PleaseConfirmEmail", "ConfirmEmail");
                   return Ok(res);
               }
               throw new Exception(res.ToString());

            }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
           
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUser([FromQuery]int id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());
                await userManager.DeleteAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] IdentityUser<int> user)
        {
            try
            {
                if (user != null)
                {
                    await userManager.UpdateAsync(user);
                    return Ok();
                }
                throw  new Exception("Empty user.");
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddToRole([FromQuery] int userId,string role)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId.ToString());
                var res =await userManager.AddToRoleAsync(user, role);
                if (res.Succeeded)
                {
                    return Ok();
                }
                throw new Exception(res.ToString());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveFromRole([FromQuery] int userId, string role)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId.ToString());
                var res = await userManager.RemoveFromRoleAsync(user, role);
                if (res.Succeeded)
                {
                    return Ok();
                }
                throw new Exception(res.ToString());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Empty code or user id");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            if (await userManager.IsEmailConfirmedAsync(user))
            {
                return Ok("AlreadyConfirmedEmail");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
            }

            return Ok();
        }

    }
}
