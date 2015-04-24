namespace CodingQuiz.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }//FK to Question
        public string AnswerText { get; set; }
        public int Weight { get; set; }
        public bool IsAnswer { get; set; }

    }
}