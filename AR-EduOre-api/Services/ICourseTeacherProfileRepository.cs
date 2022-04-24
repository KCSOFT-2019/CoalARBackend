using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services;

public interface ICourseTeacherProfileRepository : IRepositoryBase<CourseTeacherProfile>, IRepositoryBase2<CourseTeacherProfile, Guid>
{
    Task<IEnumerable<CourseTeacherProfile>> GetByUserIdAsync(Guid id);
    Task<bool> isExistUserIdAsync(Guid id);

    Task<bool> hasOnlineCourse(Guid id);

    Task<bool> hasOfflineCourse(Guid id);
    Task<bool> hasOpenCourse(Guid id);
}