using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateQuestionController : ControllerBase
    {
        private readonly IDateQuestionService _dateQuestionService;
        public DateQuestionController(IDateQuestionService dateQuestionService)
        {
            _dateQuestionService = dateQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDatQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'Date'";
            var result = await _dateQuestionService.GetDatQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDateQuestion(DateQuestionDTO dateQuestionDTO)
        {
            dateQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _dateQuestionService.AddDateQuestion(dateQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDateQuestion(DateQuestionDTO dateQuestionsDTO)
        {

            var result = await _dateQuestionService.UpdateDateQuestion(dateQuestionsDTO);
            return Ok(result);
        }
    }
}