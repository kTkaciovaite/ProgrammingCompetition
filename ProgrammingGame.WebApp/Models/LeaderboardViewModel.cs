
using System.Collections.Generic;

namespace ProgrammingGame.WebApp.Models
{
    public class LeaderboardViewModel
    {
        public string Nickname { get; set; }

        public int SuccessfulSolutionsCount { get; set; }

        public List<string> SolvedProblems { get; set; }
    }
}