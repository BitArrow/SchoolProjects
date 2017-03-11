using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Models;

namespace WCF.Library
{
    [ServiceContract]
    public interface IDailyService
    {
        #region question
        [OperationContract]
        List<QuestionDTO> getAllQuestions();

        [OperationContract]
        QuestionDTO getQuestionById(Guid id);

        [OperationContract]
        List<QuestionDTO> findQuestionByTitle(string query);

        [OperationContract]
        List<QuestionDTO> findQuestionByDescription(string query);

        [OperationContract]
        Result addQuestion(QuestionDTO question);

        [OperationContract]
        Result updateQuestion(QuestionDTO question);

        [OperationContract]
        Result deleteQuestion(QuestionDTO question);
        #endregion

        #region questionAnswers
        [OperationContract]
        List<QuestionAnswerDTO> getAllQuestionAnswers();

        [OperationContract]
        QuestionAnswerDTO getQuestionAnswerById(Guid id);

        [OperationContract]
        List<QuestionAnswerDTO> findQuestionAnswerByTitle(string query);

        [OperationContract]
        List<QuestionAnswerDTO> findQuestionAnswersByQuestionId(Guid id);

        [OperationContract]
        Result addQuestionAnswer(QuestionAnswerDTO question);

        [OperationContract]
        Result updateQuestionAnswer(QuestionAnswerDTO question);

        [OperationContract]
        Result deleteQuestionAnswer(QuestionAnswerDTO question);

        #endregion
    }
}
