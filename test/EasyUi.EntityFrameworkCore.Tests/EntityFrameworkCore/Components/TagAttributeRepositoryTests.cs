using System;
using System.Threading.Tasks;
using EasyUi.Components;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyUi.EntityFrameworkCore.Components;

public class TagAttributeRepositoryTests : EasyUiEntityFrameworkCoreTestBase
{
    private readonly ITagAttributeRepository _tagAttributeRepository;

    public TagAttributeRepositoryTests()
    {
        _tagAttributeRepository = GetRequiredService<ITagAttributeRepository>();
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
