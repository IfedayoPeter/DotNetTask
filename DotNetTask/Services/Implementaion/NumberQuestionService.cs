using AutoMapper;
using DemoApi.Services.Interface;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using Microsoft.Azure.Cosmos;

namespace DemoApi.Services.Implementaion
{
    public class NumberQuestionService : INumberQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public NumberQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Questions";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<NumberQuestionDTO> CreateNumberQuestion(NumberQuestionDTO numberQuestionDTO)
        {
            var question = _mapper.Map<NumberQuestion>(numberQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return numberQuestionDTO;
        }

        public async Task<List<NumberQuestionDTO>> GetNumberQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<NumberQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<NumberQuestion> responseList = new List<NumberQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<NumberQuestionDTO>>(responseList);

            return result;
        }

        public async Task<NumberQuestionDTO> UpdateNumberQuestion(NumberQuestionDTO numberQuestionDTO)
        {
            var numberquestion = _mapper.Map<NumberQuestion>(numberQuestionDTO);
            await _questionContainer.UpsertItemAsync(numberquestion);
            return numberQuestionDTO;
        }

    }
}