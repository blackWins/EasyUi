using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyUi.Components;

public static class TagsEfCoreQueryableExtensions
{
    public static IQueryable<Tags> IncludeDetails(this IQueryable<Tags> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
