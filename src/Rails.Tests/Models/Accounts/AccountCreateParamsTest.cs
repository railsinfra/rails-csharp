using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Currency = "currency",
            Environment = "environment",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ApiEnum<string, AccountType> expectedAccountType = AccountType.Checking;
        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCurrency = "currency";
        string expectedEnvironment = "environment";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedAccountType, parameters.AccountType);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedEnvironment, parameters.Environment);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Environment = "environment",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Environment = "environment",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Currency = null,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Currency = "currency",
        };

        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawBodyData.ContainsKey("environment"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawBodyData.ContainsKey("organization_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Currency = "currency",

            Environment = null,
            OrganizationID = null,
        };

        Assert.Null(parameters.Environment);
        Assert.True(parameters.RawBodyData.ContainsKey("environment"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawBodyData.ContainsKey("organization_id"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountCreateParams parameters = new()
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://accounts-service-staging.up.railway.app/api/v1/accounts"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            AccountType = AccountType.Checking,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Currency = "currency",
            Environment = "environment",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountType.Checking)]
    [InlineData(AccountType.Saving)]
    public void Validation_Works(AccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountType.Checking)]
    [InlineData(AccountType.Saving)]
    public void SerializationRoundtrip_Works(AccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
