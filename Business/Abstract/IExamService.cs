using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        IResult Add(Exam exam);
        IResult Delete(Exam exam);
        IResult Update(Exam exam);
        IDataResult<Exam> GetExamById(int Id);
        IDataResult<Exam> GetExamDetailsById(int Id);
        IDataResult<List<Exam>> GetAllExams();
    }
}
