using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;
using QuizTest.Pages.Quiz;

namespace QuizTest.Pages.Question
{
    public class CreateQuestionModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateQuestionModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string QuestionText { get; set; }

        [BindProperty]
        public List<string> AnswerTexts { get; set; } = new List<string>() { "", "", "", "" };

        [BindProperty]
        public int CorrectAnswerIndex { get; set; }

        [BindProperty]
        public int QuizID { get; set; }
        
        public List<Models.Quiz> Quizzes { get; set; }

        public async Task OnGetAsync()
        {
            Quizzes = await _context.quizzes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var newQuestion = new Models.Question
            {
                QuestionText = QuestionText,
                answers = AnswerTexts.Select(answerText => new Answers
                {
                    AnswerText = answerText
                }).ToList(),
                QuizId = QuizID
            };

            _context.question.Add(newQuestion);
            await _context.SaveChangesAsync();

            var correctAnswer = newQuestion.answers[CorrectAnswerIndex];
            newQuestion.CorrectAnswerId = correctAnswer.AnswerId;

            await _context.SaveChangesAsync();
            return RedirectToPage("/Question/Manager");
        }
    }
}
