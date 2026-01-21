using System;
using Rails.Models.User;

namespace Rails.Tests.Models.User;

public class UserLoginParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserLoginParams { Password = "password", Username = "username" };

        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserLoginParams { };

        Assert.Null(parameters.Password);
        Assert.False(parameters.RawQueryData.ContainsKey("password"));
        Assert.Null(parameters.Username);
        Assert.False(parameters.RawQueryData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserLoginParams
        {
            // Null should be interpreted as omitted for these properties
            Password = null,
            Username = null,
        };

        Assert.Null(parameters.Password);
        Assert.False(parameters.RawQueryData.ContainsKey("password"));
        Assert.Null(parameters.Username);
        Assert.False(parameters.RawQueryData.ContainsKey("username"));
    }

    [Fact]
    public void Url_Works()
    {
        UserLoginParams parameters = new() { Password = "password", Username = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://petstore3.swagger.io/api/v3/user/login?password=password&username=username"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserLoginParams { Password = "password", Username = "username" };

        UserLoginParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
