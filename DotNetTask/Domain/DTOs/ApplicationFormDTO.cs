using DotNetTask.Domain.Models;

namespace DotNetTask.Domain.DTOs
{
    public class ApplicationFormDTO
    {
        public string ApplicationId { get; set; }

        public ApplicationProgramDTO ApplicationProgram { get; set; }

        public PersonalInformationDTO PersonalInformation { get; set; }

        public List<CustomQuestionsDTO> CustomQuestions { get; set; }
    }
}