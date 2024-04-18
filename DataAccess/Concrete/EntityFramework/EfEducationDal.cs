using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;
public class EfEducationDal : IEfEntityRepositoryBase<Education, ReCapProjectDBContext>, IEducationDal
{
    public List<EducationDto> GetAllEducationDto()
    {
        using(ReCapProjectDBContext context = new ReCapProjectDBContext())
            {

                var resultList = from edu in context.Educations
                                 join exam in context.Exams
                                 on edu.ExamId equals exam.Id
                                 select new EducationDto
                                 {
                                     EducationId = edu.EducationId,
                                     ContentName = exam.ExamName,
                                     EducationName = edu.EducationName,
                                     EducationDescription = edu.EducationDescription,
                                     ContentImageUrl = edu.ContentImageUrl,
                                     VideoUrl = edu.VideoUrl
                                 };

                return resultList.ToList();

            }
    }

    public List<EducationDto> GetByExamId(int Id)
    {
        using (ReCapProjectDBContext context = new ReCapProjectDBContext())
        {

            var resultList = from edu in context.Educations
                             where edu.ExamId == Id
                             join exam in context.Exams
                             on edu.ExamId equals exam.Id
                             select new EducationDto
                             {
                                 EducationId = edu.EducationId,
                                 ContentName = exam.ExamName,
                                 EducationName = edu.EducationName,
                                 EducationDescription = edu.EducationDescription,
                                 ContentImageUrl = edu.ContentImageUrl,
                                 VideoUrl = edu.VideoUrl
                             };

            return resultList.ToList();

        }
    }

    public EducationDto GetById(int Id)
    {
        using (ReCapProjectDBContext context = new ReCapProjectDBContext())
        {

            var resultList = from edu in context.Educations
                             where edu.EducationId == Id
                             join exam in context.Exams
                             on edu.ExamId equals exam.Id
                             select new EducationDto
                             {
                                 EducationId = edu.EducationId,
                                 ContentName = exam.ExamName,
                                 EducationName = edu.EducationName,
                                 EducationDescription = edu.EducationDescription,
                                 ContentImageUrl = edu.ContentImageUrl,
                                 VideoUrl = edu.VideoUrl
                             };

            return resultList.FirstOrDefault();

        }
    }
}
