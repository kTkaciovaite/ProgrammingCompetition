using ProgrammingGame.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingGame.DataAccess
{
    public class ProblemDataService
    {
        public List<Problem> GetAll()
        {
            using (var context = new GameContext())
            {
                return context.Problem.ToList();
            }
        }
    }
}
