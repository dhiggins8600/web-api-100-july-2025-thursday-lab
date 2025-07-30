
using Shows.Api.Api.Shows;
using FluentValidation.TestHelper;
using System.ComponentModel;
namespace Shows.Tests.Api.Shows;

public class AddShowValidationTests
{
    [Fact]
    [Trait("Category", "UnitTest")]
    public void ExampleOfInvalidShow()
    {
        var invalidShow = new AddShowRequest
        {
            Name = "X",
            Description = "Y",
        };
        var validator = new AddShowRequestValidator();

        var validations = validator.TestValidate(invalidShow);

        Assert.False(validations.IsValid);


    }
}
