using System;
using Rails.Models.User;

namespace Rails.Tests.Models.User;

public class UserUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserUpdateParams
        {
            ExistingUsername = "username",
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        string expectedExistingUsername = "username";
        long expectedID = 10;
        string expectedEmail = "john@email.com";
        string expectedFirstName = "John";
        string expectedLastName = "James";
        string expectedPassword = "12345";
        string expectedPhone = "12345";
        string expectedUsername = "theUser";
        int expectedUserStatus = 1;

        Assert.Equal(expectedExistingUsername, parameters.ExistingUsername);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedUsername, parameters.Username);
        Assert.Equal(expectedUserStatus, parameters.UserStatus);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateParams { ExistingUsername = "username" };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Password);
        Assert.False(parameters.RawBodyData.ContainsKey("password"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.Username);
        Assert.False(parameters.RawBodyData.ContainsKey("username"));
        Assert.Null(parameters.UserStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("userStatus"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserUpdateParams
        {
            ExistingUsername = "username",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Email = null,
            FirstName = null,
            LastName = null,
            Password = null,
            Phone = null,
            Username = null,
            UserStatus = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Password);
        Assert.False(parameters.RawBodyData.ContainsKey("password"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.Username);
        Assert.False(parameters.RawBodyData.ContainsKey("username"));
        Assert.Null(parameters.UserStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("userStatus"));
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateParams parameters = new() { ExistingUsername = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/user/username"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserUpdateParams
        {
            ExistingUsername = "username",
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        UserUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
