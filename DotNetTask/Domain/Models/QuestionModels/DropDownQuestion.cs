using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class DropDownQuestion
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "DropDown"; 
        public List<string> Options { get; set; }
        public bool IsRequired { get; set; }
        public DropDownQuestion()
        {
            Options = new List<string>();
        }
    }
}