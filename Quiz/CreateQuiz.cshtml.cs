using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;

namespace QuizTest.Pages.Quiz
{
    public class CreateQuizModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateQuizModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newQuiz = new Models.Quiz
            {
                Title = Title,
                Description = Description
            };

            _context.quizzes.Add(newQuiz);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Quiz/Index");
        }
        public void OnGet()
        {
        }
    }
}
