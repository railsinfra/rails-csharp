using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountListResponse, AccountListResponseFromRaw>))]
public sealed record class AccountListResponse : JsonModel
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

    public required ApiEnum<string, AccountListResponseAccountType> AccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountListResponseAccountType>>(
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

    public required ApiEnum<string, AccountListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountListResponseStatus>>(
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

    public AccountListResponse() { }

    public AccountListResponse(AccountListResponse accountListResponse)
        : base(accountListResponse) { }

    public AccountListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountListResponseFromRaw.FromRawUnchecked"/>
    public static AccountListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountListResponseFromRaw : IFromRawJson<AccountListResponse>
{
    /// <inheritdoc/>
    public AccountListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountListResponseAccountTypeConverter))]
public enum AccountListResponseAccountType
{
    Checking,
    Saving,
}

sealed class AccountListResponseAccountTypeConverter : JsonConverter<AccountListResponseAccountType>
{
    public override AccountListResponseAccountType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "checking" => AccountListResponseAccountType.Checking,
            "saving" => AccountListResponseAccountType.Saving,
            _ => (AccountListResponseAccountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountListResponseAccountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountListResponseAccountType.Checking => "checking",
                AccountListResponseAccountType.Saving => "saving",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountListResponseStatusConverter))]
public enum AccountListResponseStatus
{
    Active,
    Suspended,
    Closed,
}

sealed class AccountListResponseStatusConverter : JsonConverter<AccountListResponseStatus>
{
    public override AccountListResponseStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => AccountListResponseStatus.Active,
            "suspended" => AccountListResponseStatus.Suspended,
            "closed" => AccountListResponseStatus.Closed,
            _ => (AccountListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountListResponseStatus.Active => "active",
                AccountListResponseStatus.Suspended => "suspended",
                AccountListResponseStatus.Closed => "closed",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
