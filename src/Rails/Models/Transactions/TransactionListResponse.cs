using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Transactions;

[JsonConverter(typeof(JsonModelConverter<TransactionListResponse, TransactionListResponseFromRaw>))]
public sealed record class TransactionListResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public TransactionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionListResponse(TransactionListResponse transactionListResponse)
        : base(transactionListResponse) { }
#pragma warning restore CS8618

    public TransactionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionListResponseFromRaw.FromRawUnchecked"/>
    public static TransactionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionListResponseFromRaw : IFromRawJson<TransactionListResponse>
{
    /// <inheritdoc/>
    public TransactionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Transaction as returned by list-by-organization (organization_id, from/to_account_id, transaction_kind).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    /// <summary>
    /// Amount in minor units
    /// </summary>
    public required long Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount");
        }
        init { this._rawData.Set("amount", value); }
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

    public required string FromAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("from_account_id");
        }
        init { this._rawData.Set("from_account_id", value); }
    }

    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public required ApiEnum<string, DataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string ToAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("to_account_id");
        }
        init { this._rawData.Set("to_account_id", value); }
    }

    public required ApiEnum<string, TransactionKind> TransactionKind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionKind>>(
                "transaction_kind"
            );
        }
        init { this._rawData.Set("transaction_kind", value); }
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

    public string? Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failure_reason");
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    public string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("idempotency_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.FromAccountID;
        _ = this.OrganizationID;
        this.Status.Validate();
        _ = this.ToAccountID;
        this.TransactionKind.Validate();
        _ = this.UpdatedAt;
        _ = this.Environment;
        _ = this.FailureReason;
        _ = this.IdempotencyKey;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    Pending,
    Posted,
    Failed,
}

sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => DataStatus.Pending,
            "posted" => DataStatus.Posted,
            "failed" => DataStatus.Failed,
            _ => (DataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataStatus.Pending => "pending",
                DataStatus.Posted => "posted",
                DataStatus.Failed => "failed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TransactionKindConverter))]
public enum TransactionKind
{
    Deposit,
    Withdraw,
    Transfer,
}

sealed class TransactionKindConverter : JsonConverter<TransactionKind>
{
    public override TransactionKind Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deposit" => TransactionKind.Deposit,
            "withdraw" => TransactionKind.Withdraw,
            "transfer" => TransactionKind.Transfer,
            _ => (TransactionKind)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionKind value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionKind.Deposit => "deposit",
                TransactionKind.Withdraw => "withdraw",
                TransactionKind.Transfer => "transfer",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    public required long PerPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("per_page");
        }
        init { this._rawData.Set("per_page", value); }
    }

    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    public required long TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_pages");
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.PerPage;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
