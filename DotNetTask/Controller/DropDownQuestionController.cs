using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropDownQuestionController : ControllerBase
    {
        private readonly IDropDownQuestionService _dropdownQuestionService;
        public DropDownQuestionController(IDropDownQuestionService dropdownQuestionService)
        {
            _dropdownQuestionService = dropdownQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDropDownQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'Dropdown'";
            var result = await _dropdownQuestionService.GetDropDownQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDropDownQuestion(DropDownQuestionDTO dropdownQuestionDTO)
        {
            dropdownQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _dropdownQuestionService.CreateDropDownQuestion(dropdownQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDropDownQuestion(DropDownQuestionDTO dropdownQuestionsDTO)
        {

            var result = await _dropdownQuestionService.UpdateDropDownQuestion(dropdownQuestionsDTO);
            return Ok(result);
        }
    }
}