using Core.DataAccess;
using Entity;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;
public interface IEducationDal :IEntityRepository<Education>
{
    List<EducationDto> GetAll();
    List<EducationDto> GetByExamId(int Id);
    EducationDto GetById(int Id);
}
