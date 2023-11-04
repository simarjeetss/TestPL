using System.IO;
using System;
using Newtonsoft.Json;
using TestPL.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace TestPL.DataStores
{
    public class LocalDataStore : IDataStore
    {
        public LocalDataStore() { }
        readonly string filePath = "D:/questions.txt";
        readonly string answerPath = "D:/answers.txt";

        //implement the methods in the interface
        public bool save(int id, Question data)
        {
            try
            {
                //var content = File.ReadAllText(filepath);
                var newDataToBesaved = JsonConvert.SerializeObject(data, Formatting.Indented) + ",\n";
                //var updatedContent = content + "\n\n" + newDataToBesaved;
                File.AppendAllText(filePath, newDataToBesaved);
            }
            catch (Exception ex)
            {
                return false;
            }
            //throw new NotImplementedException();
            return true;
        }

        public Question retrieve(int id)
        {
            try
            {
                // Read the entire JSON file as a single string
                string content = File.ReadAllText(filePath);

                // Deserialize the entire JSON array into a list of questions
                List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(content);

                // Search for the question with the given id
                Question q = questions.Find(question => question.id == id);

                return q;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
            return null;
        }

        //function to print all questions in the given file
        public String[] printAll()
        {

            string content = File.ReadAllText(filePath);
            if (content.Equals(null))
            {
                return null;
            }
            string[] questions = content.Split(",");

             //List<PollQuestion> ?questions = JsonConvert.DeserializeObject<List<PollQuestion>>(content);
             


            return questions;
            
        }

        public bool update(Question newQuestion)
        {
            try
            {
                
                if (newQuestion.id != null && newQuestion.question != null)
                {
                    Question currentQuestion = retrieve(newQuestion.id);

                    if (currentQuestion != null)
                    {

                        currentQuestion.question = newQuestion.question;


                        save(currentQuestion.id, currentQuestion);
                    }
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }


        public List<Question> ReadQuestionsFromFile()
        {
            List<Question> questions = new List<Question>();

            try
            {
                // Read the JSON data from the file
                string jsonData = File.ReadAllText(filePath);

                // Deserialize the JSON data into a list of questions
                //questions = System.Text.Json.JsonSerializer.Deserialize<List<Question>>(jsonData);
                questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
                // You might want to log the error or return an error response
                // For simplicity, we'll just print the error message
                Console.WriteLine(ex.Message);
            }

            return questions;
        }

        public Boolean check(int id, Answer ans)
        {
            try
            {
                string correctAnswers = File.ReadAllText(answerPath);
                List<Answer> answers = new List<Answer>();

                answers = JsonConvert.DeserializeObject<List<Answer>>(correctAnswers);
                Answer correct = answers.Find(ans => ans.id == id);

                if(correct != null)
                {
                    bool isRight = string.Equals(correct.answer, ans.answer);    

                    if(isRight )
                    {
                        return true;
                    }
                }
                return false;
            } 
            catch (Exception ex)
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
        }
    }
}

