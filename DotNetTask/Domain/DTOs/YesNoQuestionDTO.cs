namespace DotNetTask.Domain.DTOs
{
    public class YesNoQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "YesNo";
        public bool IsRequired { get; set; }
    }
}