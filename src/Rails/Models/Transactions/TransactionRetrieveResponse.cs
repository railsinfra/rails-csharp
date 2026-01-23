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
    typeof(JsonModelConverter<TransactionRetrieveResponse, TransactionRetrieveResponseFromRaw>)
)]
public sealed record class TransactionRetrieveResponse : JsonModel
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public TransactionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionRetrieveResponse(TransactionRetrieveResponse transactionRetrieveResponse)
        : base(transactionRetrieveResponse) { }
#pragma warning restore CS8618

    public TransactionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TransactionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionRetrieveResponseFromRaw : IFromRawJson<TransactionRetrieveResponse>
{
    /// <inheritdoc/>
    public TransactionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Completed,
    Failed,
    Cancelled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            "cancelled" => Status.Cancelled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Completed => "completed",
                Status.Failed => "failed",
                Status.Cancelled => "cancelled",
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
