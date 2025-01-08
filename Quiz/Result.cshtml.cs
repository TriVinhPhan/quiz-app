using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;


namespace QuizTest.Pages.Quiz
{
    public class ResultModel : PageModel
    {
        public int Score { get; set; }

        public void OnGet(int score)
        {
            Score = score;
        }
    }
}
