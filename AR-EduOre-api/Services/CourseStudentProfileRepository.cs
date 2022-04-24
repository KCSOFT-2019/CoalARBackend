using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class CourseStudentProfileRepository : RepositoryBase<CourseStudentProfile, Guid>, ICourseStudentProfileRepository
{
    public CourseStudentProfileRepository(DbContext dbContext) : base(dbContext)
    {
    }
}