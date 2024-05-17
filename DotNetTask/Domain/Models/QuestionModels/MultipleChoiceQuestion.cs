using Newtonsoft.Json;

namespace DotNetTask.Domain.Models.QuestionModels
{
    public class MultipleChoiceQuestion
    {
        [JsonProperty("id")]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "MultipleChoice";
        public List<string> Choices { get; set; }
        public bool AllowMultipleSelections { get; set; }
        public bool IsRequired { get; set; }

        public MultipleChoiceQuestion()
        {
            Choices = new List<string>();
        }
        public object Response { get; set; }

    }

}