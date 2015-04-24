
namespace CodingQuiz.Model
{
    public class Question
    {
        public int Id { get; set; }        
        public string QuestionText { get; set; }
        public string ImgUrl { get; set; }
       
        public int QuizId { get; set; }
        /*
        public short QuestionType { get; set; }//0=SingleChoice, 1= MultipleChoice, 3=FreeText
        public List<Answer> Answers { get; set; }
        
        public string CorrectText { get; set; }
        public string IncorrectText { get; set; }
        public string OtherUrl { get; set; }
        */
    }
}