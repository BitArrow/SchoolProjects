using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Models;

namespace BLL.Service
{
    public class QuestionAnswerService
    {
        private DAL.Interfaces.IQuestionAnswerRepository _repo;
        private Factories.QuestionAnswerFactroy _factory;

        public QuestionAnswerService()
        {
            _repo = new DAL.Repositories.QuestionAnswerRepository(new DAL.DataContext());
            _factory = new Factories.QuestionAnswerFactroy();
        }

        public List<QuestionAnswerDTO> getAllQuestionAnswers()
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }

        public QuestionAnswerDTO getQuestionAnswerById(Guid id)
        {
            var query = _repo.All.FirstOrDefault(x => x.QuestionId == id);
            if (query == null) return null;
            return _factory.createBasicDTO(query);
        }

        public List<QuestionAnswerDTO> findQuestionAnswerByTitle(string query)
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).Where(t => t.Title.Contains(query)).ToList();
        }

        public List<QuestionAnswerDTO> findQuestionAnswersByQuestionId(Guid id)
        {
            return _repo.All.Select(x => _factory.createBasicDTO(x)).Where(t => t.QuestionId == id).ToList();
        }

        public bool addQuestionAnswer(QuestionAnswerDTO question)
        {
            //TODO lukustada uute lisaine, kui küsimus on avalik
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

        public bool updateQuestionAnswer(QuestionAnswerDTO question)
        {
            var q = _factory.reverseBasicDTO(question);
            if (_repo.GetById(q.QuestionId).Locked)
                return false;
            try
            {
                _repo.Update(_factory.reverseBasicDTO(question));
                _repo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteQuestionAnswer(QuestionAnswerDTO question)
        {
            var q = _factory.reverseBasicDTO(question);
            if (_repo.GetById(q.QuestionId).Locked)
                return false;
            try
            {
                _repo.Delete(_factory.reverseBasicDTO(question));
                _repo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void LockQuestionAnswers(Question question)
        {
            var qas = _repo.GetAllQuestionAnswersByQuestionId(question.QuestionId);

            foreach (var questionAnswer in qas)
            {
                questionAnswer.Locked = true;
                updateQuestionAnswer(_factory.createBasicDTO(questionAnswer));
            }
        }
    }
}
