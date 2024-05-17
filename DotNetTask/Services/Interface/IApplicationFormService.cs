using DotNetTask.Domain.DTOs;

namespace DotNetTask.Services.Interface
{
    public interface IApplicationFormService
    {
        Task<List<ApplicationFormDTO>> GetApplications(string sqlCosmosQuery);
        Task<ApplicationFormDTO> CreateApplication(ApplicationFormDTO applicationFormDTO);
        Task<ApplicationFormDTO> UpdateApplication(ApplicationFormDTO applicationFormDTO);
    }
}