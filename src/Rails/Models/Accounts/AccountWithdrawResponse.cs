using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountWithdrawResponse, AccountWithdrawResponseFromRaw>))]
public sealed record class AccountWithdrawResponse : JsonModel
{
    public required AccountWithdrawResponseAccount Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountWithdrawResponseAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required AccountWithdrawResponseTransaction Transaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountWithdrawResponseTransaction>("transaction");
        }
        init { this._rawData.Set("transaction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Account.Validate();
        this.Transaction.Validate();
    }

    public AccountWithdrawResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountWithdrawResponse(AccountWithdrawResponse accountWithdrawResponse)
        : base(accountWithdrawResponse) { }
#pragma warning restore CS8618

    public AccountWithdrawResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountWithdrawResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountWithdrawResponseFromRaw.FromRawUnchecked"/>
    public static AccountWithdrawResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountWithdrawResponseFromRaw : IFromRawJson<AccountWithdrawResponse>
{
    /// <inheritdoc/>
    public AccountWithdrawResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountWithdrawResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        AccountWithdrawResponseAccount,
        AccountWithdrawResponseAccountFromRaw
    >)
)]
public sealed record class AccountWithdrawResponseAccount : JsonModel
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

    public required ApiEnum<string, AccountWithdrawResponseAccountAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountWithdrawResponseAccountAccountType>
            >("account_type");
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

    public required ApiEnum<string, AccountWithdrawResponseAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountWithdrawResponseAccountStatus>
            >("status");
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

    public AccountWithdrawResponseAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountWithdrawResponseAccount(
        AccountWithdrawResponseAccount accountWithdrawResponseAccount
    )
        : base(accountWithdrawResponseAccount) { }
#pragma warning restore CS8618

    public AccountWithdrawResponseAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountWithdrawResponseAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountWithdrawResponseAccountFromRaw.FromRawUnchecked"/>
    public static AccountWithdrawResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountWithdrawResponseAccountFromRaw : IFromRawJson<AccountWithdrawResponseAccount>
{
    /// <inheritdoc/>
    public AccountWithdrawResponseAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountWithdrawResponseAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountWithdrawResponseAccountAccountTypeConverter))]
public enum AccountWithdrawResponseAccountAccountType
{
    Checking,
    Saving,
}

sealed class AccountWithdrawResponseAccountAccountTypeConverter
    : JsonConverter<AccountWithdrawResponseAccountAccountType>
{
    public override AccountWithdrawResponseAccountAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AccountWithdrawResponseAccountAccountType.Checking,
            "saving" => AccountWithdrawResponseAccountAccountType.Saving,
            _ => (AccountWithdrawResponseAccountAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountWithdrawResponseAccountAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountWithdrawResponseAccountAccountType.Checking => "checking",
                AccountWithdrawResponseAccountAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountWithdrawResponseAccountStatusConverter))]
public enum AccountWithdrawResponseAccountStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class AccountWithdrawResponseAccountStatusConverter
    : JsonConverter<AccountWithdrawResponseAccountStatus>
{
    public override AccountWithdrawResponseAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountWithdrawResponseAccountStatus.Active,
            "suspended" => AccountWithdrawResponseAccountStatus.Suspended,
            "closed" => AccountWithdrawResponseAccountStatus.Closed,
            _ => (AccountWithdrawResponseAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountWithdrawResponseAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountWithdrawResponseAccountStatus.Active => "active",
                AccountWithdrawResponseAccountStatus.Suspended => "suspended",
                AccountWithdrawResponseAccountStatus.Closed => "closed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        AccountWithdrawResponseTransaction,
        AccountWithdrawResponseTransactionFromRaw
    >)
)]
public sealed record class AccountWithdrawResponseTransaction : JsonModel
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

    public required ApiEnum<string, AccountWithdrawResponseTransactionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountWithdrawResponseTransactionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<
        string,
        AccountWithdrawResponseTransactionTransactionType
    > TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountWithdrawResponseTransactionTransactionType>
            >("transaction_type");
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

    public AccountWithdrawResponseTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountWithdrawResponseTransaction(
        AccountWithdrawResponseTransaction accountWithdrawResponseTransaction
    )
        : base(accountWithdrawResponseTransaction) { }
#pragma warning restore CS8618

    public AccountWithdrawResponseTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountWithdrawResponseTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountWithdrawResponseTransactionFromRaw.FromRawUnchecked"/>
    public static AccountWithdrawResponseTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountWithdrawResponseTransactionFromRaw : IFromRawJson<AccountWithdrawResponseTransaction>
{
    /// <inheritdoc/>
    public AccountWithdrawResponseTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountWithdrawResponseTransaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountWithdrawResponseTransactionStatusConverter))]
public enum AccountWithdrawResponseTransactionStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled,
}

sealed class AccountWithdrawResponseTransactionStatusConverter
    : JsonConverter<AccountWithdrawResponseTransactionStatus>
{
    public override AccountWithdrawResponseTransactionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => AccountWithdrawResponseTransactionStatus.Pending,
            "completed" => AccountWithdrawResponseTransactionStatus.Completed,
            "failed" => AccountWithdrawResponseTransactionStatus.Failed,
            "cancelled" => AccountWithdrawResponseTransactionStatus.Cancelled,
            _ => (AccountWithdrawResponseTransactionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountWithdrawResponseTransactionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountWithdrawResponseTransactionStatus.Pending => "pending",
                AccountWithdrawResponseTransactionStatus.Completed => "completed",
                AccountWithdrawResponseTransactionStatus.Failed => "failed",
                AccountWithdrawResponseTransactionStatus.Cancelled => "cancelled",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountWithdrawResponseTransactionTransactionTypeConverter))]
public enum AccountWithdrawResponseTransactionTransactionType
{
    Deposit,
    Withdrawal,
    Transfer,
    RecurringPayment,
    SavingsWithdraw,
}

sealed class AccountWithdrawResponseTransactionTransactionTypeConverter
    : JsonConverter<AccountWithdrawResponseTransactionTransactionType>
{
    public override AccountWithdrawResponseTransactionTransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => AccountWithdrawResponseTransactionTransactionType.Deposit,
            "withdrawal" => AccountWithdrawResponseTransactionTransactionType.Withdrawal,
            "transfer" => AccountWithdrawResponseTransactionTransactionType.Transfer,
            "recurring_payment" =>
                AccountWithdrawResponseTransactionTransactionType.RecurringPayment,
            "savings_withdraw" => AccountWithdrawResponseTransactionTransactionType.SavingsWithdraw,
            _ => (AccountWithdrawResponseTransactionTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountWithdrawResponseTransactionTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountWithdrawResponseTransactionTransactionType.Deposit => "deposit",
                AccountWithdrawResponseTransactionTransactionType.Withdrawal => "withdrawal",
                AccountWithdrawResponseTransactionTransactionType.Transfer => "transfer",
                AccountWithdrawResponseTransactionTransactionType.RecurringPayment =>
                    "recurring_payment",
                AccountWithdrawResponseTransactionTransactionType.SavingsWithdraw =>
                    "savings_withdraw",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
