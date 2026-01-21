using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountNumber = "account_number";
        ApiEnum<string, AccountListResponseAccountType> expectedAccountType =
            AccountListResponseAccountType.Checking;
        string expectedBalance = "balance";
        string expectedCurrency = "currency";
        string expectedEnvironment = "environment";
        ApiEnum<string, AccountListResponseStatus> expectedStatus =
            AccountListResponseStatus.Active;
        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserRole = "user_role";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAccountType, model.AccountType);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedAdminUserID, model.AdminUserID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserRole, model.UserRole);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountNumber = "account_number";
        ApiEnum<string, AccountListResponseAccountType> expectedAccountType =
            AccountListResponseAccountType.Checking;
        string expectedBalance = "balance";
        string expectedCurrency = "currency";
        string expectedEnvironment = "environment";
        ApiEnum<string, AccountListResponseStatus> expectedStatus =
            AccountListResponseStatus.Active;
        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUserRole = "user_role";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAccountType, deserialized.AccountType);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedAdminUserID, deserialized.AdminUserID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserRole, deserialized.UserRole);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.AdminUserID);
        Assert.False(model.RawData.ContainsKey("admin_user_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.OrganizationID);
        Assert.False(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.UserRole);
        Assert.False(model.RawData.ContainsKey("user_role"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            AdminUserID = null,
            CreatedAt = null,
            OrganizationID = null,
            UpdatedAt = null,
            UserRole = null,
        };

        Assert.Null(model.AdminUserID);
        Assert.True(model.RawData.ContainsKey("admin_user_id"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.OrganizationID);
        Assert.True(model.RawData.ContainsKey("organization_id"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.UserRole);
        Assert.True(model.RawData.ContainsKey("user_role"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountListResponseAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountListResponseStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            AdminUserID = null,
            CreatedAt = null,
            OrganizationID = null,
            UpdatedAt = null,
            UserRole = null,
        };

        model.Validate();
    }
}

public class AccountListResponseAccountTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountListResponseAccountType.Checking)]
    [InlineData(AccountListResponseAccountType.Saving)]
    public void Validation_Works(AccountListResponseAccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListResponseAccountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseAccountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountListResponseAccountType.Checking)]
    [InlineData(AccountListResponseAccountType.Saving)]
    public void SerializationRoundtrip_Works(AccountListResponseAccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListResponseAccountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountListResponseAccountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseAccountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountListResponseAccountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountListResponseStatus.Active)]
    [InlineData(AccountListResponseStatus.Suspended)]
    [InlineData(AccountListResponseStatus.Closed)]
    public void Validation_Works(AccountListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountListResponseStatus.Active)]
    [InlineData(AccountListResponseStatus.Suspended)]
    [InlineData(AccountListResponseStatus.Closed)]
    public void SerializationRoundtrip_Works(AccountListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
