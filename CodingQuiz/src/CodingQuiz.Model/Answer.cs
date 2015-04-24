using System;
using System.ComponentModel.DataAnnotations;

namespace CodingQuiz.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }//FK to Question
        [Required]
        public string AnswerText { get; set; }
        public int Weight { get; set; }
        public bool IsAnswer { get; set; }

    }
}