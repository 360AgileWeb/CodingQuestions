using System;
using System.Collections.Generic;
using CodingQuiz.Model;
using System.Linq;

namespace CodingQuiz.Repo
{
    public class CodingQuizRepository : ICodingQuizRepository
    {
        readonly List<Question> _items = new List<Question>();

        public IEnumerable<Question> AllItems
        {
            get
            {
                //simulate a few items
                var newId = (_items.Count + 1);
                _items.Add(new Question() {Id =newId, QuestionText="Question " + newId.ToString(), QuizId=1 });

                return _items;
            }
        }

        public Question GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Question item)
        {
            item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(item);
        }

        public bool TryDelete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }
    }
}