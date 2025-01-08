using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;

namespace QuizTest.Pages.Quiz
{
    public class ScoreHistoryModel : PageModel
    {
        private readonly AppDbContext _context;

        public ScoreHistoryModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<UserScore> Scores { get; set; }

        public async Task OnGetAsync()
        {
            Scores = await _context.userscore.Include(s => s.Quiz).ToListAsync();
        }
    }
}
