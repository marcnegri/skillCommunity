using System;
namespace skillCommunity.Models
{
    public class User
    {
        private string username;
        private string email;
        private bool isActive;
        private readonly int id;

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int Id => id;

        public User()
        {
        }
    }
}
