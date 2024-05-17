using DotNetTask.Domain.DTOs;

namespace DemoApi.Services.Interface
{
    public interface IDropDownQuestionService
    {
        Task<List<DropDownQuestionDTO>> GetDropDownQuestions(string sqlCosmosQuery);
        Task<DropDownQuestionDTO> CreateDropDownQuestion(DropDownQuestionDTO dropdownQuestionDTO);
        Task<DropDownQuestionDTO> UpdateDropDownQuestion(DropDownQuestionDTO dropdownQuestionDTO);
    }
}