namespace DotNetTask.Domain.DTOs
{
    public class DateQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Date";
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public bool IsRequired { get; set; }
        public DateTime Response { get; set; }

    }
}