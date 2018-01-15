using ProgrammingGame.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingGame.WebApp.Models
{
    public class SubmissionViewModel
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        public int ProblemId { get; set; }

        [Required]
        public string Solution { get; set; }

        public static SubmissionViewModel MapFrom(Submission submission)
        {
            var model = new SubmissionViewModel
            {
                Nickname = submission.Nickname,
                ProblemId = submission.ProblemId,
                Solution = submission.Solution
            };

            return model;
        }
    }
}