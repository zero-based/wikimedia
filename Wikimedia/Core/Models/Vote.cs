namespace Core.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Topic Topic { get; set; }
        public UserAccount Voter { get; set; }
    }
}
