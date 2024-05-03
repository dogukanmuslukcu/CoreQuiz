using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationController : ControllerBase
{
    private readonly IEducationService _educationService;

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }
    [HttpGet("getAllEducationDto")]
    public IActionResult GetAllEducationDto()
    {
        var result = _educationService.GetAllEducationDto();
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
    [HttpGet("getByExamId")]
    public IActionResult GetByExamId(int id)
    {
        var result = _educationService.GetByExamId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        var result = _educationService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
    [HttpGet("getVideoTimeById")]
    public IActionResult GetVideoTimeById(int id) 
    {
        var result = _educationService.GetYouTubeVideoDuration(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }

    }
    [HttpGet("getVote")]
    public IActionResult GetVote(int id)
    {
        var result = _educationService.GetVote(id);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
    [HttpPost("vote")]
    public IActionResult Vote(int educationId, int vote)
    {
        var result = _educationService.Vote(educationId, vote);
        if (result.Success)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
}
