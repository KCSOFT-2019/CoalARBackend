using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services;

public interface IOfflineCourseRepository : IRepositoryBase<OfflineCourse>, IRepositoryBase2<OfflineCourse, Guid>
{
    
}