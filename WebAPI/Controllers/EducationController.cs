using Business.Abstract;
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
        var result = _educationService.GetAll();
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
}
