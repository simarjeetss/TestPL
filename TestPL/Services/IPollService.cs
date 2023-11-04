using TestPL.Models;

namespace TestPL.Services
{
    public interface IPollService
    {
        List<Question> Get();
        Question Get(int id);
        Question Create(Question question);
        void Update(int id, Question question);
        void Remove(int id);
    }
}
