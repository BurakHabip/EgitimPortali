using AutoMapper;
using EgitimPortali.Models;
using EgitimPortali.ViewModels;

namespace EgitimPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Education, EducationModel>().ReverseMap();
            CreateMap<Lesson, LessonModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, RegisterModel>().ReverseMap();
            CreateMap<Todo, TodoModel>().ReverseMap();
        }
    }
}
