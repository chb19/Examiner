using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Examiner.DAL.Repositories;

namespace Examiner.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _repository;

        public async Task<Question> EditQuestionAnswer(Guid questionId, Answer newQuestionAnswer)
        {
            return await Task.Run(() =>
            {
                var question = _repository.Questions.Find(x => x.Id == questionId).First();
                question.CorrectAnswer = newQuestionAnswer;
                _repository.Questions.Update(question);
                return question;
            }).ConfigureAwait(false);
        }
        public async Task<Question> EditQuestionText(Guid questionId, string newQuestionText)
        {
            return await Task.Run(() =>
            {
                var question = _repository.Questions.Find(x => x.Id == questionId).First();
                question.QuestionText = newQuestionText;
                _repository.Questions.Update(question);
                return question;
            }).ConfigureAwait(false);
        }
    }
}
