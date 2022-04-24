using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IDailyQuestionRepository _dailyQuestionRepository;
        private IUserInformationRepository _userInformationRepository;
        private ICourseEquipmentRepository _courseEquipmentRepository;
        private ICourseTeacherProfileRepository _teacherProfileRepository;
        private IOnlineCourseRepository _onlineCourseRepository;
        private IOfflineCourseRepository _offlineCourseRepository;
        private ICourseStudentProfileRepository _studentProfileRepository;
        private IChapterRepository _chapterRepository;
        public RepositoryWrapper(ARDbContext ardbcontext)
        {
            ARDBContext = ardbcontext;
        }


        public IDailyQuestionRepository DailyQuestion => _dailyQuestionRepository ?? new DailyQuestionRepository(ARDBContext);
        public IUserInformationRepository UserInformation => _userInformationRepository ?? new UserInformationRepository(ARDBContext);

        public ICourseEquipmentRepository CourseEquipment =>
            _courseEquipmentRepository ?? new CourseEquipmentRepository(ARDBContext);

        public ICourseTeacherProfileRepository CourseTeacherProfile =>
            _teacherProfileRepository ?? new CourseTeacherProfileRepository(ARDBContext);

        public IOnlineCourseRepository OnlineCourse =>
            _onlineCourseRepository ?? new OnlineCourseRepository(ARDBContext);

        public IOfflineCourseRepository OfflineCourse =>
            _offlineCourseRepository ?? new OfflineCourseRepository(ARDBContext);

        public ICourseStudentProfileRepository CourseStudentProfile => _studentProfileRepository ?? new CourseStudentProfileRepository(ARDBContext);
        
        public IChapterRepository Chapter => _chapterRepository ?? new ChapterRepository(ARDBContext);
        public ARDbContext ARDBContext { get; }
    }
}
