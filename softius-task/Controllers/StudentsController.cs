using Microsoft.AspNetCore.Mvc;
using softius_task.Models;
using softius_task.Services;

namespace softius_task.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentMessagesGraphCalculator _calculator;

    public StudentsController(IStudentMessagesGraphCalculator calculator) =>
        _calculator = calculator;

    [Route("")]
    public IActionResult Input() =>
        View();

    [HttpGet]
    public IActionResult Result([FromQuery] string countsString)
    {
        int[] parsed;
        try
        {
            parsed = countsString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        catch
        {
            return View(new ResultOutputModel(default, true));
        }

        return View(new ResultOutputModel(
            _calculator.GetResultGraph(new StudentInputModel(parsed)),
            false));
    }
}
