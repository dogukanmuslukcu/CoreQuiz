using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        IUserService _userservice;
        IExamService _examService;
        public QuestionManager(IQuestionDal questionDal,IUserService userService,IExamService examService)
        {
            _questionDal = questionDal;
            _userservice = userService;
            _examService = examService;

        }

        public IResult Add(Question question)
        {
            throw new NotImplementedException();
        }

       

        public IResult Delete(Question question)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Question> GetQuestionById(int questionId)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(I => I.Id == questionId), Messages.SuccessDataMessage);
        }

        public IDataResult<Question> GetQuestionDetailsByExamId(int examId, int questionId)
        {
            return new SuccessDataResult<Question>(_questionDal.GetQuestionDetailsByExamId(examId, questionId),Messages.SuccessDataMessage);
        }
        public IDataResult<Question> CheckUserPointWithQuestion(int examId, int questionId, string userAnswer, int userId)
        {
            var rightAnswer = _questionDal.GetQuestionDetailsByExamId(examId, questionId).RightAnswer;
            var examName = _examService.GetExamById(examId).Data.ExamName;


            if (rightAnswer.Replace(" ", "").ToLower() == userAnswer.Replace(" ", "").ToLower())
            {
                _userservice.AddPoint(userId, examName);
            }
            return new SuccessDataResult<Question>(Messages.SuccessDataMessage);



        }
        public IResult Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
