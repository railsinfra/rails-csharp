using System;
using System.Net.Http;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountTransferParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            XEnvironment = AccountTransferParamsXEnvironment.Sandbox,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        ApiEnum<string, AccountTransferParamsXEnvironment> expectedXEnvironment =
            AccountTransferParamsXEnvironment.Sandbox;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedToAccountID, parameters.ToAccountID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedXEnvironment, parameters.XEnvironment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
        };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            XEnvironment = null,
        };

        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountTransferParamsXEnvironment.Sandbox,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountTransferParamsXEnvironment.Sandbox,

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountTransferParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://www.api.railsinfra.com/api/v1/accounts/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/transfer"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AccountTransferParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            XEnvironment = AccountTransferParamsXEnvironment.Sandbox,
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sandbox"], requestMessage.Headers.GetValues("X-Environment"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            XEnvironment = AccountTransferParamsXEnvironment.Sandbox,
        };

        AccountTransferParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountTransferParamsXEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AccountTransferParamsXEnvironment.Sandbox)]
    [InlineData(AccountTransferParamsXEnvironment.Production)]
    public void Validation_Works(AccountTransferParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransferParamsXEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransferParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTransferParamsXEnvironment.Sandbox)]
    [InlineData(AccountTransferParamsXEnvironment.Production)]
    public void SerializationRoundtrip_Works(AccountTransferParamsXEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransferParamsXEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountTransferParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransferParamsXEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountTransferParamsXEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
