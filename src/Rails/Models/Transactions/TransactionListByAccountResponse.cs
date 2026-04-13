using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Transactions;

[JsonConverter(
    typeof(JsonModelConverter<
        TransactionListByAccountResponse,
        TransactionListByAccountResponseFromRaw
    >)
)]
public sealed record class TransactionListByAccountResponse : JsonModel
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

    public required ApiEnum<string, TransactionListByAccountResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TransactionListByAccountResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, TransactionListByAccountResponseTransactionType> TransactionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TransactionListByAccountResponseTransactionType>
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

    public TransactionListByAccountResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionListByAccountResponse(
        TransactionListByAccountResponse transactionListByAccountResponse
    )
        : base(transactionListByAccountResponse) { }
#pragma warning restore CS8618

    public TransactionListByAccountResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionListByAccountResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionListByAccountResponseFromRaw.FromRawUnchecked"/>
    public static TransactionListByAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionListByAccountResponseFromRaw : IFromRawJson<TransactionListByAccountResponse>
{
    /// <inheritdoc/>
    public TransactionListByAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionListByAccountResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TransactionListByAccountResponseStatusConverter))]
public enum TransactionListByAccountResponseStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled,
}

sealed class TransactionListByAccountResponseStatusConverter
    : JsonConverter<TransactionListByAccountResponseStatus>
{
    public override TransactionListByAccountResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => TransactionListByAccountResponseStatus.Pending,
            "completed" => TransactionListByAccountResponseStatus.Completed,
            "failed" => TransactionListByAccountResponseStatus.Failed,
            "cancelled" => TransactionListByAccountResponseStatus.Cancelled,
            _ => (TransactionListByAccountResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionListByAccountResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionListByAccountResponseStatus.Pending => "pending",
                TransactionListByAccountResponseStatus.Completed => "completed",
                TransactionListByAccountResponseStatus.Failed => "failed",
                TransactionListByAccountResponseStatus.Cancelled => "cancelled",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TransactionListByAccountResponseTransactionTypeConverter))]
public enum TransactionListByAccountResponseTransactionType
{
    Deposit,
    Withdrawal,
    Transfer,
    RecurringPayment,
    SavingsWithdraw,
}

sealed class TransactionListByAccountResponseTransactionTypeConverter
    : JsonConverter<TransactionListByAccountResponseTransactionType>
{
    public override TransactionListByAccountResponseTransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => TransactionListByAccountResponseTransactionType.Deposit,
            "withdrawal" => TransactionListByAccountResponseTransactionType.Withdrawal,
            "transfer" => TransactionListByAccountResponseTransactionType.Transfer,
            "recurring_payment" => TransactionListByAccountResponseTransactionType.RecurringPayment,
            "savings_withdraw" => TransactionListByAccountResponseTransactionType.SavingsWithdraw,
            _ => (TransactionListByAccountResponseTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionListByAccountResponseTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionListByAccountResponseTransactionType.Deposit => "deposit",
                TransactionListByAccountResponseTransactionType.Withdrawal => "withdrawal",
                TransactionListByAccountResponseTransactionType.Transfer => "transfer",
                TransactionListByAccountResponseTransactionType.RecurringPayment =>
                    "recurring_payment",
                TransactionListByAccountResponseTransactionType.SavingsWithdraw =>
                    "savings_withdraw",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
