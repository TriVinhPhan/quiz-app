using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;
using QuizTest.Data;
using QuizTest.Pages.Quiz;


namespace QuizTest.Pages.Question
{
    public class ManagerModel : PageModel
    {
        private readonly AppDbContext _context;

        public ManagerModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Models.Question> Questions { get; set; }

        public async Task OnGetAsync()
        {
            Questions = await _context.question.Include(q => q.Quiz).ToListAsync();
        }
    }
}
