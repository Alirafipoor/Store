﻿namespace Store.Models.ViewModels.AuthenticationViewModels
{
    public class SignupViewModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}