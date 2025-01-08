using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;
using QuizTest.Pages.Quiz;

namespace QuizTest.Pages.Question
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Question = await _context.question.FindAsync(id);

            if (Question == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var question = await _context.question.FindAsync(id);

            if (question != null)
            {
                _context.question.Remove(question);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Question/Manager");
        }
    }
}
