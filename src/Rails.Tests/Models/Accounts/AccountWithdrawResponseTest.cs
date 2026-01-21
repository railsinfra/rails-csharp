using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountWithdrawResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountWithdrawResponse
        {
            Account = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountWithdrawResponseAccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountWithdrawResponseAccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            Transaction = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = "amount",
                BalanceAfter = "balance_after",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Status = AccountWithdrawResponseTransactionStatus.Pending,
                TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        AccountWithdrawResponseAccount expectedAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        AccountWithdrawResponseTransaction expectedTransaction = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedAccount, model.Account);
        Assert.Equal(expectedTransaction, model.Transaction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountWithdrawResponse
        {
            Account = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountWithdrawResponseAccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountWithdrawResponseAccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            Transaction = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = "amount",
                BalanceAfter = "balance_after",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Status = AccountWithdrawResponseTransactionStatus.Pending,
                TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountWithdrawResponse
        {
            Account = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountWithdrawResponseAccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountWithdrawResponseAccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            Transaction = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = "amount",
                BalanceAfter = "balance_after",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Status = AccountWithdrawResponseTransactionStatus.Pending,
                TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AccountWithdrawResponseAccount expectedAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        AccountWithdrawResponseTransaction expectedTransaction = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedAccount, deserialized.Account);
        Assert.Equal(expectedTransaction, deserialized.Transaction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountWithdrawResponse
        {
            Account = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountWithdrawResponseAccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountWithdrawResponseAccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            Transaction = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = "amount",
                BalanceAfter = "balance_after",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                Status = AccountWithdrawResponseTransactionStatus.Pending,
                TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }
}

public class AccountWithdrawResponseAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountNumber = "account_number";
        ApiEnum<string, AccountWithdrawResponseAccountAccountType> expectedAccountType =
            AccountWithdrawResponseAccountAccountType.Checking;
        string expectedBalance = "balance";
        string expectedCurrency = "currency";
        string expectedEnvironment = "environment";
        ApiEnum<string, AccountWithdrawResponseAccountStatus> expectedStatus =
            AccountWithdrawResponseAccountStatus.Active;
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
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponseAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponseAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountNumber = "account_number";
        ApiEnum<string, AccountWithdrawResponseAccountAccountType> expectedAccountType =
            AccountWithdrawResponseAccountAccountType.Checking;
        string expectedBalance = "balance";
        string expectedCurrency = "currency";
        string expectedEnvironment = "environment";
        ApiEnum<string, AccountWithdrawResponseAccountStatus> expectedStatus =
            AccountWithdrawResponseAccountStatus.Active;
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
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
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
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
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
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
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
        var model = new AccountWithdrawResponseAccount
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountWithdrawResponseAccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountWithdrawResponseAccountStatus.Active,
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

public class AccountWithdrawResponseAccountAccountTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountWithdrawResponseAccountAccountType.Checking)]
    [InlineData(AccountWithdrawResponseAccountAccountType.Saving)]
    public void Validation_Works(AccountWithdrawResponseAccountAccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseAccountAccountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountAccountType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountWithdrawResponseAccountAccountType.Checking)]
    [InlineData(AccountWithdrawResponseAccountAccountType.Saving)]
    public void SerializationRoundtrip_Works(AccountWithdrawResponseAccountAccountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseAccountAccountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountAccountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountAccountType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountAccountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountWithdrawResponseAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountWithdrawResponseAccountStatus.Active)]
    [InlineData(AccountWithdrawResponseAccountStatus.Suspended)]
    [InlineData(AccountWithdrawResponseAccountStatus.Closed)]
    public void Validation_Works(AccountWithdrawResponseAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountWithdrawResponseAccountStatus.Active)]
    [InlineData(AccountWithdrawResponseAccountStatus.Suspended)]
    [InlineData(AccountWithdrawResponseAccountStatus.Closed)]
    public void SerializationRoundtrip_Works(AccountWithdrawResponseAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountWithdrawResponseTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        ApiEnum<string, AccountWithdrawResponseTransactionStatus> expectedStatus =
            AccountWithdrawResponseTransactionStatus.Pending;
        ApiEnum<string, AccountWithdrawResponseTransactionTransactionType> expectedTransactionType =
            AccountWithdrawResponseTransactionTransactionType.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedExternalRecipientID = "external_recipient_id";
        string expectedRecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBalanceAfter, model.BalanceAfter);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionType, model.TransactionType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExternalRecipientID, model.ExternalRecipientID);
        Assert.Equal(expectedRecipientAccountID, model.RecipientAccountID);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponseTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountWithdrawResponseTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        ApiEnum<string, AccountWithdrawResponseTransactionStatus> expectedStatus =
            AccountWithdrawResponseTransactionStatus.Pending;
        ApiEnum<string, AccountWithdrawResponseTransactionTransactionType> expectedTransactionType =
            AccountWithdrawResponseTransactionTransactionType.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedExternalRecipientID = "external_recipient_id";
        string expectedRecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBalanceAfter, deserialized.BalanceAfter);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionType, deserialized.TransactionType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExternalRecipientID, deserialized.ExternalRecipientID);
        Assert.Equal(expectedRecipientAccountID, deserialized.RecipientAccountID);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalRecipientID);
        Assert.False(model.RawData.ContainsKey("external_recipient_id"));
        Assert.Null(model.RecipientAccountID);
        Assert.False(model.RawData.ContainsKey("recipient_account_id"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            ExternalRecipientID = null,
            RecipientAccountID = null,
            ReferenceID = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalRecipientID);
        Assert.True(model.RawData.ContainsKey("external_recipient_id"));
        Assert.Null(model.RecipientAccountID);
        Assert.True(model.RawData.ContainsKey("recipient_account_id"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountWithdrawResponseTransaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = AccountWithdrawResponseTransactionStatus.Pending,
            TransactionType = AccountWithdrawResponseTransactionTransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            ExternalRecipientID = null,
            RecipientAccountID = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class AccountWithdrawResponseTransactionStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountWithdrawResponseTransactionStatus.Pending)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Completed)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Failed)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Cancelled)]
    public void Validation_Works(AccountWithdrawResponseTransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseTransactionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountWithdrawResponseTransactionStatus.Pending)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Completed)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Failed)]
    [InlineData(AccountWithdrawResponseTransactionStatus.Cancelled)]
    public void SerializationRoundtrip_Works(AccountWithdrawResponseTransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseTransactionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountWithdrawResponseTransactionTransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Deposit)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Withdrawal)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Transfer)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.RecurringPayment)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.SavingsWithdraw)]
    public void Validation_Works(AccountWithdrawResponseTransactionTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseTransactionTransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Deposit)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Withdrawal)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.Transfer)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.RecurringPayment)]
    [InlineData(AccountWithdrawResponseTransactionTransactionType.SavingsWithdraw)]
    public void SerializationRoundtrip_Works(
        AccountWithdrawResponseTransactionTransactionType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountWithdrawResponseTransactionTransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountWithdrawResponseTransactionTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
