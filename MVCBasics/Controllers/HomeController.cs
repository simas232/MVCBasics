using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            IDictionary<String, String> myEducation = new Dictionary<String, String>();
            myEducation.Add("2015-2021", "Doctor of Philosophy – PhD | Chalmers University of Technology");
            myEducation.Add("2014-2015", "MSc Bioinformatics | University of Skövde");
            myEducation.Add("2007-2011", "BSc Bioengineering | Vilnius Tech");

            IDictionary<String, String> myWorkExperience = new Dictionary<String, String>();
            myWorkExperience.Add("2015-2021", "PhD Student in Systems Biology | Chalmers University of Technology (Gothenburg, Sweden)");
            myWorkExperience.Add("2014", "Data Analyst (summer job) | SciCross AB (Skövde, Sweden)");
            myWorkExperience.Add("2012-2013", "Bioengineer | Sosdiagnostika UAB (Vilnius, Lithuania)");
            myWorkExperience.Add("2011", "In-Process Control Analyst | Teva Lithuania / Sicor Biotech UAB (Vilnius, Lithuania)");

            ViewBag.MyEducation = myEducation;
            ViewBag.MyWorkExperience = myWorkExperience;

            return View();
        }

        public IActionResult Contact()
        {
            IDictionary<String, String> myContacts = new Dictionary<String, String>();
            myContacts.Add("Name", "Simonas Marcišauskas");
            myContacts.Add("Address", "Majorsgatan 6, 41308 Gothenburg");
            myContacts.Add("Phone", "0727323064");

            ViewBag.MyContacts = myContacts;

            return View();
        }
        public IActionResult Projects()
        {
            IDictionary<String, String> myProjects = new Dictionary<String, String>();
            myProjects.Add("ConsoleMultiTool", "A console application containing Test & Bedömning tasks and 28 exercises from the main programme");
            myProjects.Add("Hangman", "A console application featuring game called Hangman");
            myProjects.Add("Calc", "A calculator console application that allows doing four basic mathematical operations with real numbers. Unit tests are also included.");
            myProjects.Add("ToDoIt", "A console application featuring ToDoIt management back-end module. Unit tests are also included.");
            myProjects.Add("VendingMachineController", "Controller for vending machine plus unit tests");
            myProjects.Add("BasicHTMLFundamentals", "Two simple HTML pages without CSS and JavaScript add-ons");
            myProjects.Add("CSSIntroduction", "Two simple HTML pages with CSS implementation");
            myProjects.Add("Sokoban", "A JavaScript-based game Sokoban");
            
            ViewBag.MyProjects = myProjects;

            return View();
        }

        // Actions for the random number guessing game
        [HttpGet]
        public IActionResult GuessingGame()
        {
            Random rnd = new Random();
            HttpContext.Session.SetInt32("randomNumber", rnd.Next(1, 101));
            HttpContext.Session.SetInt32("guessCounter", 0);

            ViewBag.GuessCounter = HttpContext.Session.GetInt32("guessCounter");

            HttpContext.Session.SetInt32("guessCounter", 0);

            // Load top 5 scores
            ViewBag.FirstScore = String.IsNullOrEmpty(Request.Cookies["firstScore"]) ? "1000" : Request.Cookies["firstScore"];
            ViewBag.SecondScore = String.IsNullOrEmpty(Request.Cookies["secondScore"]) ? "1000" : Request.Cookies["secondScore"];
            ViewBag.ThirdScore = String.IsNullOrEmpty(Request.Cookies["thirdScore"]) ? "1000" : Request.Cookies["thirdScore"];
            ViewBag.FourthScore = String.IsNullOrEmpty(Request.Cookies["fourthScore"]) ? "1000" : Request.Cookies["fourthScore"];
            ViewBag.FifthScore = String.IsNullOrEmpty(Request.Cookies["fifthScore"]) ? "1000" : Request.Cookies["fifthScore"];

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guessNumber)
        {
            // Load top 5 scores
            ViewBag.FirstScore = String.IsNullOrEmpty(Request.Cookies["firstScore"]) ? "1000" : Request.Cookies["firstScore"];
            ViewBag.SecondScore = String.IsNullOrEmpty(Request.Cookies["secondScore"]) ? "1000" : Request.Cookies["secondScore"];
            ViewBag.ThirdScore = String.IsNullOrEmpty(Request.Cookies["thirdScore"]) ? "1000" : Request.Cookies["thirdScore"];
            ViewBag.FourthScore = String.IsNullOrEmpty(Request.Cookies["fourthScore"]) ? "1000" : Request.Cookies["fourthScore"];
            ViewBag.FifthScore = String.IsNullOrEmpty(Request.Cookies["fifthScore"]) ? "1000" : Request.Cookies["fifthScore"];

            // Default session idle timeout is 20 minutes, should be more than enough
            int randomNumber = (int)HttpContext.Session.GetInt32("randomNumber");
            int guessCounter = (int)HttpContext.Session.GetInt32("guessCounter");

            // Autoincrease guessCounter and update it in View
            HttpContext.Session.SetInt32("guessCounter", ++guessCounter);
            ViewBag.GuessCounter = guessCounter;

            if (guessNumber == 0)
            {
                ViewBag.Status = "ERROR: Enter An Integer Number between 1 and 100!!!";
            }
            else if (guessNumber == randomNumber)
            {
                // Congratulate the player
                ViewBag.Status = "Congratulations! You Guessed The Number! Another Random Number Was Generated, Try to Guess It with Fewer Guesses!";

                // Now check if the current score qualifies as the top 5 all-time score and update the table if necessary

                int[] hiScores = {
                    int.Parse(ViewBag.FirstScore),
                    int.Parse(ViewBag.SecondScore),
                    int.Parse(ViewBag.ThirdScore),
                    int.Parse(ViewBag.FourthScore),
                    int.Parse(ViewBag.FifthScore),
                    0
                };

                // If the current score is high (to be more precise - low) enough, it should be included in high score list. Otherwise do nothing.
                if (guessCounter < hiScores.Max())
                {
                    hiScores[5] = guessCounter;
                    Array.Sort(hiScores);
                    // The 6th score is not included in the high score table anymore
                    Response.Cookies.Append("firstScore", hiScores[0].ToString());
                    Response.Cookies.Append("secondScore", hiScores[1].ToString());
                    Response.Cookies.Append("thirdScore", hiScores[2].ToString());
                    Response.Cookies.Append("fourthScore", hiScores[3].ToString());
                    Response.Cookies.Append("fifthScore", hiScores[4].ToString());
                }

                // Generate the new number. The congratulating window is, therefore, also allows to guess the next randomly generated number
                Random rnd = new Random();
                HttpContext.Session.SetInt32("randomNumber", rnd.Next(1, 101));
                HttpContext.Session.SetInt32("guessCounter", 0);      
            }
            else if (guessNumber < randomNumber)
            {
                ViewBag.Status = $"Incorrect! The Generated Number Is Greater Than {guessNumber}";
            }
            else if (guessNumber > randomNumber)
            {
                ViewBag.Status = $"Incorrect! The Generated Number Is Less Than {guessNumber}";
            }

            return View();
        }
    }
}
