using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class DateQuestionService : IDateQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public DateQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Questions";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<DateQuestionDTO> AddDateQuestion(DateQuestionDTO dateQuestionDTO)
        {
            var question = _mapper.Map<DateQuestion>(dateQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return dateQuestionDTO;
        }

        public async Task<List<DateQuestionDTO>> GetDatQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<DateQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<DateQuestion> responseList = new List<DateQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<DateQuestionDTO>>(responseList);

            return result;
        }

        public async Task<DateQuestionDTO> UpdateDateQuestion(DateQuestionDTO dateQuestionDTO)
        {
            var datequestion = _mapper.Map<DateQuestion>(dateQuestionDTO);
            await _questionContainer.UpsertItemAsync(datequestion);
            return dateQuestionDTO;
        }

    }
}