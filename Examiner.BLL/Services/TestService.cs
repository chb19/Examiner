using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Services
{
    public class TestService : ITestService
    {
        private IUnitOfWork _repository;
        private UserManager<User> _userManager;
        public TestService(IUnitOfWork repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task AddQuestion(QuestionDTO questionDTO, Guid testId)
        {
            await Task.Run(() =>
            {
                _repository.Questions.Create(new Question { QuestionText = questionDTO.QuestionText, TestId = testId });
                _repository.Save();
            });
        }
        public async Task DeleteQuestion(Guid questionId)
        {
            await Task.Run(() =>
            {
                _repository.Questions.Delete(questionId);
                _repository.Save();
            });
        }
        public async Task EditQuestion(QuestionDTO questionDTO)
        {
            var question = _repository.Questions.Find(x => x.Id == questionDTO.Id).ToList();
            if (question.Count == 0)
            {
                return;
            }
            await Task.Run(() =>
            {
                var q = question[0];
                q.QuestionText = questionDTO.QuestionText;
                q.CorrectAnswer = questionDTO.Answer;
                _repository.Questions.Update(q);
                _repository.Save();
            });
        }
    }
}
