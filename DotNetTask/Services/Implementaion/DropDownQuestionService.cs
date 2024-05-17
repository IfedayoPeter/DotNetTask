using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models.QuestionModels;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class DropDownQuestionService : IDropDownQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _questionContainer;
        private readonly IMapper _mapper;
        public DropDownQuestionService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var questionsContainerName = "Applications";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionsContainerName);
        }

        public async Task<DropDownQuestionDTO> CreateDropDownQuestion(DropDownQuestionDTO dropdownQuestionDTO)
        {
            var question = _mapper.Map<DropDownQuestion>(dropdownQuestionDTO);
            await _questionContainer.CreateItemAsync(question);
            return dropdownQuestionDTO;
        }

        public async Task<List<DropDownQuestionDTO>> GetDropDownQuestions(string sqlCosmosQuery)
        {
            var query = _questionContainer.GetItemQueryIterator<DropDownQuestion>(new QueryDefinition(sqlCosmosQuery));

            List<DropDownQuestion> responseList = new List<DropDownQuestion>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<DropDownQuestionDTO>>(responseList);

            return result;
        }

        public async Task<DropDownQuestionDTO> UpdateDropDownQuestion(DropDownQuestionDTO dropdownQuestionDTO)
        {
            var dropdownquestion = _mapper.Map<DropDownQuestion>(dropdownQuestionDTO);
            await _questionContainer.UpsertItemAsync(dropdownquestion);
            return dropdownQuestionDTO;
        }

    }
}