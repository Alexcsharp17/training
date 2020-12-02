﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AuthServer.WebApi.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(20, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime LastSignIn { get; set; } = DateTime.UtcNow;
    }
}
