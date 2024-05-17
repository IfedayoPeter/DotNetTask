using DotNetTask.Domain.Models;
using DotNetTask.Services.Helpers;
using DotNetTask.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IPersonalInformationService _personalInformationService;
        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalInformations()
        {
            var sqlCosmosQuery = "SELECT * FROM c WHERE IS_DEFINED(c.Email)";
            var result = await _personalInformationService.GetPersonalInformations(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonalInformation(PersonalInformationDTO personalInformationDTO)
        {
            personalInformationDTO.UserId = new RandomGenerator().GenerateRandomCode(5);
            var result = await _personalInformationService.CreatePersonalInformation(personalInformationDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformation(PersonalInformationDTO personalInformationsDTO)
        {

            var result = await _personalInformationService.UpdatePersonalInformation(personalInformationsDTO);
            return Ok(result);
        }
    }
}