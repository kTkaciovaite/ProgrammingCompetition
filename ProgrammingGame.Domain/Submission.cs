
namespace ProgrammingGame.Domain
{
    public class Submission
    {
        public int Id { get; set; }

        public int ProblemId { get; set; }

        public string Nickname { get; set; }

        public string Solution { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
