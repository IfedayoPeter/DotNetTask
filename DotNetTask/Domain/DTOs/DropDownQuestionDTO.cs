namespace DotNetTask.Domain.DTOs
{
    public class DropDownQuestionDTO
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType => "DropDown"; 
        public List<string> Options { get; set; }
        public bool IsRequired { get; set; }
        public DropDownQuestionDTO()
        {
            Options = new List<string>();
        }
    }
}