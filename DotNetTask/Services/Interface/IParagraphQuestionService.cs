using DotNetTask.Domain.DTOs;

namespace DemoApi.Services.Interface
{
    public interface IParagraphQuestionService
    {
        Task<List<ParagraphQuestionDTO>> GetParagraphQuestions(string sqlCosmosQuery);
        Task<ParagraphQuestionDTO> UpdateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionDTO);
        Task<ParagraphQuestionDTO> CreateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionDTO);
    }
}