using Core.Utilities.Abstract;
using Core.Utilities;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Delete(Question question);
        IResult Update(Question question);
        IDataResult<Question> GetQuestionById(int questionId);
        IDataResult<Question> GetQuestionDetailsByExamId(int examId, int questionId);

        IDataResult<Question> CheckUserPointWithQuestion(int examId, int questionId, string userAnswer, int userId);

    }
}
