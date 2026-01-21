using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Store.Order;

[JsonConverter(typeof(JsonModelConverter<OrderOrder, OrderOrderFromRaw>))]
public sealed record class OrderOrder : JsonModel
{
    public long? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public bool? Complete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("complete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("complete", value);
        }
    }

    public long? PetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("petId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("petId", value);
        }
    }

    public int? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    public DateTimeOffset? ShipDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("shipDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipDate", value);
        }
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public ApiEnum<string, OrderOrderStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OrderOrderStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Complete;
        _ = this.PetID;
        _ = this.Quantity;
        _ = this.ShipDate;
        this.Status?.Validate();
    }

    public OrderOrder() { }

    public OrderOrder(OrderOrder orderOrder)
        : base(orderOrder) { }

    public OrderOrder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrderOrder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrderOrderFromRaw.FromRawUnchecked"/>
    public static OrderOrder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrderOrderFromRaw : IFromRawJson<OrderOrder>
{
    /// <inheritdoc/>
    public OrderOrder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrderOrder.FromRawUnchecked(rawData);
}

/// <summary>
/// Order Status
/// </summary>
[JsonConverter(typeof(OrderOrderStatusConverter))]
public enum OrderOrderStatus
{
    Placed,
    Approved,
    Delivered,
}

sealed class OrderOrderStatusConverter : JsonConverter<OrderOrderStatus>
{
    public override OrderOrderStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "placed" => OrderOrderStatus.Placed,
            "approved" => OrderOrderStatus.Approved,
            "delivered" => OrderOrderStatus.Delivered,
            _ => (OrderOrderStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrderOrderStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrderOrderStatus.Placed => "placed",
                OrderOrderStatus.Approved => "approved",
                OrderOrderStatus.Delivered => "delivered",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
