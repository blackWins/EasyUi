using System;
using System.Linq;
using System.Threading.Tasks;
using EasyUi.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyUi.Components;

public class TagAttributeRepository : EfCoreRepository<EasyUiDbContext, TagAttribute, Guid>, ITagAttributeRepository
{
    public TagAttributeRepository(IDbContextProvider<EasyUiDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<TagAttribute>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}