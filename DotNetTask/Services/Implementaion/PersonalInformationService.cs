using AutoMapper;
using DotNetTask.Domain.Models;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _applicationContainer;
        private readonly IMapper _mapper;
        private readonly IApplicationProgramService _applicationProgramService;
        public PersonalInformationService(CosmosClient cosmosClient, IConfiguration configuration,
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

        public async Task<PersonalInformationDTO> CreatePersonalInformation(PersonalInformationDTO personalInformationDTO)
        {
            var question = _mapper.Map<PersonalInformation>(personalInformationDTO);
            await _applicationContainer.CreateItemAsync(question);
            return personalInformationDTO;
        }

        public async Task<List<PersonalInformationDTO>> GetPersonalInformations(string sqlCosmosQuery)
        {
            var query = _applicationContainer.GetItemQueryIterator<PersonalInformation>(new QueryDefinition(sqlCosmosQuery));

            List<PersonalInformation> responseList = new List<PersonalInformation>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<PersonalInformationDTO>>(responseList);

            return result;
        }

        public async Task<PersonalInformationDTO> UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO)
        {
            var application = _mapper.Map<PersonalInformation>(personalInformationDTO);
            await _applicationContainer.UpsertItemAsync(application);
            return personalInformationDTO;
        }

    }
}