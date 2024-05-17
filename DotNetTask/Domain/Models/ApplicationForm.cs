using DotNetTask.Domain.Models;
using Newtonsoft.Json;

namespace DotNetTask.Models
{
    public class ApplicationForm
    {
        [JsonProperty("id")]
        public string ApplicationId { get; set; }

        public ApplicationProgram ApplicationProgram { get; set; }

        public PersonalInformation PersonalInformation { get; set; }

        public List<CustomQuestion> CustomQuestions { get; set; }
    }
}