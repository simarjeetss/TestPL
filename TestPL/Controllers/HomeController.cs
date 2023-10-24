using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TestPL.DataStores;
using TestPL.Models;

namespace TestPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataStore dataStore;

        public HomeController(ILogger<HomeController> logger)
        {
            this.dataStore = new LocalDataStore();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();

        }

        public IActionResult Promo()
        {

            return Ok("This is the privacy page");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("hello/{name}")]
        public IActionResult World(string name)
        {
            if (name.Equals("sunny"))
            {
                return Ok("hello legend");
            }
            return Ok("Hello " + name);
        }

        //post method to save into a file on the localhost
        [HttpPost("/questions")]
        public IActionResult postQuestion([FromBody] PollQuestion question)
        {
            if (question != null)
            {
                dataStore.save(question.id, question);
            }

            return Ok("question sent by user: " + JsonConvert.SerializeObject(question, Formatting.Indented) + "\n saved by id:" + question.id);
        }
        //GET method to retrieve question by id
        [HttpGet("questions/{questionId}")]
        public IActionResult retrieveById(string questionId)
        {
            PollQuestion response = dataStore.retrieve(questionId);


            return Ok("Question with ID " + questionId + " is " + JsonConvert.SerializeObject(response, Formatting.Indented));
        }


        //GET method to print all the questions present
        [HttpGet("printAll")]
        public IActionResult print()
        {
            List<PollQuestion> all = dataStore.printAll();


            return Ok("Questions are:- \n" + JsonConvert.SerializeObject(all,Formatting.Indented));
        }

    }
}