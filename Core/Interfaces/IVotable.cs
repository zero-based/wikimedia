namespace Core.Interfaces
{
    internal interface IVotable
    {
        int UpVotes { get; set; }
        int DownVotes { get; set; }
    }
}
