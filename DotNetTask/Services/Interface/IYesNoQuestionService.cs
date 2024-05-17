using DotNetTask.Domain.DTOs;

namespace DemoApi.Services.Interface
{
    public interface IYesNoQuestionService
    {
        Task<List<YesNoQuestionDTO>> GetYesNoQuestions(string sqlCosmosQuery);
        Task<YesNoQuestionDTO> CreateYesNoQuestion(YesNoQuestionDTO yesnoQuestionDTO);
        Task<YesNoQuestionDTO> UpdateYesNoQuestion(YesNoQuestionDTO yesnoQuestionDTO);
    }
}