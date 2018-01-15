using ProgrammingGame.Domain;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProgrammingGame.DataAccess
{
    public class GameInitializer : DropCreateDatabaseAlways<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            var problems = new List<Problem>
            {
                new Problem() { Name = "Square", InputParameter = "5", OutputParameter = "25" },
                new Problem() { Name = "Average", InputParameter = "[10,15,20,30]", OutputParameter = "18" }
            };

            problems.ForEach(problem => context.Problem.Add(problem));
            context.SaveChanges();

            var submissions = new List<Submission>
            {
                new Submission { Nickname = "Bob", ProblemId = 1, IsSuccessful = true, Solution = "using System; using System.Collections.Generic; using System.Linq; using System.Text.RegularExpressions; namespace Rextester { public class Program { public static void Main(string[] args) { var input = int.Parse(Console.ReadLine()); Console.Write(input * input); } } }" },
                new Submission { Nickname = "Alice", ProblemId = 1, IsSuccessful = true, Solution = "using System; using System.Collections.Generic; using System.Linq; using System.Text.RegularExpressions; namespace Rextester { public class Program { public static void Main(string[] args) { var input = int.Parse(Console.ReadLine()); Console.Write(input * input); } } }" },
                new Submission { Nickname = "Bob", ProblemId = 2, IsSuccessful = false, Solution = "" },
                new Submission { Nickname = "Bob", ProblemId = 2, IsSuccessful = false, Solution = "" },
                new Submission { Nickname = "Alice", ProblemId = 2, IsSuccessful = true, Solution = "using System; using System.Collections.Generic; using System.Linq; using System.Text.RegularExpressions; namespace Rextester { public class Program { public static void Main(string[] args) { var input = int.Parse(Console.ReadLine()); Console.Write(input * input); } } }" }
            };

            submissions.ForEach(submission => context.Submission.Add(submission));
            context.SaveChanges();
        }
    }
}
