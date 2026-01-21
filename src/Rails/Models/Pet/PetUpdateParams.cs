using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Pet;

/// <summary>
/// Update an existing pet by Id
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PetUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public required IReadOnlyList<string> PhotoUrls
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("photoUrls");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "photoUrls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? ID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("id", value);
        }
    }

    public PetUpdateParamsCategory? Category
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PetUpdateParamsCategory>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("category", value);
        }
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public ApiEnum<string, PetUpdateParamsStatus>? Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PetUpdateParamsStatus>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    public IReadOnlyList<PetUpdateParamsTag>? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<PetUpdateParamsTag>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<PetUpdateParamsTag>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PetUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PetUpdateParams(PetUpdateParams petUpdateParams)
        : base(petUpdateParams)
    {
        this._rawBodyData = new(petUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PetUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PetUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PetUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/pet")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<PetUpdateParamsCategory, PetUpdateParamsCategoryFromRaw>))]
public sealed record class PetUpdateParamsCategory : JsonModel
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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public PetUpdateParamsCategory() { }

    public PetUpdateParamsCategory(PetUpdateParamsCategory petUpdateParamsCategory)
        : base(petUpdateParamsCategory) { }

    public PetUpdateParamsCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetUpdateParamsCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetUpdateParamsCategoryFromRaw.FromRawUnchecked"/>
    public static PetUpdateParamsCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetUpdateParamsCategoryFromRaw : IFromRawJson<PetUpdateParamsCategory>
{
    /// <inheritdoc/>
    public PetUpdateParamsCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PetUpdateParamsCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(PetUpdateParamsStatusConverter))]
public enum PetUpdateParamsStatus
{
    Available,
    Pending,
    Sold,
}

sealed class PetUpdateParamsStatusConverter : JsonConverter<PetUpdateParamsStatus>
{
    public override PetUpdateParamsStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => PetUpdateParamsStatus.Available,
            "pending" => PetUpdateParamsStatus.Pending,
            "sold" => PetUpdateParamsStatus.Sold,
            _ => (PetUpdateParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PetUpdateParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PetUpdateParamsStatus.Available => "available",
                PetUpdateParamsStatus.Pending => "pending",
                PetUpdateParamsStatus.Sold => "sold",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PetUpdateParamsTag, PetUpdateParamsTagFromRaw>))]
public sealed record class PetUpdateParamsTag : JsonModel
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

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public PetUpdateParamsTag() { }

    public PetUpdateParamsTag(PetUpdateParamsTag petUpdateParamsTag)
        : base(petUpdateParamsTag) { }

    public PetUpdateParamsTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetUpdateParamsTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetUpdateParamsTagFromRaw.FromRawUnchecked"/>
    public static PetUpdateParamsTag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetUpdateParamsTagFromRaw : IFromRawJson<PetUpdateParamsTag>
{
    /// <inheritdoc/>
    public PetUpdateParamsTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PetUpdateParamsTag.FromRawUnchecked(rawData);
}
