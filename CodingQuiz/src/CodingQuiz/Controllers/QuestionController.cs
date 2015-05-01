using CodingQuiz.Model;
using CodingQuiz.Repo;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingQuiz.Controllers
{
    [Route("api/[controller]")] //Using route tokens. [controller] is placeholder of actual controller 
    //[Route("[controller]/[action]")] //Say, for For Web UI
    public class QuestionController : Controller
    {
        private readonly ICodingQuizRepository _repository;

        public QuestionController(ICodingQuizRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Question> GetAll()
        {
            return _repository.AllItems;
        }
        
        [HttpGet("{id:int}", Name = "GetByIdRoute")]//Example of merging Route Verb and attributes
        public IActionResult GetById(int id)
        {
            var item = _repository.AllItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }
        
        /*
        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        [Produces("application/json")] //If you want to serve specific fomart
        public Question GetById(int id)
        {
            var item = _repository.AllItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return new Question() { Id = 10001, QuestionText = "Some othe question" };
            }

            return item;
        }
        */

        [HttpPost]
        public void CreateQuestion(Question item)
        {
            //1. Model binding from Form Post: Can use [FromBody], [FromHeader], etc
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                item.Id = 1 + _repository.AllItems.Max(x => (int?)x.Id) ?? 0;
                _repository.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                  Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_repository.TryDelete(id))
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
            else
            {
                return HttpNotFound();
            }

        }

       #region Views 
        public IActionResult Index()
        {
            return View("Index", _repository.AllItems);
        }

        public IActionResult Create()
        {
            return View();
        }
        #endregion
    }
}
