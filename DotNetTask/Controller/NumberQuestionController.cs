using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberQuestionController : ControllerBase
    {
        private readonly INumberQuestionService _numberQuestionService;
        public NumberQuestionController(INumberQuestionService numberQuestionService)
        {
            _numberQuestionService = numberQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNumberQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'Number'";
            var result = await _numberQuestionService.GetNumberQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNumberQuestion(NumberQuestionDTO numberQuestionDTO)
        {
            numberQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _numberQuestionService.CreateNumberQuestion(numberQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNumberQuestion(NumberQuestionDTO numberQuestionsDTO)
        {

            var result = await _numberQuestionService.UpdateNumberQuestion(numberQuestionsDTO);
            return Ok(result);
        }

    }
}