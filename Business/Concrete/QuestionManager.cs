using Business.Abstract;
using Business.Constants;
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
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
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

        public IDataResult<List<Question>> GetQuestionDetailsByExamId(int examId, int questionId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetQuestionDetailsByExamId(examId, questionId),Messages.SuccessDataMessage);
        }

        public IResult Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
