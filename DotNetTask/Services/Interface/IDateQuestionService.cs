using DotNetTask.Domain.DTOs;

namespace DemoApi.Services.Interface
{
    public interface IDateQuestionService
    {
        Task<List<DateQuestionDTO>> GetDatQuestions(string sqlCosmosQuery);
        Task<DateQuestionDTO> AddDateQuestion(DateQuestionDTO dateQuestionDTO);
        Task<DateQuestionDTO> UpdateDateQuestion(DateQuestionDTO dateQuestionDTO);

    }
}