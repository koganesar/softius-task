using softius_task.Services;

namespace softius_task.Models;

public record struct ResultOutputModel(IEnumerable<StudentPair>? Pairs, bool ParsingError);