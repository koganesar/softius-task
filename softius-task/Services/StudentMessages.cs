using softius_task.Models;

namespace softius_task.Services;

public class StudentMessages : IStudentMessagesGraphCalculator
{
    private record struct StudentMessagesPair(int Number, int MessagesCount);

    public IEnumerable<StudentPair> GetResultGraph(StudentInputModel inputModel)
    {
        var data = new List<StudentMessagesPair>(inputModel.MessagesCounts.Length);
        data.AddRange(inputModel.MessagesCounts.Select(
            (count, i) => new StudentMessagesPair {Number = i + 1, MessagesCount = count}));

        return CalculateGraph(data);
    }

    private static List<StudentPair> CalculateGraph(List<StudentMessagesPair> data)
    {
        var firstStudent = data[0];
        data.Remove(firstStudent);
        data.Sort((pair1, pair2) => -pair1.MessagesCount.CompareTo(pair2.MessagesCount));
        var result = new List<StudentPair>(data.Count);
        var queue = new Queue<StudentMessagesPair>();
        var (currentNumber, currentCount) = firstStudent;
        foreach (var nextStudent in data)
        {
            if (currentCount is 0)
            {
                if (!queue.TryDequeue(out var student) || student.MessagesCount is 0)
                {
                    result = new List<StudentPair> {new(0, 0)};
                    break;
                }

                (currentNumber, currentCount) = student;
            }

            --currentCount;
            result.Add(new StudentPair
            {
                Number1 = currentNumber,
                Number2 = nextStudent.Number
            });
            queue.Enqueue(nextStudent);
        }

        return result;
    }
}
