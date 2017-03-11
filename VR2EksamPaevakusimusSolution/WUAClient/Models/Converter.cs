using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.DailyService;

namespace WUAClient.Models
{
    public class Converter
    {
        public static Question convertToQuestion(QuestionDTO dto)
        {
            return new Question
            {
                QuestionId = dto.QuestionId,
                Title = dto.Title,
                Description = dto.Description,
                Published = dto.Published,
                Visible = dto.Visible
            };
        }

        public static QuestionDTO convertToQuestionDTO(Question question)
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

        public static QuestionAnswer convertToQAnswer(QuestionAnswerDTO dto)
        {
            return new QuestionAnswer
            {
                QuestionAnswerId = dto.QuestionAnswerId,
                QuestionId = dto.QuestionId,
                Title = dto.Title,
            };
        }

        public static QuestionAnswerDTO convertToQAnswerDTO(QuestionAnswer qAnswer)
        {
            return new QuestionAnswerDTO
            {
                QuestionAnswerId = qAnswer.QuestionAnswerId,
                QuestionId = qAnswer.QuestionId,
                Title = qAnswer.Title,
            };
        }
    }
}
