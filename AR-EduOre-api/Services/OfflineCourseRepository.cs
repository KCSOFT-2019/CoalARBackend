using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class OfflineCourseRepository : RepositoryBase<OfflineCourse, Guid>, IOfflineCourseRepository
{
    public OfflineCourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}