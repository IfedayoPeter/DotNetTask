namespace DotNetTask.Domain.DTOs
{
    public class ParagraphQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Paragraph";
        public bool IsRequired { get; set; }
        public object Response { get; set; }
    }
}