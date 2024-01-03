using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public IResult Add(Exam exam)
        {
            throw new NotImplementedException();
        }
        public IResult Update(Exam exam)
        {
            throw new NotImplementedException();
        }
        public IResult Delete(Exam exam)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Exam> GetExamById(int Id)
        {
            return new SuccessDataResult<Exam>(_examDal.Get(e => e.Id == Id), Messages.SuccessDataMessage);
        }

        public IDataResult<List<Exam>> GetExamDetailsById(int Id)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetExamDetails(Id), Messages.SuccessDataMessage);
        }

        public IDataResult<List<Exam>> GetAllExams()
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(), Messages.SuccessDataMessage);
        }

        
    }
}
