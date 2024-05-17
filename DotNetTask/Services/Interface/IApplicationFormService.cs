using DotNetTask.Domain.DTOs;

namespace DotNetTask.Services.Interface
{
    public interface IApplicationFormService
    {
        Task<ApplicationFormDTO> CreateApplication(ApplicationFormDTO applicationFormDTO);
        Task<ApplicationFormDTO> UpdateApplication(ApplicationFormDTO applicationFormDTO);
    }
}