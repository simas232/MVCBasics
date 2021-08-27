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
    }
}
