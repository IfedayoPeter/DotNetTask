using Newtonsoft.Json;

namespace DotNetTask.Domain.Models
{
    public class ApplicationProgram
    {
        [JsonProperty("id")]
        public string ProgramId { get; set; }

        public string ProgramTitle { get; set; }

        public string ProgramDescription { get; set; }
    }
}