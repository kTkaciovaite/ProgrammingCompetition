using ProgrammingGame.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingGame.DataAccess
{
    public class SubmissionDataService
    {
        public List<Submission> GetAll()
        {
            using (var context = new GameContext())
            {
                return context.Submission.ToList();
            }
        }

        public void Add(Submission submission)
        {
            using(var context = new GameContext())
            {
                context.Submission.Add(submission);
                context.SaveChanges();
            }
        }
    }
}
