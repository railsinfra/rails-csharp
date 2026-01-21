using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.Pet;

[JsonConverter(typeof(JsonModelConverter<PetUploadImageResponse, PetUploadImageResponseFromRaw>))]
public sealed record class PetUploadImageResponse : JsonModel
{
    public int? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Message;
        _ = this.Type;
    }

    public PetUploadImageResponse() { }

    public PetUploadImageResponse(PetUploadImageResponse petUploadImageResponse)
        : base(petUploadImageResponse) { }

    public PetUploadImageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PetUploadImageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetUploadImageResponseFromRaw.FromRawUnchecked"/>
    public static PetUploadImageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetUploadImageResponseFromRaw : IFromRawJson<PetUploadImageResponse>
{
    /// <inheritdoc/>
    public PetUploadImageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PetUploadImageResponse.FromRawUnchecked(rawData);
}
