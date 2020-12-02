﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.BLL.Interfaces
{
    public interface IMessageService
    {
        Task RegisterEmailConfirm(IdentityUser<int> user, IUrlHelper Url, HttpContext HttpContext,
            string subject, string text);

        Task ResetPasswordConfirm(IdentityUser<int> user, IUrlHelper Url, HttpContext HttpContext,
            string subject, string text);
    }
}