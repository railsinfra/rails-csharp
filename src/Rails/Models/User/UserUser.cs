using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.User;

[JsonConverter(typeof(JsonModelConverter<UserUser, UserUserFromRaw>))]
public sealed record class UserUser : JsonModel
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

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("firstName", value);
        }
    }

    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastName", value);
        }
    }

    public string? Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("password");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("password", value);
        }
    }

    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <summary>
    /// User Status
    /// </summary>
    public int? UserStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("userStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userStatus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.Password;
        _ = this.Phone;
        _ = this.Username;
        _ = this.UserStatus;
    }

    public UserUser() { }

    public UserUser(UserUser userUser)
        : base(userUser) { }

    public UserUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserUserFromRaw.FromRawUnchecked"/>
    public static UserUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserUserFromRaw : IFromRawJson<UserUser>
{
    /// <inheritdoc/>
    public UserUser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserUser.FromRawUnchecked(rawData);
}
