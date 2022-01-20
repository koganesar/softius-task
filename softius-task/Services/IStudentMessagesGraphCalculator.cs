using softius_task.Models;

namespace softius_task.Services;

public interface IStudentMessagesGraphCalculator
{
    public IEnumerable<StudentPair> GetResultGraph(StudentInputModel inputModel);
}
