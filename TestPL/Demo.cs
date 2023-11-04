using Newtonsoft.Json;
using System;

namespace TestPL
{
    public class Demo
    {
        public string? question { get; set; }
        public List<String>? options { get; set; }
        public int ID { get; set; }
        static void main(String[] args)
        {
            Demo obj = new Demo();
            obj.question = "Which is the best?";
            List<String> option = new List<String>();
            option.Add("1");
            option.Add("2");
            option.Add("3");
            option.Add("4");
            obj.options = option;
            obj.ID = 100;

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);

        }
    }
}
