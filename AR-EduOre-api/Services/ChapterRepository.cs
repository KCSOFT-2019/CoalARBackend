using AR_EduOre_api.Entities;
using AR_EduOre_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AR_EduOre_api.Services;

public class ChapterRepository : RepositoryBase<Chapter, Guid>, IChapterRepository
{
    public ChapterRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Chapter> getHead(Guid id)
    {
        var cp = await DbContext.Set<Chapter>().Where(cp => cp.course_id.Equals(id) && cp.head.Equals(true)).FirstOrDefaultAsync();
        return cp;
        throw new NotImplementedException();
    }

    public Task<Guid?> getNext(Guid? chapter_id)
    {
        return Task.FromResult<Guid?>(DbContext.Set<Chapter>().Where(cp => cp.id.Equals(chapter_id)).FirstOrDefault().next_id);
        throw new NotImplementedException();
    }
}