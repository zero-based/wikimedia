namespace Wikimedia.Models
{
    internal interface IVotable
    {
        int UpVotes { get; set; }
        int DownVotes { get; set; }
    }
}
