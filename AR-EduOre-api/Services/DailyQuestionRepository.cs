using AR_EduOre_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services
{
    public class DailyQuestionRepository : RepositoryBase<DailyQuestion, int>, IDailyQuestionRepository
    {
        public DailyQuestionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
