using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services;

public interface ICourseEquipmentRepository : IRepositoryBase<CourseEquipment>, IRepositoryBase2<CourseEquipment, Guid>
{
    
}