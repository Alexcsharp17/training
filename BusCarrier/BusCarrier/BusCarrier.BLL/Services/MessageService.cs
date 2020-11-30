using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using BusCarrier.Util.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace BusCarrier.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly UserManager<IdentityUser<int>> userManager;

        private readonly IMailSender mailSender;

        public MessageService(UserManager<IdentityUser<int>> userManager, IMailSender mailSender)
        {
            this.userManager = userManager;
            this.mailSender = mailSender;
        }

        public async Task RegisterEmailConfirm(IdentityUser<int> user, IUrlHelper Url, HttpContext HttpContext,
            string subject, string text)
        {
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id, code},
                HttpContext.Request.Scheme);

            await mailSender.SendMail(user.Email, subject,
                text + $"<a href='{callbackUrl}'>link</a>");
        }

        public async Task ResetPasswordConfirm(IdentityUser<int> user, IUrlHelper Url, HttpContext HttpContext,
            string subject, string text)
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new {userEmail = user.Email, code},
                HttpContext.Request.Scheme);

            await mailSender.SendMail(user.Email, subject,
                text + $"<a href='{callbackUrl}'>link</a>");
        }
    }
}
