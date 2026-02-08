using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountDepositResponse, AccountDepositResponseFromRaw>))]
public sealed record class AccountDepositResponse : JsonModel
{
    public required Account Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Account>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    public required Transaction Transaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Transaction>("transaction");
        }
        init { this._rawData.Set("transaction", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Account.Validate();
        this.Transaction.Validate();
    }

    public AccountDepositResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountDepositResponse(AccountDepositResponse accountDepositResponse)
        : base(accountDepositResponse) { }
#pragma warning restore CS8618

    public AccountDepositResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountDepositResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountDepositResponseFromRaw.FromRawUnchecked"/>
    public static AccountDepositResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountDepositResponseFromRaw : IFromRawJson<AccountDepositResponse>
{
    /// <inheritdoc/>
    public AccountDepositResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountDepositResponse.FromRawUnchecked(rawData);
}
