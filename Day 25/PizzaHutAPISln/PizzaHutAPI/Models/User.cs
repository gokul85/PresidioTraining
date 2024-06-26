﻿
using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? Role { get; set; } = "User";

    }
}
