using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultipleChoiceQuestionController : ControllerBase
    {
        private readonly IMultipleChoiceQuestionService _multiplechoiceQuestionService;
        public MultipleChoiceQuestionController(IMultipleChoiceQuestionService multiplechoiceQuestionService)
        {
            _multiplechoiceQuestionService = multiplechoiceQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMultipleChoiceQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'MultipleChoice'";
            var result = await _multiplechoiceQuestionService.GetMultipleChoiceQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionDTO)
        {
            multiplechoiceQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _multiplechoiceQuestionService.CreateMultipleChoiceQuestion(multiplechoiceQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionsDTO)
        {

            var result = await _multiplechoiceQuestionService.UpdateMultipleChoiceQuestion(multiplechoiceQuestionsDTO);
            return Ok(result);
        }
    }
}