﻿namespace Store.Application.Services.User.Queries.GetUser
{
    public class GetUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
