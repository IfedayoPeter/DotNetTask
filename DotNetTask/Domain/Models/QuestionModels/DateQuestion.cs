using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class DateQuestion 
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Date";
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public bool IsRequired { get; set; }
        public string? Response { get; set; }
    }

}