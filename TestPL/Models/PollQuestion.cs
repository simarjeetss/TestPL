namespace TestPL.Models;

using Newtonsoft.Json;
using System;



public class PollQuestion
{
    /*    [JsonProperty("question")]
        public string question { get; set; }
        [JsonProperty("options")]
        public List<string> options { get; set; }
        [JsonProperty("id")]
        public Guid id { get; set; }

            public PollQuestion()
            {
                id = Guid.NewGuid();
            }

            public PollQuestion(string question, List<string> options)
            {
                this.question = question;
                this.options = options;
            }*/
    public string id { get; set; }
    public string question { get; set; }
    public List<string> options { get; set; }
}


