using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class ParagraphQuestion
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Paragraph";
        public bool IsRequired { get; set; }
        public object? Response { get; set; }
    }
}