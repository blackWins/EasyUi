using System;
using System.Threading.Tasks;
using EasyUi.Components;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyUi.EntityFrameworkCore.Components;

public class TagsRepositoryTests : EasyUiEntityFrameworkCoreTestBase
{
    private readonly ITagsRepository _tagsRepository;

    public TagsRepositoryTests()
    {
        _tagsRepository = GetRequiredService<ITagsRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
