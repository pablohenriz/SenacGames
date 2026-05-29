using System;
using System.Collections.Generic;
using System.Text;

// DTOs usados nos endpoinst de autenticação (login, registro ...)
namespace SenacGames.Application.DTOs
{
    internal class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegistroDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string ConfirPassword {  get; set; } = string.Empty;
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string Email {  set; get; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
