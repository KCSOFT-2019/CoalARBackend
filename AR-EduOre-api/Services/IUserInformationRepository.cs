using AR_EduOre_api.Entities;

namespace AR_EduOre_api.Services
{
    public interface IUserInformationRepository : IRepositoryBase<UserInformation>, IRepositoryBase2<UserInformation, Guid>
    {
        Task<IEnumerable<UserInformation>> GetClassmates(string telephone);
        
        
        Task<bool> isTelephoneExistAsync(string telephone);
    }
}
