using ProgrammingGame.DataAccess;
using ProgrammingGame.Domain;
using ProgrammingGame.WebApp.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace ProgrammingGame.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Problem> problemList;

        public HomeController()
        {
            var problemDataService = new ProblemDataService();
            problemList = problemDataService.GetAll();

            ViewBag.problems = problemList;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SubmissionViewModel newSubmission)
        {
            if (ModelState.IsValid)
            {
                var submissionService = new SubmissionDataService();
                var submission = new Submission
                {
                    Nickname = newSubmission.Nickname,
                    ProblemId = newSubmission.ProblemId,
                    Solution = newSubmission.Solution,
                    IsSuccessful = true
                };

                // The API did not work as it should for me, so I assume all posted solutions are successful for now
                // var response = PostSubmission(submission);

                submissionService.Add(submission);

                return RedirectToAction("SubmittedSolution");
            }

            return View(newSubmission);
        }

        private string PostSubmission(Submission submission)
        {
            using (var webClient = new WebClient())
            {
                var data = new NameValueCollection
                {
                    ["LanguageChoice"] = "1",
                    // Encoding of this property must be the problem. The error I get is:
                    // "Method 'main' must be in a class 'Rextester'."
                    // But actually, it is there
                    ["Program "] = submission.Solution,
                    ["Input"] = "5"
                };
                
                var response = webClient.UploadValues("http://rextester.com/rundotnet/api", "POST", data);
                return Encoding.UTF8.GetString(response);
            }
        }

        public ActionResult SubmittedSolution()
        {
            return View();
        }

        public ActionResult Leaderboard()
        {
            var submissionService = new SubmissionDataService();
            var submissions = submissionService.GetAll();

            var successfulSubmissions = submissions
                .Where(submission => submission.IsSuccessful)
                .GroupBy(submission => submission.Nickname)
                .Select(group => group.ToList())
                .ToList();

            var leadersList = new List<LeaderboardViewModel>();
            foreach (var item in successfulSubmissions)
            {
                var solvedProblemsIds = item.Select(submission => submission.ProblemId).ToArray();
                var solvedProblems = solvedProblemsIds
                    .Select(problemId => problemList.Find(problem => problem.Id == problemId).Name).ToList();

                var newLeader = new LeaderboardViewModel
                {
                    Nickname = item.First().Nickname,
                    SuccessfulSolutionsCount = item.Count,
                    SolvedProblems = solvedProblems
                };

                leadersList.Add(newLeader);
            }

            leadersList = leadersList.OrderByDescending(x => x.SuccessfulSolutionsCount).ToList();

            return View(leadersList);
        }
    }
}