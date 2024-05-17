using AutoMapper;
using DemoApi.Services.Interface;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using Microsoft.Azure.Cosmos;

namespace DemoApi.Services.Implementaion
{
    public class ParagraphQuestionService : IParagraphQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public ParagraphQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Questions";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<ParagraphQuestionDTO> CreateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionDTO)
        {
            var question = _mapper.Map<ParagraphQuestion>(paragraphQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return paragraphQuestionDTO;
        }

        public async Task<List<ParagraphQuestionDTO>> GetParagraphQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<ParagraphQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<ParagraphQuestion> responseList = new List<ParagraphQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<ParagraphQuestionDTO>>(responseList);

            return result;
        }

        public async Task<ParagraphQuestionDTO> UpdateParagraphQuestion(ParagraphQuestionDTO paragraphQuestionDTO)
        {
            var paragraphquestion = _mapper.Map<ParagraphQuestion>(paragraphQuestionDTO);
            await _questionContainer.UpsertItemAsync(paragraphquestion);
            return paragraphQuestionDTO;
        }

    }
}