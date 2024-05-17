namespace DotNetTask.Domain.DTOs
{
    public class CustomQuestionsDTO
    {
        public DateQuestionDTO DateQuestion { get; set; }
        public DropDownQuestionDTO DropDownQuestion { get; set; }
        public MultipleChoiceQuestionDTO MultipleChoiceQuestion { get; set; }
        public NumberQuestionDTO NumberQuestion { get; set; }
        public ParagraphQuestionDTO ParagraphQuestion { get; set; }
        public YesNoQuestionDTO YesNoQuestion { get; set; }
    }
}