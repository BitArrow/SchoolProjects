using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Service;

namespace WCF.Library
{
    public class DailyService : IDailyService
    {
        private readonly QuestionService _questionService;
        private readonly QuestionAnswerService _qAnswerService;

        public DailyService()
        {
            _questionService = new QuestionService();
            _qAnswerService = new QuestionAnswerService();
        }

        public List<QuestionDTO> getAllQuestions()
        {
            return _questionService.getAllQuestions();
        }

        public QuestionDTO getQuestionById(Guid id)
        {
            return _questionService.getQuestionById(id);
        }

        public List<QuestionDTO> findQuestionByTitle(string query)
        {
            return _questionService.findByQuestionTitle(query);
        }

        public List<QuestionDTO> findQuestionByDescription(string query)
        {
            return _questionService.findByQuestionDescription(query);
        }

        public Result addQuestion(QuestionDTO question)
        {
            return QueryResult(_questionService.addQuestion(question));

        }

        public Result updateQuestion(QuestionDTO question)
        {
            return QueryResult(_questionService.updateQuestion(question));
        }

        public Result deleteQuestion(QuestionDTO question)
        {
            return QueryResult(_questionService.deleteQuestion(question));
        }

        public List<QuestionAnswerDTO> getAllQuestionAnswers()
        {
            return _qAnswerService.getAllQuestionAnswers();
        }

        public QuestionAnswerDTO getQuestionAnswerById(Guid id)
        {
            return _qAnswerService.getQuestionAnswerById(id);
        }

        public List<QuestionAnswerDTO> findQuestionAnswerByTitle(string query)
        {
            return _qAnswerService.findQuestionAnswerByTitle(query);
        }

        public List<QuestionAnswerDTO> findQuestionAnswersByQuestionId(Guid id)
        {
            return _qAnswerService.findQuestionAnswersByQuestionId(id);
        }

        public Result addQuestionAnswer(QuestionAnswerDTO question)
        {
            return QueryResult(_qAnswerService.addQuestionAnswer(question));
        }

        public Result updateQuestionAnswer(QuestionAnswerDTO question)
        {
            return QueryResult(_qAnswerService.updateQuestionAnswer(question));
        }

        public Result deleteQuestionAnswer(QuestionAnswerDTO question)
        {
            return QueryResult(_qAnswerService.deleteQuestionAnswer(question));
        }


        public Result QueryResult(bool res)
        {
            if (res)
                return new Result
                {
                    Description = "Category deleted!",
                    Status = Status.Ok
                };

            return new Result
            {
                Description = "Failed to delete Category!",
                Status = Status.NotOk
            };
        }
    }
}
