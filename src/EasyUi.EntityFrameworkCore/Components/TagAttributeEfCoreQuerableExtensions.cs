using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EasyUi.Components;

public static class TagAttributeEfCoreQueryableExtensions
{
    public static IQueryable<TagAttribute> IncludeDetails(this IQueryable<TagAttribute> queryable, bool include = true)
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
