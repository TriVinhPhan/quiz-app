using System.ComponentModel.DataAnnotations;

namespace QuizTest.Models
{
    public class UserScore
    {
        [Key] public int ScoreId { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int Score { get; set; }
        public DateTime timestamp { get; set; }
    }
}
