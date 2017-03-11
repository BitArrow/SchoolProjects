using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUAClient.Models;
using WUAClient.Service.Interface;

namespace WUAClient.Service
{
    class QuestionAnswerSOAPService : IQuestionAnswerService
    {
        private DailyService.DailyServiceClient _client;

        public QuestionAnswerSOAPService()
        {
            _client = new DailyService.DailyServiceClient();
        }

        public async Task<ObservableCollection<QuestionAnswer>> getAll()
        {
            ObservableCollection<QuestionAnswer> questions = new ObservableCollection<QuestionAnswer>();
            var result = await _client.getAllQuestionAnswersAsync();
            foreach (var QADto in result)
            {
                questions.Add(Converter.convertToQAnswer(QADto));
            }

            return questions;
        }

        public async Task<QuestionAnswer> getQuestionAnswerById(Guid id)
        {
            return Converter.convertToQAnswer(await _client.getQuestionAnswerByIdAsync(id));
        }

        public async Task<ObservableCollection<QuestionAnswer>> findQuestionAnswersByTitle(string query)
        {
            ObservableCollection<QuestionAnswer> questions = new ObservableCollection<QuestionAnswer>();
            var result = await _client.findQuestionAnswerByTitleAsync(query);
            foreach (var QADto in result)
            {
                questions.Add(Converter.convertToQAnswer(QADto));
            }

            return questions;
        }

        public async Task<ObservableCollection<QuestionAnswer>> findQuestionAnswersByQuestionId(Guid id)
        {
            ObservableCollection<QuestionAnswer> questions = new ObservableCollection<QuestionAnswer>();
            var result = await _client.findQuestionAnswersByQuestionIdAsync(id);
            foreach (var QADto in result)
            {
                questions.Add(Converter.convertToQAnswer(QADto));
            }

            return questions;
        }

        public async Task<QuestionAnswer> addQuestionAnswer(QuestionAnswer qAnswer)
        {
            await _client.addQuestionAnswerAsync(Converter.convertToQAnswerDTO(qAnswer));
            return null;
        }

        public async Task<QuestionAnswer> updateQuestionAnswer(QuestionAnswer qAnswer)
        {
            await _client.updateQuestionAnswerAsync(Converter.convertToQAnswerDTO(qAnswer));
            return null;
        }

        public async Task<QuestionAnswer> deleteQuestionAnswer(QuestionAnswer qAnswer)
        {
            await _client.deleteQuestionAnswerAsync(Converter.convertToQAnswerDTO(qAnswer));
            return null;
        }
    }
}
