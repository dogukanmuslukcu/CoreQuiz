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
    IDataResult <List<EducationDto>> GetAllEducationDto();
    IDataResult<List<EducationDto>> GetByExamId(int id);
    IDataResult<EducationDto> GetById(int id);
    TimeSpan GetYouTubeVideoDuration(int ıd);
    IDataResult<int> GetVote(int educationId);
    IResult Vote(int educationId, int vote);
}
