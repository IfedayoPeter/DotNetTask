using DotNetTask.Domain.DTOs;

namespace DotNetTask.Services.Interface
{
    public interface IMultipleChoiceQuestionService
    {
        Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestions(string sqlCosmosQuery);
        Task<MultipleChoiceQuestionDTO> CreateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionDTO);
        Task<MultipleChoiceQuestionDTO> UpdateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionDTO);
    }
}