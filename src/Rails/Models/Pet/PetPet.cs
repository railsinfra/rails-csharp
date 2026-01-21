using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Pet;

[JsonConverter(typeof(JsonModelConverter<PetPet, PetPetFromRaw>))]
public sealed record class PetPet : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required IReadOnlyList<string> PhotoUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("photoUrls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "photoUrls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public PetPetCategory? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PetPetCategory>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public ApiEnum<string, PetPetStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PetPetStatus>>("status");
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

    public IReadOnlyList<PetPetTag>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PetPetTag>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PetPetTag>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.PhotoUrls;
        _ = this.ID;
        this.Category?.Validate();
        this.Status?.Validate();
        foreach (var item in this.Tags ?? [])
        {
            item.Validate();
        }
    }

    public PetPet() { }

    public PetPet(PetPet petPet)
        : base(petPet) { }

    public PetPet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetPet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetPetFromRaw.FromRawUnchecked"/>
    public static PetPet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetPetFromRaw : IFromRawJson<PetPet>
{
    /// <inheritdoc/>
    public PetPet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PetPet.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PetPetCategory, PetPetCategoryFromRaw>))]
public sealed record class PetPetCategory : JsonModel
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

    public PetPetCategory() { }

    public PetPetCategory(PetPetCategory petPetCategory)
        : base(petPetCategory) { }

    public PetPetCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetPetCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetPetCategoryFromRaw.FromRawUnchecked"/>
    public static PetPetCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetPetCategoryFromRaw : IFromRawJson<PetPetCategory>
{
    /// <inheritdoc/>
    public PetPetCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PetPetCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(PetPetStatusConverter))]
public enum PetPetStatus
{
    Available,
    Pending,
    Sold,
}

sealed class PetPetStatusConverter : JsonConverter<PetPetStatus>
{
    public override PetPetStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => PetPetStatus.Available,
            "pending" => PetPetStatus.Pending,
            "sold" => PetPetStatus.Sold,
            _ => (PetPetStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PetPetStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PetPetStatus.Available => "available",
                PetPetStatus.Pending => "pending",
                PetPetStatus.Sold => "sold",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PetPetTag, PetPetTagFromRaw>))]
public sealed record class PetPetTag : JsonModel
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

    public PetPetTag() { }

    public PetPetTag(PetPetTag petPetTag)
        : base(petPetTag) { }

    public PetPetTag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetPetTag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetPetTagFromRaw.FromRawUnchecked"/>
    public static PetPetTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetPetTagFromRaw : IFromRawJson<PetPetTag>
{
    /// <inheritdoc/>
    public PetPetTag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PetPetTag.FromRawUnchecked(rawData);
}
