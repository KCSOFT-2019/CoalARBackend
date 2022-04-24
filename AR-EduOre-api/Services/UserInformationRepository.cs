using AR_EduOre_api.Entities;
using AR_EduOre_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services
{
    public class UserInformationRepository : RepositoryBase<UserInformation, Guid>, IUserInformationRepository
    {
        public UserInformationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<UserInformation>> GetClassmates(string telephone)
        {
            var lesson = DbContext.Set<UserInformation>().Where(user => user.telephone == telephone).FirstOrDefault()
                .lesson;
            if (lesson == null) return Task.FromResult<IEnumerable<UserInformation>>(null);
            return Task.FromResult(DbContext.Set<UserInformation>().Where(user => user.lesson == lesson)
                .AsEnumerable());
        }

        public async Task<bool> isTelephoneExistAsync(string telephone)
        {
            return await DbContext.Set<UserInformation>().Where(o => o.telephone == telephone).FirstOrDefaultAsync()!= null;
            throw new NotImplementedException();
        }


        
    }
}
