using DotNetTask.Domain.Models;

namespace DemoApi.Services.Interface
{
    public interface IPersonalInformationService
    {
        Task<List<PersonalInformationDTO>> GetPersonalInformations(string sqlCosmosQuery);
        Task<PersonalInformationDTO> CreatePersonalInformation(PersonalInformationDTO personalInformationDTO);
        Task<PersonalInformationDTO> UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO);
    }
}