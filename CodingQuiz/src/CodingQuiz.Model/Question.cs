using System;
using System.ComponentModel.DataAnnotations;

namespace CodingQuiz.Model
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string ImgUrl { get; set; }
        /*
        QuestionType
        List<Answer>
        */

    }
}