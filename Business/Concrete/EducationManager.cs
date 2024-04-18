using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;
public class EducationManager : IEducationService
{
    private readonly IEducationDal _educationDal;

    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }

    public IDataResult<List<EducationDto>> GetAllEducationDto()
    {
       return new SuccessDataResult<List<EducationDto>>(_educationDal.GetAllEducationDto(), Messages.SuccessDataMessage);
    }

    public IDataResult<List<EducationDto>> GetByExamId(int id)
    {
        return new SuccessDataResult<List<EducationDto>>(_educationDal.GetByExamId(id), Messages.SuccessDataMessage);
    }

    public IResult GetById(int id)
    {
        return new SuccessDataResult<EducationDto>(_educationDal.GetById(id), Messages.SuccessMessage);
    }
}
