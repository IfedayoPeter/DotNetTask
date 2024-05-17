using DotNetTask.Domain.DTOs;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService _applicationFormService;
        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE IS_DEFINED(c.questionText)";
            var result = await _applicationFormService.GetApplications(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationFormDTO applicationFormDTO)
        {
            applicationFormDTO.ApplicationId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _applicationFormService.CreateApplication(applicationFormDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(ApplicationFormDTO applicationFormsDTO)
        {

            var result = await _applicationFormService.UpdateApplication(applicationFormsDTO);
            return Ok(result);
        }

    }
}