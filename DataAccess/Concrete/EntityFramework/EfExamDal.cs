using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfExamDal : IEfEntityRepositoryBase<Exam, ReCapProjectDBContext>, IExamDal
    {
        public Exam GetExamDetails(int examId)
        {
            using(ReCapProjectDBContext context = new ReCapProjectDBContext())
            {

                var resultList = from exam in context.Exams
                                 where exam.Id == examId
                                 join examQuestion in context.ExamQuestions
                                 on exam.Id equals examQuestion.ExamId
                                 join question in context.Questions
                                 on examQuestion.QuestionId equals question.Id
                                 select new Exam
                                 {
                                     Id = exam.Id,
                                     ExamName = exam.ExamName,
                                     MinimumScore = exam.MinimumScore,
                                     Questions = context.Questions
                                                   .Where(q => q.Id == question.Id)
                                                   .Select(q => new Question
                                                   {
                                                       Id = q.Id,
                                                       QuestionText = q.QuestionText,
                                                       Answer1 = q.Answer1,
                                                       Answer2 = q.Answer2,
                                                       Answer3 = q.Answer3,
                                                       Answer4 = q.Answer4,
                                                       RightAnswer = q.RightAnswer,
                                                       Score = q.Score
                                                   })
                                                   .ToList()
                                 };

                return resultList.FirstOrDefault();

            }

        }

    }
}
