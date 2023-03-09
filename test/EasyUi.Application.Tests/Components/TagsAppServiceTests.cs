using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyUi.Components;

public class TagsAppServiceTests : EasyUiApplicationTestBase
{
    private readonly ITagsAppService _tagsAppService;

    public TagsAppServiceTests()
    {
        _tagsAppService = GetRequiredService<ITagsAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

