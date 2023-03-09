using System;
using Volo.Abp.Domain.Repositories;

namespace EasyUi.Components;

public interface ITagAttributeRepository : IRepository<TagAttribute, Guid>
{
}
