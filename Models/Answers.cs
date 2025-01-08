using System.ComponentModel.DataAnnotations;

namespace QuizTest.Models
{
    public class Answers
    {
        [Key] public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
