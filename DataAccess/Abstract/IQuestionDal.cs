using Core.DataAccess;
using Core.Entities.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>
    {
        List<Question> GetQuestionDetailsByExamId(int examId, int questionId);
    }
}
