using System;

namespace Wikimedia.Models
{
    public class Commit
    {
        public UserAccount Author { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}