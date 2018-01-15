using ProgrammingGame.Domain;
using System.Data.Entity;

namespace ProgrammingGame.DataAccess
{
    public class GameContext : DbContext
    {
        public GameContext() : base()
        {
            Database.SetInitializer(new GameInitializer());
        }

        public DbSet<Problem> Problem { get; set; }

        public DbSet<Submission> Submission { get; set; }
    }
}
