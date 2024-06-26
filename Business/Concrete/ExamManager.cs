﻿using Business.Abstract;
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
        public IDataResult<int> GetVote(int examId)
        {
            var exam = _examDal.Get(v => v.Id == examId);

            if (exam == null)
            {
                return new ErrorDataResult<int>(Messages.ObjectDoesNotExist);
            }
            try
            {

                int TotalVotes = exam.TotalVotes;
                int VoteAmount = exam.VoteAmount;

                if (TotalVotes == 0 || VoteAmount == 0)
                {
                    return new ErrorDataResult<int>(Messages.VoteNullMessage);
                }

                return new SuccessDataResult<int>(TotalVotes / VoteAmount, Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<int>(ex.Message);
            }

        }

        public IResult Vote(int examId, int vote)
        {
            var exam = _examDal.Get(v => v.Id == examId);

            if (exam == null)
            {
                return new ErrorDataResult<int>(Messages.ObjectDoesNotExist);
            }
            if (vote > 5 || vote <= 0)
                return new ErrorResult(Messages.VoteCanNotBeGreaterOrLess0To5);

            try
            {
                exam.VoteAmount += 1;
                exam.TotalVotes += vote;
                _examDal.Update(exam);
                return new SuccessResult(Messages.SuccessMessage);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }
        }
    }
}
