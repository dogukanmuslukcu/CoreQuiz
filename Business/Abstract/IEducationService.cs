using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Entity;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IEducationService
{
    IDataResult <List<EducationDto>> GetAll();
    IDataResult<List<EducationDto>> GetByExamId(int id);
    IResult GetById(int id);
}
