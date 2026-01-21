using System;
using System.Collections.Generic;
using Rails.Models.User;

namespace Rails.Tests.Models.User;

public class UserCreateWithListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserCreateWithListParams
        {
            Body =
            [
                new()
                {
                    ID = 10,
                    Email = "john@email.com",
                    FirstName = "John",
                    LastName = "James",
                    Password = "12345",
                    Phone = "12345",
                    Username = "theUser",
                    UserStatus = 1,
                },
            ],
        };

        List<UserUser> expectedBody =
        [
            new()
            {
                ID = 10,
                Email = "john@email.com",
                FirstName = "John",
                LastName = "James",
                Password = "12345",
                Phone = "12345",
                Username = "theUser",
                UserStatus = 1,
            },
        ];

        Assert.NotNull(parameters.Body);
        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        for (int i = 0; i < expectedBody.Count; i++)
        {
            Assert.Equal(expectedBody[i], parameters.Body[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserCreateWithListParams { };

        Assert.Null(parameters.Body);
        Assert.False(parameters.RawBodyData.ContainsKey("body"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserCreateWithListParams
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
        };

        Assert.Null(parameters.Body);
        Assert.False(parameters.RawBodyData.ContainsKey("body"));
    }

    [Fact]
    public void Url_Works()
    {
        UserCreateWithListParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/user/createWithList"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserCreateWithListParams
        {
            Body =
            [
                new()
                {
                    ID = 10,
                    Email = "john@email.com",
                    FirstName = "John",
                    LastName = "James",
                    Password = "12345",
                    Phone = "12345",
                    Username = "theUser",
                    UserStatus = 1,
                },
            ],
        };

        UserCreateWithListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
