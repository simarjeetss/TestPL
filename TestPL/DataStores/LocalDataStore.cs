using System.IO;
using System;
using Newtonsoft.Json;
using TestPL.Models;
using Newtonsoft.Json.Linq;

namespace TestPL.DataStores
{
    public class LocalDataStore : IDataStore
    {
        public LocalDataStore() { }
        readonly string filePath = "D:/data.txt";

        //implement the methods in the interface
        public bool save(string id, PollQuestion data)
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

        public PollQuestion retrieve(string id)
        {
            try
            {
                //read the entire json file
                string content = File.ReadAllText(filePath);

                //seperate the json file by comma
                string[] objects = content.Split(',');

                //deserialize and search for question with given 
                foreach (string i in objects)
                {
                    
                        PollQuestion q = JsonConvert.DeserializeObject<PollQuestion>(i);

                        if (q.id.Equals(id))
                        {
                            return q;
                        }
                    
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
            return null;
        }

        //function to print all questions in the given file
        public List<PollQuestion> printAll()
        {

            string content = File.ReadAllText(filePath);
            

             List<PollQuestion> ?questions = JsonConvert.DeserializeObject<List<PollQuestion>>(content);

            return questions;
            
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
        }
    }
}

