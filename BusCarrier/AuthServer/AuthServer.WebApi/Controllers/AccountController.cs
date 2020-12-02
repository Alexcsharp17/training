using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AuthServer.WebApi.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using AuthServer.BLL.Interfaces;
using AutoMapper;

namespace AuthServer.WebApi.Controllers
{
    public class AccountController : Controller
    {
        protected readonly UserManager<IdentityUser<int>> userManager;

        protected readonly SignInManager<IdentityUser<int>> signInManager;

        private readonly IMessageService messageService;

        private readonly IMapper mapper;

        public AccountController(UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager, ILogger<AccountController> logger,
              IMessageService messageService, IMapper mapper)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.messageService = messageService;
            this.mapper = mapper;

        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map<IdentityUser<int>>(registerModel);
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {

                    await messageService.RegisterEmailConfirm(user, Url, HttpContext, "EmailConfirmation", "Please Confirm Email");

                    return RedirectToAction("ConfirmRegistration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(registerModel);
        }

        [HttpGet]
        public IActionResult ConfirmRegistration()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            if (await userManager.IsEmailConfirmedAsync(user))
            {
                return View("AlreadyConfirmedEmail");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is null)
                {
                    ModelState.AddModelError("", "There isn't login user with such an email!");

                    return View(model);
                }

                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "You don't confirm your email");

                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, true);

                if (result.IsLockedOut)
                {
                    var timeLeft = (TimeSpan)(user.LockoutEnd - DateTime.UtcNow);

                    ModelState.AddModelError(string.Empty, $"Account is Locked, time left {timeLeft}");

                    return View(model);
                }

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Uncorrect login and (or) password");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return View("ConfirmForgotPassword");
                }

                await messageService.ResetPasswordConfirm(user, Url, HttpContext, "EmailConfirmation", "Please Confirm email");

                return RedirectToAction("ConfirmForgotPassword");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ConfirmForgotPassword()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string userEmail, string code = null)
        {
            var model = new ResetPasswordViewModel();
            model.Email = userEmail;
            model.Code = code;
            return code == null ? View("Error") : View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("ConfirmResetPassword");
            }

            var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("ConfirmResetPassword");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}

