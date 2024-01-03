using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService; 
        }
        [HttpGet("getQuestionById")]
        public IActionResult GetQuestionById(int questionId)
        {
            var result = _questionService.GetQuestionById(questionId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getQuestionDetailsByExamId")]
        public IActionResult GetQuestionDetailsByExamId(int examId, int questionId)
        {
            var result = _questionService.GetQuestionDetailsByExamId(examId, questionId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        
        [HttpPost("checkUserPointWithQuestion")]
        public IActionResult CheckUserPointWithQuestion(int examId, int questionId, string userAnswer, int userId)
        {
            var result = _questionService.CheckUserPointWithQuestion(examId,questionId, userAnswer, userId);
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
