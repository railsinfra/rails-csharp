using System;
using System.Net.Http;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountListParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountListParamsXEnvironment.Sandbox,
        };

        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AccountListParamsXEnvironment> expectedXEnvironment =
            AccountListParamsXEnvironment.Sandbox;

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedXEnvironment, parameters.XEnvironment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountListParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountListParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            XEnvironment = null,
        };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountListParams parameters = new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://www.api.railsinfra.com/api/v1/accounts?user_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AccountListParams parameters = new()
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountListParamsXEnvironment.Sandbox,
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sandbox"], requestMessage.Headers.GetValues("X-Environment"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountListParams
        {
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountListParamsXEnvironment.Sandbox,
        };

        AccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountListParamsXEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AccountListParamsXEnvironment.Sandbox)]
    [InlineData(AccountListParamsXEnvironment.Production)]
    public void Validation_Works(AccountListParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListParamsXEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountListParamsXEnvironment.Sandbox)]
    [InlineData(AccountListParamsXEnvironment.Production)]
    public void SerializationRoundtrip_Works(AccountListParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListParamsXEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountListParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountListParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
