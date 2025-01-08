namespace QuizTest.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public List<Answers> answers { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}
