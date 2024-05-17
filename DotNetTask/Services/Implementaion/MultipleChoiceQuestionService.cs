using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public MultipleChoiceQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Questions";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<MultipleChoiceQuestionDTO> CreateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionDTO)
        {
            var question = _mapper.Map<MultipleChoiceQuestion>(multiplechoiceQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return multiplechoiceQuestionDTO;
        }

        public async Task<List<MultipleChoiceQuestionDTO>> GetMultipleChoiceQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<MultipleChoiceQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<MultipleChoiceQuestion> responseList = new List<MultipleChoiceQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<MultipleChoiceQuestionDTO>>(responseList);

            return result;
        }

        public async Task<MultipleChoiceQuestionDTO> UpdateMultipleChoiceQuestion(MultipleChoiceQuestionDTO multiplechoiceQuestionDTO)
        {
            var multiplechoicequestion = _mapper.Map<MultipleChoiceQuestion>(multiplechoiceQuestionDTO);
            await _questionContainer.UpsertItemAsync(multiplechoicequestion);
            return multiplechoiceQuestionDTO;
        }

    }
}