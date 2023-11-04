using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestPL.Models
{
    [BsonIgnoreExtraElements]
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }
        [BsonElement("question")]
        public string question { get; set; }
        [BsonElement("options")]
        public List<String> options { get; set; }

        public Question()
        {

        }
    }


}
