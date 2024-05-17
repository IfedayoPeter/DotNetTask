namespace DotNetTask.Domain.DTOs
{
    public class MultipleChoiceQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "MultipleChoice";
        public List<string> Choices { get; set; }
        public bool AllowMultipleSelections { get; set; }
        public bool IsRequired { get; set; }

        public MultipleChoiceQuestionDTO()
        {
            Choices = new List<string>();
        }
    }

}