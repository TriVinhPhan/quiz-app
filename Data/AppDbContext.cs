using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuizTest.Models;

namespace QuizTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Answers> answers { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<UserScore> userscore { get; set; }

    }
}