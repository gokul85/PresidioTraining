﻿namespace PizzaHutAPIWithAuth.Models.DTOs
{
    public class LoginReturnDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

    }
}
