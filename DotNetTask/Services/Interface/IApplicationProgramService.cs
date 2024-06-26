using DotNetTask.Domain.Models;

namespace DotNetTask.Services.Interface
{
    public interface IApplicationProgramService
    {
        Task<List<ApplicationProgramDTO>> GetPrograms(string sqlCosmosQuery);
        Task<ApplicationProgramDTO> GetProgramsByTitle(string programTitle);
        Task<ApplicationProgramDTO> CreateProgram(ApplicationProgramDTO applicationProgramDTO);
        Task<ApplicationProgramDTO> UpdateProgram(ApplicationProgramDTO applicationProgramDTO);

    }
}