using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class YesNoQuestionService : IYesNoQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public YesNoQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Applications";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<YesNoQuestionDTO> CreateYesNoQuestion(YesNoQuestionDTO yesnoQuestionDTO)
        {
            var question = _mapper.Map<YesNoQuestion>(yesnoQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return yesnoQuestionDTO;
        }

        public async Task<List<YesNoQuestionDTO>> GetYesNoQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<YesNoQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<YesNoQuestion> responseList = new List<YesNoQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<YesNoQuestionDTO>>(responseList);

            return result;
        }

        public async Task<YesNoQuestionDTO> UpdateYesNoQuestion(YesNoQuestionDTO yesnoQuestionDTO)
        {
            var yesnoquestion = _mapper.Map<YesNoQuestion>(yesnoQuestionDTO);
            await _questionContainer.UpsertItemAsync(yesnoquestion);
            return yesnoQuestionDTO;
        }
    }
}