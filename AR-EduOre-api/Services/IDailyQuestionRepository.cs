using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services
{
    public interface IDailyQuestionRepository : IRepositoryBase<DailyQuestion>, IRepositoryBase2<DailyQuestion, int>
    {

    }
}
