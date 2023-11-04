using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TestPL.DataStores;
using TestPL.Models;
using System.Text.Json.Serialization;

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

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //post method to save into a file on the localhost
        [HttpPost("/questions")]
        public IActionResult postQuestion([FromBody] Question question)
        {
            if (question != null)
            {
                dataStore.save(question.id, question);
            }

            return Ok("question sent by user: " + JsonConvert.SerializeObject(question, Formatting.Indented) + "\n saved by id:" + question.id);
        }
        //GET method to retrieve question by id
        [HttpGet("question/{id}")]
        public IActionResult retrieveById(int id)
        {
            Question response = dataStore.retrieve(id);


            return Ok("Question with ID " + id + " is " + JsonConvert.SerializeObject(response, Formatting.Indented));
        }


        //GET method to print all the questions present
        [HttpGet("print")]
        public IActionResult print()
        {
            String[] all = dataStore.printAll();

            
            return Ok("Questions are:- \n" + JsonConvert.SerializeObject(all,Formatting.Indented));
        }



        //PUT method to update the existing question
        [HttpPut("question/update/{id}")]
        public IActionResult UpdateQuestion([FromBody]Question question)
        {

            dataStore.update( question);



            //return Ok("Question with ID " + JsonConvert.SerializeObject(id, Formatting.Indented) + " updated");
            return Ok("OK");
        }

        [HttpGet("poll")]
        public IActionResult GetRandomQuestion()
        {
            // Read questions from a file into a list
            List<Question> questions = dataStore.ReadQuestionsFromFile();

            // Generate a random index to select a question
            Random random = new Random();
            int randomIndex = random.Next(0, questions.Count);

            // Return the randomly selected question
            Question randomQuestion = questions[randomIndex];
            return Ok(randomQuestion);
        }



        [HttpPost("poll/{questionId}")]
        public IActionResult Check(int questionId, [FromBody]Answer ans)
        {
            bool isCorrect = dataStore.check(questionId, ans);

            if (isCorrect)
            {
                return Ok("7 Croreeeeee!!!!!!!!!!!!!!!!!!!!");
            }
            else
            {
                return Ok("Galat Jawab");

            }

        }


    }
}