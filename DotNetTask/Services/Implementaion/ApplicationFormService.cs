using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Models;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _applicationContainer;
        private readonly IMapper _mapper;
        private readonly IApplicationProgramService _applicationProgramService;
        public ApplicationFormService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper, IApplicationProgramService applicationProgramService)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            _applicationProgramService = applicationProgramService;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var applicationsContainerName = "Applications";
            _applicationContainer = cosmosClient.GetContainer(databaseName, applicationsContainerName);
        }

        public async Task<ApplicationFormDTO> CreateApplication(ApplicationFormDTO applicationFormDTO)
        {
            var question = _mapper.Map<ApplicationForm>(applicationFormDTO);
            await _applicationContainer.CreateItemAsync(question);
            return applicationFormDTO;
        }

        public async Task<List<ApplicationFormDTO>> GetApplications(string sqlCosmosQuery)
        {
            var query = _applicationContainer.GetItemQueryIterator<ApplicationForm>(new QueryDefinition(sqlCosmosQuery));

            List<ApplicationForm> responseList = new List<ApplicationForm>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<ApplicationFormDTO>>(responseList);

            return result;
        }

        public async Task<ApplicationFormDTO> UpdateApplication(ApplicationFormDTO applicationFormDTO)
        {
            var application = _mapper.Map<ApplicationForm>(applicationFormDTO);
            await _applicationContainer.UpsertItemAsync(application);
            return applicationFormDTO;
        }

    }
}