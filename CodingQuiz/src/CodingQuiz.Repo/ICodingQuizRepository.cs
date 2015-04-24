using CodingQuiz.Model;
using System;
using System.Collections.Generic;

namespace CodingQuiz.Repo
{
    public interface ICodingQuizRepository
    {
        IEnumerable<Question> AllItems { get; }
        void Add(Question item);
        Question GetById(int id);
        bool TryDelete(int id);

    }
}