using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YesNoQuestionController : ControllerBase
    {
        private readonly IYesNoQuestionService _yesnoQuestionService;
        public YesNoQuestionController(IYesNoQuestionService yesnoQuestionService)
        {
            _yesnoQuestionService = yesnoQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetYesNoQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'YesNO'";
            var result = await _yesnoQuestionService.GetYesNoQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYesNoQuestion(YesNoQuestionDTO yesnoQuestionDTO)
        {
            yesnoQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _yesnoQuestionService.CreateYesNoQuestion(yesnoQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateYesNoQuestion(YesNoQuestionDTO yesnoQuestionsDTO)
        {

            var result = await _yesnoQuestionService.UpdateYesNoQuestion(yesnoQuestionsDTO);
            return Ok(result);
        }
    }
}