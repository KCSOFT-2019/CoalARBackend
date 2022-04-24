namespace AR_EduOre_api.Services
{
    public interface IRepositoryWrapper
    {
        IDailyQuestionRepository DailyQuestion { get; }
        IUserInformationRepository UserInformation { get; }
        
        ICourseEquipmentRepository CourseEquipment { get; }
        
        ICourseTeacherProfileRepository CourseTeacherProfile { get; }
        
        IOnlineCourseRepository OnlineCourse { get; }
        
        IOfflineCourseRepository OfflineCourse { get; }
        
        IChapterRepository Chapter { get; }
        
        ICourseStudentProfileRepository CourseStudentProfile { get; }
    }
}
