using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountWithdrawResponse, AccountWithdrawResponseFromRaw>))]
public sealed record class AccountWithdrawResponse : JsonModel
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

    public AccountWithdrawResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountWithdrawResponse(AccountWithdrawResponse accountWithdrawResponse)
        : base(accountWithdrawResponse) { }
#pragma warning restore CS8618

    public AccountWithdrawResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountWithdrawResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountWithdrawResponseFromRaw.FromRawUnchecked"/>
    public static AccountWithdrawResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountWithdrawResponseFromRaw : IFromRawJson<AccountWithdrawResponse>
{
    /// <inheritdoc/>
    public AccountWithdrawResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountWithdrawResponse.FromRawUnchecked(rawData);
}
