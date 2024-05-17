namespace DotNetTask.Domain.DTOs
{
    public class NumberQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "Number";
        public bool IsRequired { get; set; }
        public object Response { get; set; }
    }
    

}