using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;
using QuizTest.Pages.Quiz;

namespace QuizTest.Pages.Quiz
{
    public class TakeModel : PageModel
    {
        private readonly AppDbContext _context;

        public TakeModel(AppDbContext context)
        {
            _context = context;
        }

        public Models.Quiz Quiz { get; set; }
        public List<Models.Question> Questions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Quiz = await _context.quizzes.FindAsync(id);
            
            if (Quiz == null)
            {
                return NotFound();
            }
            Console.WriteLine(id);

            Questions = await _context.question.Where(q => q.QuizId == id).Include(q => q.answers).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Quiz = await _context.quizzes.FindAsync(id);

            if (Quiz == null)
            {
                return NotFound();
            }

            Questions = await _context.question.Where(q => q.QuizId == id).Include(q => q.answers).ToListAsync();

            var score = 0;
            var selectedAnswers = new Dictionary<int, int?>();

            foreach (var question in Questions)
            {
                var selectedAnswerId = Request.Form[$"Question_{question.QuestionId}"];

                if (!string.IsNullOrEmpty(selectedAnswerId) && int.TryParse(selectedAnswerId, out int selectedId))
                {
                    selectedAnswers[question.QuestionId] = selectedId;

                    if (selectedId == question.CorrectAnswerId)
                    {
                        score++;
                    }
                }
                else
                {
                    selectedAnswers[question.QuestionId] = null;
                }
            }

            TempData.Put("SelectedAnswers", selectedAnswers);

            var newScore = new Models.UserScore
            {
                QuizId = Quiz.QuizId,
                Score = score,
                timestamp = DateTime.UtcNow
            };

            _context.userscore.Add(newScore);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quiz/Result", new { id, score });
        }
    }
}
