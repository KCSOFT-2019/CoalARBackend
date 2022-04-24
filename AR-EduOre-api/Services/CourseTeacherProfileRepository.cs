using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class CourseTeacherProfileRepository : RepositoryBase<CourseTeacherProfile, Guid>, ICourseTeacherProfileRepository
{
    public CourseTeacherProfileRepository(DbContext dbContext) : base(dbContext)
    {
    }

    
    public  Task<IEnumerable<CourseTeacherProfile>> GetByUserIdAsync(Guid id)
    {
        return Task.FromResult<IEnumerable<CourseTeacherProfile>>(DbContext.Set<CourseTeacherProfile>().Where(o => o.UserId == id).AsEnumerable()); 
        throw new NotImplementedException();
    }

    public async Task<bool> isExistUserIdAsync(Guid id)
    {
        return await DbContext.Set<CourseTeacherProfile>().Where(o => o.UserId == id).FirstOrDefaultAsync() != null;
        throw new NotImplementedException();
    }

    public async Task<bool> hasOnlineCourse(Guid id)
    {
        var tea = await DbContext.Set<CourseTeacherProfile>().Where(o => o.UserId == id).FirstOrDefaultAsync();
        return tea.online_id != null;
        new NotImplementedException();
    }

    public async Task<bool> hasOfflineCourse(Guid id)
    {
        var tea = await DbContext.Set<CourseTeacherProfile>().Where(o => o.UserId == id).FirstOrDefaultAsync();
        return tea.offline_id != null;
        throw new NotImplementedException();
    }

    public async Task<bool> hasOpenCourse(Guid id)
    {
        var tea = await DbContext.Set<CourseTeacherProfile>().Where(o => o.UserId == id).FirstOrDefaultAsync();
        return tea.open_id != null;
        throw new NotImplementedException();
    }
}