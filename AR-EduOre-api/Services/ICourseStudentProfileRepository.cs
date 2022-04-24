using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services;

public interface ICourseStudentProfileRepository : IRepositoryBase<CourseStudentProfile>, IRepositoryBase2<CourseStudentProfile, Guid>
{
    
}