using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;

namespace QuizTest.Pages.Quiz
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Models.Quiz> Quizzes { get; set; }

        public async Task OnGetAsync()
        {
            Quizzes = await _context.quizzes.ToListAsync();
        }
    }
}
