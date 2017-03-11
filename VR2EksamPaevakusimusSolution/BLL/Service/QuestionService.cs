using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Models;

namespace BLL.Service
{
    public class QuestionService
    {
        private DAL.Interfaces.IQuestionRepository _repo;
        private Factories.QuestionFactory _factory;
        private DAL.Interfaces.IQuestionAnswerRepository _qaRepo;
        private QuestionAnswerService _qaService;

        public QuestionService()
        {
            _repo = new DAL.Repositories.QuestionRepository(new DAL.DataContext());
            _factory = new Factories.QuestionFactory();
            _qaRepo =  new DAL.Repositories.QuestionAnswerRepository(new DAL.DataContext());
            _qaService = new QuestionAnswerService();
        }

        public List<QuestionDTO> getAllQuestions()
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).Where(p => p.Visible).ToList();
        }

        public QuestionDTO getQuestionById(Guid id)
        {
            var query =  _repo.All.FirstOrDefault(x => x.QuestionId == id);
            if (query == null) return null;
            return _factory.createBasicDTO(query);
        }

        public List<QuestionDTO> findByQuestionTitle(string query)
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).Where(t => t.Title.Contains(query)).ToList();
        }

        public List<QuestionDTO> findByQuestionDescription(string query)
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).Where(t => t.Description.Contains(query)).ToList();
        }

        public bool addQuestion(QuestionDTO question)
        {
            try
            {
                _repo.Add(_factory.reverseBasicDTO(question));
                _repo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateQuestion(QuestionDTO question)
        {
            var q = _factory.reverseBasicDTO(question);
            if (_repo.GetById(q.QuestionId).Locked)
                return false;
            try
            {
                if (q.Published)
                {
                    q.Locked = true;
                    _qaService.LockQuestionAnswers(q);
                }

                _repo.Update(q);
                _repo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteQuestion(QuestionDTO question)
        {
            try
            {
                var quest = _repo.GetById(question.QuestionId);
                quest.QuestionAnswers = _qaRepo.GetAllQuestionAnswersByQuestionId(question.QuestionId);

                _repo.DeleteQuestion(quest);
                _repo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
