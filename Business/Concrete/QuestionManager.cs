using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
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

        public IResult Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
