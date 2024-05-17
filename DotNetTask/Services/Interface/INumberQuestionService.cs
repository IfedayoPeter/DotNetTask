using DotNetTask.Domain.DTOs;

namespace DotNetTask.Services.Interface
{
    public interface INumberQuestionService
    {
        Task<List<NumberQuestionDTO>> GetNumberQuestions(string sqlCosmosQuery);
        Task<NumberQuestionDTO> CreateNumberQuestion(NumberQuestionDTO numberQuestionDTO);
        Task<NumberQuestionDTO> UpdateNumberQuestion(NumberQuestionDTO numberQuestionDTO);
    }
}