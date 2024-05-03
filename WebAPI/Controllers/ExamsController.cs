using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("getAllExams")]
        public ActionResult GetAllExams()
        {
            var result = _examService.GetAllExams();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getExamDetailsById")]
        public IActionResult GetExamDetailsById(int Id)
        {
            var result = _examService.GetExamDetailsById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getExamById")]
        public IActionResult GetById(int Id)
        {
            var result = _examService.GetExamById(Id);
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
        public IActionResult GetVote(int examId)
        {
            var result = _examService.GetVote(examId);
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
        public IActionResult Vote(int examId, int vote)
        {
            var result = _examService.Vote(examId, vote);
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
}
