using System;
using Rails.Models.User;

namespace Rails.Tests.Models.User;

public class UserDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserDeleteParams { Username = "username" };

        string expectedUsername = "username";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        UserDeleteParams parameters = new() { Username = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/user/username"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserDeleteParams { Username = "username" };

        UserDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
