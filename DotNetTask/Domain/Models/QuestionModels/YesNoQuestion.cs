using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class YesNoQuestion
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "YesNo";
        public bool IsRequired { get; set; }
        public object? Response { get; set; }
    }
}