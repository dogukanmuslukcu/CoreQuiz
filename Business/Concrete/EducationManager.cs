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
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

    public IDataResult<EducationDto> GetById(int id)
    {
        return new SuccessDataResult<EducationDto>(_educationDal.GetById(id), Messages.SuccessMessage);
    }

    public IDataResult<TimeSpan> GetYouTubeVideoDuration(int ıd)
    {
        string videoId = GetYouTubeVideoId(ıd);
        string apiUrl = "https://www.googleapis.com/youtube/v3/videos?id=" + videoId + "&key=AIzaSyAESoIxDU1ks6Nkyog3MhqnARPknb-8nfU&part=contentDetails";

        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(apiUrl);
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            string durationString = data.items[0].contentDetails.duration;
            var duration = XmlConvert.ToTimeSpan(durationString);
            return new SuccessDataResult<TimeSpan>(duration,Messages.SuccessDataMessage);
        }
    }

    private string GetYouTubeVideoId(int ıd)
    {
        var videoString = _educationDal.GetById(ıd).VideoUrl;

        Uri uri = new Uri(videoString);
        string query = uri.Query;
        return System.Web.HttpUtility.ParseQueryString(query).Get("v");
    }

    public IDataResult<int> GetVote(int educationId)
    {
        var education = _educationDal.Get(v => v.EducationId == educationId);

        if (education == null)
        {
            return new ErrorDataResult<int>(Messages.ObjectDoesNotExist);
        }
        try
        {
           
            int TotalVotes = education.TotalVotes;
            int VoteAmount = education.VoteAmount;

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

    public IResult Vote(int educationId, int vote)
    {
        var education = _educationDal.Get(v => v.EducationId == educationId);

        if (education == null)
        {
            return new ErrorDataResult<int>(Messages.ObjectDoesNotExist);
        }
        if (vote > 5 || vote<=0)
            return new ErrorResult(Messages.VoteCanNotBeGreaterOrLess0To5);
        
        try
        {
            education.VoteAmount += 1;
            education.TotalVotes += vote;
            _educationDal.Update(education);
            return new SuccessResult(Messages.SuccessMessage);
        }
        catch (Exception ex)
        {
            return new ErrorResult(Messages.ErrorMessage);
        }
    }
}
