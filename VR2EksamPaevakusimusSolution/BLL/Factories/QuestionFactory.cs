using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Models;

namespace BLL.Factories
{
    public class QuestionFactory
    {
        public QuestionDTO createBasicDTO(Question question)
        {
            return new QuestionDTO
            {
                QuestionId = question.QuestionId,
                Title = question.Title,
                Description = question.Description,
                Published = question.Published,
                Visible = question.Visible
            };
        }

        public Question reverseBasicDTO(QuestionDTO questionDTO)
        {
            return new Question
            {
                QuestionId = questionDTO.QuestionId,
                Title = questionDTO.Title,
                Description = questionDTO.Description,
                Published = questionDTO.Published,
                Visible = questionDTO.Visible
            };
        }
    }
}
