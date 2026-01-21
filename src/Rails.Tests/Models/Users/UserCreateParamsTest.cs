using System;
using System.Net.Http;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Users;

namespace Rails.Tests.Models.Users;

public class UserCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserCreateParams
        {
            Email = "dev@stainless.com",
            FirstName = "first_name",
            LastName = "last_name",
            Password = "password",
            XEnvironment = XEnvironment.Sandbox,
        };

        string expectedEmail = "dev@stainless.com";
        string expectedFirstName = "first_name";
        string expectedLastName = "last_name";
        string expectedPassword = "password";
        ApiEnum<string, XEnvironment> expectedXEnvironment = XEnvironment.Sandbox;

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedXEnvironment, parameters.XEnvironment);
    }

    [Fact]
    public void Url_Works()
    {
        UserCreateParams parameters = new()
        {
            Email = "dev@stainless.com",
            FirstName = "first_name",
            LastName = "last_name",
            Password = "password",
            XEnvironment = XEnvironment.Sandbox,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.rails.com/api/v1/users"), url);
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserCreateParams parameters = new()
        {
            Email = "dev@stainless.com",
            FirstName = "first_name",
            LastName = "last_name",
            Password = "password",
            XEnvironment = XEnvironment.Sandbox,
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sandbox"], requestMessage.Headers.GetValues("X-Environment"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserCreateParams
        {
            Email = "dev@stainless.com",
            FirstName = "first_name",
            LastName = "last_name",
            Password = "password",
            XEnvironment = XEnvironment.Sandbox,
        };

        UserCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class XEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(XEnvironment.Sandbox)]
    [InlineData(XEnvironment.Production)]
    public void Validation_Works(XEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(XEnvironment.Sandbox)]
    [InlineData(XEnvironment.Production)]
    public void SerializationRoundtrip_Works(XEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
