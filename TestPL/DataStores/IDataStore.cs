using TestPL.Models;

namespace TestPL.DataStores
{
    public interface IDataStore
    {
        public bool save(int id, Question data);
        public Question retrieve(int id);

        public String[] printAll();
        public bool update(Question newQuestion);
        public List<Question> ReadQuestionsFromFile();
        public Boolean check(int id,  Answer ans);
    }
}
