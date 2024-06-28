using Microsoft.AspNetCore.Components;
using Quizzing.Extensions;
using Quizzing.Models;

namespace Quizzing.Components.Pages;

public sealed partial class QuizCard
{
    [Parameter]
    public string? Category { get; set; } = "scrum";
    public List<Question> Questions = [];
    private int questionIndex = 0;
    private int score = 0;

    protected sealed override void OnParametersSet()
    {
        if (Category == "dotnet")
        {
            Questions.LoadDotNetQuestions();
        }
        else if (Category == "blazor")
        {
            Questions.LoadBlazorQuestions();
        }
        else if (Category == "git")
        {
            Questions.LoadGitQuestions();
        }
        else
        {
            Questions.LoadScrumQuestions();
        }
    }

    private void OptionSelected(string option)
    {
        if (option == Questions[questionIndex].Answer)
        {
            score++;
        }
        questionIndex++;
    }

    private void RestartQuiz()
    {
        score = 0;
        questionIndex = 0;
    }

    private void ExitQuiz()
    {
        NavigationManager.NavigateTo("/");
    }
}
