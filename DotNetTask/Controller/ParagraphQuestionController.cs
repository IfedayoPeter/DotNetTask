using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParagraphQuestionController : ControllerBase
    {
        private readonly IParagraphQuestionService _paragraphQuestionService;
        public ParagraphQuestionController(IParagraphQuestionService paragraphQuestionService)
        {
            _paragraphQuestionService = paragraphQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetParagraphQuestions()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE c.questiontype = 'Paragraph'";
            var result = await _paragraphQuestionService.GetParagraphQuestions(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionDTO)
        {
            paragraphQuestionDTO.QuestionId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _paragraphQuestionService.CreateParagraphQuestion(paragraphQuestionDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionsDTO)
        {

            var result = await _paragraphQuestionService.UpdateParagraphQuestion(paragraphQuestionsDTO);
            return Ok(result);
        }
    }
}