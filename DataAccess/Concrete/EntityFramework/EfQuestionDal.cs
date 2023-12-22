using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : IEfEntityRepositoryBase<Question, ReCapProjectDBContext>, IQuestionDal
    {
        public List<Question> GetQuestionDetailsByExamId(int examId, int questionId)
        {

            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var query = from examQuestion in context.ExamQuestions
                            where examQuestion.ExamId == examId && examQuestion.QuestionId == questionId
                            join question in context.Questions
                            on examQuestion.QuestionId equals question.Id
                            join exam in context.Exams
                            on examQuestion.ExamId equals exam.Id
                            select new Question
                            {
                                Id = examQuestion.QuestionId,
                                QuestionText = question.QuestionText,
                                Answer1 = question.Answer1,
                                Answer2 = question.Answer2,
                                Answer3 = question.Answer3,
                                Answer4 = question.Answer4,
                                RightAnswer = question.RightAnswer,
                                Score = question.Score
                            };

                

                return query.ToList();
            }

        }
    }
}
