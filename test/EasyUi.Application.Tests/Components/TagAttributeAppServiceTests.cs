using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyUi.Components;

public class TagAttributeAppServiceTests : EasyUiApplicationTestBase
{
    private readonly ITagAttributeAppService _tagAttributeAppService;

    public TagAttributeAppServiceTests()
    {
        _tagAttributeAppService = GetRequiredService<ITagAttributeAppService>();
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

