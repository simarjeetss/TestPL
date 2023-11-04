using TestPL.Models;
using MongoDB.Driver;

namespace TestPL.Services
{
    public class PollService : IPollService
    {
        private readonly IMongoCollection<Question> _questions;      

        public PollService(IPollingSystemDatabaseSettings settings, IMongoClient mongoclient)
        {
            var database = mongoclient.GetDatabase(settings.DatabaseName);
            _questions = database.GetCollection<Question>(settings.PollingSystemCollectionName);
            
        }
        public Question Create(Question question)
        {
            _questions.InsertOne(question);
            return question;
        }

        public List<Question> Get()
        {
            return _questions.Find(question => true).ToList();
        }

        public Question Get(int id)
        {
            return _questions.Find(question => question.id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            _questions.DeleteOne(question => question.id == id);
        }

        public void Update(int id, Question question)
        {
            _questions.ReplaceOne(question => question.id == id, question);
        }
    }
}
