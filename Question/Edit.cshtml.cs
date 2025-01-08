using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;
using QuizTest.Pages.Quiz;

namespace QuizTest.Pages.Question
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Question Question { get; set; }
        public IList<Models.Quiz> Quizzes { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Question = await _context.question.Include(q => q.Quiz).FirstOrDefaultAsync(q => q.QuestionId == id);

            if (Question == null)
            {
                return NotFound();
            }

            Quizzes = await _context.quizzes.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Question).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("/Question/Manager");
        }
    }
}
