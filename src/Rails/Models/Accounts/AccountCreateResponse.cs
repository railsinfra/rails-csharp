using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountCreateResponse, AccountCreateResponseFromRaw>))]
public sealed record class AccountCreateResponse : JsonModel
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

    public required ApiEnum<string, AccountCreateResponseAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountCreateResponseAccountType>>(
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

    public required ApiEnum<string, AccountCreateResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountCreateResponseStatus>>(
                "status"
            );
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

    public AccountCreateResponse() { }

    public AccountCreateResponse(AccountCreateResponse accountCreateResponse)
        : base(accountCreateResponse) { }

    public AccountCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountCreateResponseFromRaw.FromRawUnchecked"/>
    public static AccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountCreateResponseFromRaw : IFromRawJson<AccountCreateResponse>
{
    /// <inheritdoc/>
    public AccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountCreateResponseAccountTypeConverter))]
public enum AccountCreateResponseAccountType
{
    Checking,
    Saving,
}

sealed class AccountCreateResponseAccountTypeConverter
    : JsonConverter<AccountCreateResponseAccountType>
{
    public override AccountCreateResponseAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AccountCreateResponseAccountType.Checking,
            "saving" => AccountCreateResponseAccountType.Saving,
            _ => (AccountCreateResponseAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountCreateResponseAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountCreateResponseAccountType.Checking => "checking",
                AccountCreateResponseAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountCreateResponseStatusConverter))]
public enum AccountCreateResponseStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class AccountCreateResponseStatusConverter : JsonConverter<AccountCreateResponseStatus>
{
    public override AccountCreateResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountCreateResponseStatus.Active,
            "suspended" => AccountCreateResponseStatus.Suspended,
            "closed" => AccountCreateResponseStatus.Closed,
            _ => (AccountCreateResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountCreateResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountCreateResponseStatus.Active => "active",
                AccountCreateResponseStatus.Suspended => "suspended",
                AccountCreateResponseStatus.Closed => "closed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
