using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Models;

namespace BLL.Factories
{
    public class QuestionAnswerFactroy
    {
        public QuestionAnswerDTO createBasicDTO(QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerDTO
            {
                QuestionAnswerId = questionAnswer.QuestionAnswerId,
                QuestionId = questionAnswer.QuestionId,
                Title = questionAnswer.Title
            };
        }

        public QuestionAnswer reverseBasicDTO(QuestionAnswerDTO questionAnswer)
        {
            return new QuestionAnswer
            {
                QuestionAnswerId = questionAnswer.QuestionAnswerId,
                QuestionId = questionAnswer.QuestionId,
                Title = questionAnswer.Title
            };
        }
    }
}
