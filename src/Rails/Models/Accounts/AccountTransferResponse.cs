using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountTransferResponse, AccountTransferResponseFromRaw>))]
public sealed record class AccountTransferResponse : JsonModel
{
    public required FromAccount FromAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FromAccount>("from_account");
        }
        init { this._rawData.Set("from_account", value); }
    }

    public required ToAccount ToAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToAccount>("to_account");
        }
        init { this._rawData.Set("to_account", value); }
    }

    public required AccountTransferResponseTransaction Transaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountTransferResponseTransaction>("transaction");
        }
        init { this._rawData.Set("transaction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FromAccount.Validate();
        this.ToAccount.Validate();
        this.Transaction.Validate();
    }

    public AccountTransferResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferResponse(AccountTransferResponse accountTransferResponse)
        : base(accountTransferResponse) { }
#pragma warning restore CS8618

    public AccountTransferResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferResponseFromRaw.FromRawUnchecked"/>
    public static AccountTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferResponseFromRaw : IFromRawJson<AccountTransferResponse>
{
    /// <inheritdoc/>
    public AccountTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FromAccount, FromAccountFromRaw>))]
public sealed record class FromAccount : JsonModel
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

    public required ApiEnum<string, FromAccountAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FromAccountAccountType>>(
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

    public required ApiEnum<string, FromAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FromAccountStatus>>("status");
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

    public FromAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FromAccount(FromAccount fromAccount)
        : base(fromAccount) { }
#pragma warning restore CS8618

    public FromAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FromAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FromAccountFromRaw.FromRawUnchecked"/>
    public static FromAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FromAccountFromRaw : IFromRawJson<FromAccount>
{
    /// <inheritdoc/>
    public FromAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FromAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FromAccountAccountTypeConverter))]
public enum FromAccountAccountType
{
    Checking,
    Saving,
}

sealed class FromAccountAccountTypeConverter : JsonConverter<FromAccountAccountType>
{
    public override FromAccountAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => FromAccountAccountType.Checking,
            "saving" => FromAccountAccountType.Saving,
            _ => (FromAccountAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FromAccountAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FromAccountAccountType.Checking => "checking",
                FromAccountAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FromAccountStatusConverter))]
public enum FromAccountStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class FromAccountStatusConverter : JsonConverter<FromAccountStatus>
{
    public override FromAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => FromAccountStatus.Active,
            "suspended" => FromAccountStatus.Suspended,
            "closed" => FromAccountStatus.Closed,
            _ => (FromAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FromAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FromAccountStatus.Active => "active",
                FromAccountStatus.Suspended => "suspended",
                FromAccountStatus.Closed => "closed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ToAccount, ToAccountFromRaw>))]
public sealed record class ToAccount : JsonModel
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

    public required ApiEnum<string, ToAccountAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ToAccountAccountType>>(
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

    public required ApiEnum<string, ToAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ToAccountStatus>>("status");
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

    public ToAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToAccount(ToAccount toAccount)
        : base(toAccount) { }
#pragma warning restore CS8618

    public ToAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToAccountFromRaw.FromRawUnchecked"/>
    public static ToAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToAccountFromRaw : IFromRawJson<ToAccount>
{
    /// <inheritdoc/>
    public ToAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToAccountAccountTypeConverter))]
public enum ToAccountAccountType
{
    Checking,
    Saving,
}

sealed class ToAccountAccountTypeConverter : JsonConverter<ToAccountAccountType>
{
    public override ToAccountAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => ToAccountAccountType.Checking,
            "saving" => ToAccountAccountType.Saving,
            _ => (ToAccountAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToAccountAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToAccountAccountType.Checking => "checking",
                ToAccountAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ToAccountStatusConverter))]
public enum ToAccountStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class ToAccountStatusConverter : JsonConverter<ToAccountStatus>
{
    public override ToAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ToAccountStatus.Active,
            "suspended" => ToAccountStatus.Suspended,
            "closed" => ToAccountStatus.Closed,
            _ => (ToAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToAccountStatus.Active => "active",
                ToAccountStatus.Suspended => "suspended",
                ToAccountStatus.Closed => "closed",
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
        AccountTransferResponseTransaction,
        AccountTransferResponseTransactionFromRaw
    >)
)]
public sealed record class AccountTransferResponseTransaction : JsonModel
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

    public required ApiEnum<string, AccountTransferResponseTransactionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountTransferResponseTransactionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<
        string,
        AccountTransferResponseTransactionTransactionType
    > TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountTransferResponseTransactionTransactionType>
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

    public AccountTransferResponseTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferResponseTransaction(
        AccountTransferResponseTransaction accountTransferResponseTransaction
    )
        : base(accountTransferResponseTransaction) { }
#pragma warning restore CS8618

    public AccountTransferResponseTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferResponseTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferResponseTransactionFromRaw.FromRawUnchecked"/>
    public static AccountTransferResponseTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferResponseTransactionFromRaw : IFromRawJson<AccountTransferResponseTransaction>
{
    /// <inheritdoc/>
    public AccountTransferResponseTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferResponseTransaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountTransferResponseTransactionStatusConverter))]
public enum AccountTransferResponseTransactionStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled,
}

sealed class AccountTransferResponseTransactionStatusConverter
    : JsonConverter<AccountTransferResponseTransactionStatus>
{
    public override AccountTransferResponseTransactionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => AccountTransferResponseTransactionStatus.Pending,
            "completed" => AccountTransferResponseTransactionStatus.Completed,
            "failed" => AccountTransferResponseTransactionStatus.Failed,
            "cancelled" => AccountTransferResponseTransactionStatus.Cancelled,
            _ => (AccountTransferResponseTransactionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTransferResponseTransactionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTransferResponseTransactionStatus.Pending => "pending",
                AccountTransferResponseTransactionStatus.Completed => "completed",
                AccountTransferResponseTransactionStatus.Failed => "failed",
                AccountTransferResponseTransactionStatus.Cancelled => "cancelled",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountTransferResponseTransactionTransactionTypeConverter))]
public enum AccountTransferResponseTransactionTransactionType
{
    Deposit,
    Withdrawal,
    Transfer,
    RecurringPayment,
    SavingsWithdraw,
}

sealed class AccountTransferResponseTransactionTransactionTypeConverter
    : JsonConverter<AccountTransferResponseTransactionTransactionType>
{
    public override AccountTransferResponseTransactionTransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => AccountTransferResponseTransactionTransactionType.Deposit,
            "withdrawal" => AccountTransferResponseTransactionTransactionType.Withdrawal,
            "transfer" => AccountTransferResponseTransactionTransactionType.Transfer,
            "recurring_payment" =>
                AccountTransferResponseTransactionTransactionType.RecurringPayment,
            "savings_withdraw" => AccountTransferResponseTransactionTransactionType.SavingsWithdraw,
            _ => (AccountTransferResponseTransactionTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountTransferResponseTransactionTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountTransferResponseTransactionTransactionType.Deposit => "deposit",
                AccountTransferResponseTransactionTransactionType.Withdrawal => "withdrawal",
                AccountTransferResponseTransactionTransactionType.Transfer => "transfer",
                AccountTransferResponseTransactionTransactionType.RecurringPayment =>
                    "recurring_payment",
                AccountTransferResponseTransactionTransactionType.SavingsWithdraw =>
                    "savings_withdraw",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
