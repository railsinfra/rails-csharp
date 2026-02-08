using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;

namespace Rails.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountTransferResponse, AccountTransferResponseFromRaw>))]
public sealed record class AccountTransferResponse : JsonModel
{
    public required Account FromAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Account>("from_account");
        }
        init { this._rawData.Set("from_account", value); }
    }

    public required Account ToAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Account>("to_account");
        }
        init { this._rawData.Set("to_account", value); }
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
        this.FromAccount.Validate();
        this.ToAccount.Validate();
        this.Transaction.Validate();
    }

    public AccountTransferResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountTransferResponse(AccountTransferResponse accountTransferResponse)
        : base(accountTransferResponse) { }
#pragma warning restore CS8618

    public AccountTransferResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountTransferResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountTransferResponseFromRaw.FromRawUnchecked"/>
    public static AccountTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountTransferResponseFromRaw : IFromRawJson<AccountTransferResponse>
{
    /// <inheritdoc/>
    public AccountTransferResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountTransferResponse.FromRawUnchecked(rawData);
}
