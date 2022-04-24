namespace AR_EduOre_api.Services
{
    public interface IRepositoryBase2<T, TId>
    {
        Task<T> GetByIdAsync(TId id);
        Task<bool> isExistAsync(TId id);
    }
}
