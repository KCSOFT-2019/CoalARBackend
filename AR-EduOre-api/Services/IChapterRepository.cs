using AR_EduOre_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AR_EduOre_api.Services;

public interface IChapterRepository : IRepositoryBase<Chapter>, IRepositoryBase2<Chapter, Guid>
{

    public Task<Chapter> getHead(Guid id);

    public Task<Guid?> getNext(Guid? chapter_id);

}