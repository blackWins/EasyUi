using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace EasyUi.Components
{
    public class TagsManager : DomainService
    {
        private readonly IRepository<Tags,Guid> _tagsRepository;
        
        public TagsManager(IRepository<Tags,Guid> tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<Tags> TestWithDetails(Guid id)
        {
            //通过包含子集合获取一个 IQueryable<T>
            var queryable = await _tagsRepository.WithDetailsAsync(x => x.Attribute);

            //应用其他的 LINQ 扩展方法
            var query = queryable.Where(x => x.Id == id);

            //执行此查询并获取结果
            var tag = await AsyncExecuter.FirstOrDefaultAsync(query);

            return tag; ;
        }
    }
}
