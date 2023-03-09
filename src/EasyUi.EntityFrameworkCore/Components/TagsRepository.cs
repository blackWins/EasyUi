using System;
using System.Linq;
using System.Threading.Tasks;
using EasyUi.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyUi.Components;

public class TagsRepository : EfCoreRepository<EasyUiDbContext, Tags, Guid>, ITagsRepository
{
    public TagsRepository(IDbContextProvider<EasyUiDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Tags>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}