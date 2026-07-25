using System;
using System.Net.Http;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountRetrieveParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountRetrieveParamsXEnvironment.Sandbox,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AccountRetrieveParamsXEnvironment> expectedXEnvironment =
            AccountRetrieveParamsXEnvironment.Sandbox;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedXEnvironment, parameters.XEnvironment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountRetrieveParams { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountRetrieveParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            XEnvironment = null,
        };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountRetrieveParams parameters = new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://www.api.railsinfra.com/api/v1/accounts/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AccountRetrieveParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountRetrieveParamsXEnvironment.Sandbox,
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sandbox"], requestMessage.Headers.GetValues("X-Environment"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountRetrieveParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountRetrieveParamsXEnvironment.Sandbox,
        };

        AccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountRetrieveParamsXEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AccountRetrieveParamsXEnvironment.Sandbox)]
    [InlineData(AccountRetrieveParamsXEnvironment.Production)]
    public void Validation_Works(AccountRetrieveParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountRetrieveParamsXEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountRetrieveParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountRetrieveParamsXEnvironment.Sandbox)]
    [InlineData(AccountRetrieveParamsXEnvironment.Production)]
    public void SerializationRoundtrip_Works(AccountRetrieveParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountRetrieveParamsXEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountRetrieveParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountRetrieveParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountRetrieveParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
