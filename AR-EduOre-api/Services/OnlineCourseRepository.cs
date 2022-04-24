using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class OnlineCourseRepository : RepositoryBase<OnlineCourse, Guid>, IOnlineCourseRepository
{
    public OnlineCourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}