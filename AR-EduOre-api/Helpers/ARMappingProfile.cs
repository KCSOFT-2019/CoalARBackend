using AR_EduOre_api.Entities;
using AR_EduOre_api.Models;
using AutoMapper;

namespace AR_EduOre_api.Helpers
{
    public class ARMappingProfile : Profile
    {
        public ARMappingProfile()
        {
            CreateMap<RegisterUser, UserInformation>();
            CreateMap<LoginUser, UserInformation>();
            CreateMap<UserInformation, UserDto>();
            CreateMap<CourseCreated, CourseEquipment>();
            CreateMap<CourseEquipment, CourseCreated>();
            CreateMap<UpdateCourse, CourseEquipment>();
            CreateMap<CourseEquipment, UpdateCourse>();
            CreateMap<CreatedOnlineCourse, OnlineCourse>()
                .ForMember(dest => dest.online_week, config =>
                    config.MapFrom(src => new TimeSpan(src.online_end_time.Ticks - src.online_begin_time.Ticks).Days / 7 ));
            CreateMap<CreatedOfflineCourse, OfflineCourse>()
                .ForMember(dest => dest.offline_week, config =>
                    config.MapFrom(src => new TimeSpan(src.offline_end_date.Ticks - src.offline_begin_date.Ticks).Days / 7 ));

            CreateMap<ChapterCreated, Chapter>();
        }
    }
}
