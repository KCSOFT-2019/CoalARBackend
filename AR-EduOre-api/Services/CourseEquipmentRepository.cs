using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class CourseEquipmentRepository : RepositoryBase<CourseEquipment, Guid> , ICourseEquipmentRepository
{
    public CourseEquipmentRepository(DbContext dbContext) : base(dbContext)
    {
    }
}