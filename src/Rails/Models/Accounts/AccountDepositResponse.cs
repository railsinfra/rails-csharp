using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountDepositResponse, AccountDepositResponseFromRaw>))]
public sealed record class AccountDepositResponse : JsonModel
{
    public required Account Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Account>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required Transaction Transaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Transaction>("transaction");
        }
        init { this._rawData.Set("transaction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Account.Validate();
        this.Transaction.Validate();
    }

    public AccountDepositResponse() { }

    public AccountDepositResponse(AccountDepositResponse accountDepositResponse)
        : base(accountDepositResponse) { }

    public AccountDepositResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountDepositResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountDepositResponseFromRaw.FromRawUnchecked"/>
    public static AccountDepositResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountDepositResponseFromRaw : IFromRawJson<AccountDepositResponse>
{
    /// <inheritdoc/>
    public AccountDepositResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountDepositResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Account, AccountFromRaw>))]
public sealed record class Account : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    public required ApiEnum<string, AccountAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountAccountType>>(
                "account_type"
            );
        }
        init { this._rawData.Set("account_type", value); }
    }

    public required string Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required string Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    public required ApiEnum<string, AccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    public string? AdminUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("admin_user_id");
        }
        init { this._rawData.Set("admin_user_id", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? UserRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_role");
        }
        init { this._rawData.Set("user_role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountNumber;
        this.AccountType.Validate();
        _ = this.Balance;
        _ = this.Currency;
        _ = this.Environment;
        this.Status.Validate();
        _ = this.UserID;
        _ = this.AdminUserID;
        _ = this.CreatedAt;
        _ = this.OrganizationID;
        _ = this.UpdatedAt;
        _ = this.UserRole;
    }

    public Account() { }

    public Account(Account account)
        : base(account) { }

    public Account(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Account(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountFromRaw.FromRawUnchecked"/>
    public static Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountFromRaw : IFromRawJson<Account>
{
    /// <inheritdoc/>
    public Account FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Account.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountAccountTypeConverter))]
public enum AccountAccountType
{
    Checking,
    Saving,
}

sealed class AccountAccountTypeConverter : JsonConverter<AccountAccountType>
{
    public override AccountAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AccountAccountType.Checking,
            "saving" => AccountAccountType.Saving,
            _ => (AccountAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountAccountType.Checking => "checking",
                AccountAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountStatusConverter))]
public enum AccountStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class AccountStatusConverter : JsonConverter<AccountStatus>
{
    public override AccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountStatus.Active,
            "suspended" => AccountStatus.Suspended,
            "closed" => AccountStatus.Closed,
            _ => (AccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountStatus.Active => "active",
                AccountStatus.Suspended => "suspended",
                AccountStatus.Closed => "closed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Transaction, TransactionFromRaw>))]
public sealed record class Transaction : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string BalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance_after");
        }
        init { this._rawData.Set("balance_after", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required ApiEnum<string, TransactionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, TransactionType> TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionType>>(
                "transaction_type"
            );
        }
        init { this._rawData.Set("transaction_type", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? ExternalRecipientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_recipient_id");
        }
        init { this._rawData.Set("external_recipient_id", value); }
    }

    public string? RecipientAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient_account_id");
        }
        init { this._rawData.Set("recipient_account_id", value); }
    }

    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.Amount;
        _ = this.BalanceAfter;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Status.Validate();
        this.TransactionType.Validate();
        _ = this.UpdatedAt;
        _ = this.Description;
        _ = this.ExternalRecipientID;
        _ = this.RecipientAccountID;
        _ = this.ReferenceID;
    }

    public Transaction() { }

    public Transaction(Transaction transaction)
        : base(transaction) { }

    public Transaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionFromRaw.FromRawUnchecked"/>
    public static Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionFromRaw : IFromRawJson<Transaction>
{
    /// <inheritdoc/>
    public Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TransactionStatusConverter))]
public enum TransactionStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled,
}

sealed class TransactionStatusConverter : JsonConverter<TransactionStatus>
{
    public override TransactionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => TransactionStatus.Pending,
            "completed" => TransactionStatus.Completed,
            "failed" => TransactionStatus.Failed,
            "cancelled" => TransactionStatus.Cancelled,
            _ => (TransactionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionStatus.Pending => "pending",
                TransactionStatus.Completed => "completed",
                TransactionStatus.Failed => "failed",
                TransactionStatus.Cancelled => "cancelled",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TransactionTypeConverter))]
public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer,
    RecurringPayment,
    SavingsWithdraw,
}

sealed class TransactionTypeConverter : JsonConverter<TransactionType>
{
    public override TransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => TransactionType.Deposit,
            "withdrawal" => TransactionType.Withdrawal,
            "transfer" => TransactionType.Transfer,
            "recurring_payment" => TransactionType.RecurringPayment,
            "savings_withdraw" => TransactionType.SavingsWithdraw,
            _ => (TransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionType.Deposit => "deposit",
                TransactionType.Withdrawal => "withdrawal",
                TransactionType.Transfer => "transfer",
                TransactionType.RecurringPayment => "recurring_payment",
                TransactionType.SavingsWithdraw => "savings_withdraw",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
