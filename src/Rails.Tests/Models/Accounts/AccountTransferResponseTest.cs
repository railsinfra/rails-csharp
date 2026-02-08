using System;
using System.Text.Json;
using Rails.Core;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountTransferResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransferResponse
        {
            FromAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            ToAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
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
                Status = TransactionStatus.Pending,
                TransactionType = TransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        Account expectedFromAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        Account expectedToAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        Transaction expectedTransaction = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedFromAccount, model.FromAccount);
        Assert.Equal(expectedToAccount, model.ToAccount);
        Assert.Equal(expectedTransaction, model.Transaction);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransferResponse
        {
            FromAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            ToAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
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
                Status = TransactionStatus.Pending,
                TransactionType = TransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransferResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransferResponse
        {
            FromAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            ToAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
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
                Status = TransactionStatus.Pending,
                TransactionType = TransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransferResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Account expectedFromAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        Account expectedToAccount = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountNumber = "account_number",
            AccountType = AccountAccountType.Checking,
            Balance = "balance",
            Currency = "currency",
            Environment = "environment",
            Status = AccountStatus.Active,
            UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UserRole = "user_role",
        };
        Transaction expectedTransaction = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedFromAccount, deserialized.FromAccount);
        Assert.Equal(expectedToAccount, deserialized.ToAccount);
        Assert.Equal(expectedTransaction, deserialized.Transaction);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountTransferResponse
        {
            FromAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            ToAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
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
                Status = TransactionStatus.Pending,
                TransactionType = TransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransferResponse
        {
            FromAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AdminUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UserRole = "user_role",
            },
            ToAccount = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AccountNumber = "account_number",
                AccountType = AccountAccountType.Checking,
                Balance = "balance",
                Currency = "currency",
                Environment = "environment",
                Status = AccountStatus.Active,
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
                Status = TransactionStatus.Pending,
                TransactionType = TransactionType.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                ExternalRecipientID = "external_recipient_id",
                RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        AccountTransferResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
