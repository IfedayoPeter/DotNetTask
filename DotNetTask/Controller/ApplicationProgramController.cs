using DotNetTask.Domain.Models;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationProgramController : ControllerBase
    {
        private readonly IApplicationProgramService _applicationProgramService;
        public ApplicationProgramController(IApplicationProgramService applicationProgramService)
        {
            _applicationProgramService = applicationProgramService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE IS_DEFINED(c.ProgramTitle)";
            var result = await _applicationProgramService.GetPrograms(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpGet("/byTitle")]
        public async Task<IActionResult> GetProgramsByTitle(string programTitle)
        {
            var result = await _applicationProgramService.GetProgramsByTitle(programTitle);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(ApplicationProgramDTO applicationProgramDTO)
        {
            applicationProgramDTO.ProgramId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _applicationProgramService.CreateProgram(applicationProgramDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgram(ApplicationProgramDTO applicationProgramsDTO)
        {

            var result = await _applicationProgramService.UpdateProgram(applicationProgramsDTO);
            return Ok(result);
        }
    }
}