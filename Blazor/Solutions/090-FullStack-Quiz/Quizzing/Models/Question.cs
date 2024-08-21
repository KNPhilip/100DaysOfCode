namespace Quizzing.Models;

public sealed class Question
{
    public string QuestionTitle = string.Empty;
    public IEnumerable<string> Options = [];
    public string Answer = string.Empty;
}
