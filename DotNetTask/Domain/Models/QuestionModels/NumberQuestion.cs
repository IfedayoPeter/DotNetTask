using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class NumberQuestion
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Number";
        public bool IsRequired { get; set; }

    }
}