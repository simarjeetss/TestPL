namespace TestPL.Models
{
    public class Poll
    {
        public string Question { get; set; }
        public List<PollOption> options { get; set; }
        public int ID { get; set; }
    }
}
