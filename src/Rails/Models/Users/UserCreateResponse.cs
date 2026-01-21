using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.Users;

[JsonConverter(typeof(JsonModelConverter<UserCreateResponse, UserCreateResponseFromRaw>))]
public sealed record class UserCreateResponse : JsonModel
{
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.UserID;
    }

    public UserCreateResponse() { }

    public UserCreateResponse(UserCreateResponse userCreateResponse)
        : base(userCreateResponse) { }

    public UserCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserCreateResponseFromRaw.FromRawUnchecked"/>
    public static UserCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserCreateResponseFromRaw : IFromRawJson<UserCreateResponse>
{
    /// <inheritdoc/>
    public UserCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserCreateResponse.FromRawUnchecked(rawData);
}
