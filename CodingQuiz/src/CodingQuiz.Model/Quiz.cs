using System;
using System.Collections.Generic;

namespace CodingQuiz.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public IEnumerable<Question> Questions { get; set; }

        /* public IEnumerable<Response> Responses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        */

    }
}