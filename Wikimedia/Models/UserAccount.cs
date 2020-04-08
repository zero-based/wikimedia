using System;

namespace Wikimedia.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
        public int Points { get; set; }
    }
}
