using System;
using Volo.Abp.Domain.Repositories;

namespace EasyUi.Components;

public interface ITagsRepository : IRepository<Tags, Guid>
{
}
