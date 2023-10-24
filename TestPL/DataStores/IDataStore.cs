using TestPL.Models;

namespace TestPL.DataStores
{
    public interface IDataStore
    {
        public bool save(string id, PollQuestion data);
        public PollQuestion retrieve(string id);

        public List<PollQuestion> printAll();
    }
}
