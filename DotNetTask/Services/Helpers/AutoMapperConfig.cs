using AutoMapper;
using DotNetTask.Domain.DTOs;
using DotNetTask.Domain.Models;
using DotNetTask.Domain.Models.QuestionModels;
using DotNetTask.Models;

namespace DotNetTask.Services.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ApplicationForm, ApplicationFormDTO>()
                .ReverseMap();
            CreateMap<ApplicationProgram, ApplicationProgramDTO>()
                .ReverseMap();
            CreateMap<CustomQuestion, CustomQuestionsDTO>()
            .ReverseMap();
            CreateMap<DateQuestion, DateQuestionDTO>()
                .ReverseMap();
            CreateMap<DropDownQuestion, DropDownQuestionDTO>()
                .ReverseMap();
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDTO>()
                .ReverseMap();
            CreateMap<NumberQuestion, NumberQuestionDTO>()
                .ReverseMap();
            CreateMap<ParagraphQuestion, ParagraphQuestionDTO>()
                .ReverseMap();
            CreateMap<YesNoQuestion, YesNoQuestionDTO>()
                .ReverseMap();
            CreateMap<PersonalInformation, PersonalInformationDTO>()
                .ReverseMap();

        }

    }
}