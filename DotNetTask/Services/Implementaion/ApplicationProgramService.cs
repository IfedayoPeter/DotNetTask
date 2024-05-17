using AutoMapper;
using DotNetTask.Domain.Models;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

namespace DotNetTask.Services.Implementaion
{
    public class ApplicationProgramService : IApplicationProgramService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _applicationContainer;
        private readonly IMapper _mapper;
        public ApplicationProgramService(CosmosClient cosmosClient, IConfiguration configuration,
        IMapper mapper)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            _mapper = mapper;
            var databaseName = configuration["AzureCosmosDBSettings:DatabaseName"];
            var applicationsContainerName = "Applications";
            _applicationContainer = cosmosClient.GetContainer(databaseName, applicationsContainerName);
        }

        public async Task<ApplicationProgramDTO> CreateProgram(ApplicationProgramDTO applicationProgramDTO)
        {
            var question = _mapper.Map<ApplicationProgram>(applicationProgramDTO);
            await _applicationContainer.CreateItemAsync(question);
            return applicationProgramDTO;
        }

        public async Task<List<ApplicationProgramDTO>> GetPrograms(string sqlCosmosQuery)
        {
            var query = _applicationContainer.GetItemQueryIterator<ApplicationProgram>(new QueryDefinition(sqlCosmosQuery));

            List<ApplicationProgram> responseList = new List<ApplicationProgram>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            var result = _mapper.Map<List<ApplicationProgramDTO>>(responseList);

            return result;
        }

        public async Task<ApplicationProgramDTO> GetProgramsByTitle(string programTitle)
        {
            var query = _applicationContainer.GetItemQueryIterator<ApplicationProgram>(
                new QueryDefinition($"SELECT * FROM c WHERE c.ProgramTitle = @programTitle")
                    .WithParameter("@programTitle", programTitle));

            List<ApplicationProgram> responseList = new List<ApplicationProgram>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                responseList.AddRange(response);
            }

            if (responseList.Count == 0)
            {
                // Return null or throw an exception indicating that the program was not found
                return null;
            }

            // Assuming there should be only one program with the given title
            var result = _mapper.Map<ApplicationProgramDTO>(responseList.First());
            return result;
        }
        public async Task<ApplicationProgramDTO> UpdateProgram(ApplicationProgramDTO applicationProgramDTO)
        {
            var application = _mapper.Map<ApplicationProgram>(applicationProgramDTO);
            await _applicationContainer.UpsertItemAsync(application);
            return applicationProgramDTO;
        }
    }
}