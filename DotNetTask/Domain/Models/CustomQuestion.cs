using DotNetTask.Domain.Models.QuestionModels;
using Newtonsoft.Json;

namespace DotNetTask.Domain.Models
{
    public class CustomQuestion
    {
        public DateQuestion DateQuestion { get; set; }
        public DropDownQuestion DropDownQuestion { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
        public NumberQuestion NumberQuestion { get; set; }
        public ParagraphQuestion ParagraphQuestion { get; set; }
        public YesNoQuestion YesNoQuestion { get; set; }
        public object Response { get; set; }

    }
}