using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Services;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Account> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Account> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Account>> List(
        AccountListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Account> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Close(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> Close(
        string id,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountDepositResponse> Deposit(
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deposit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountDepositResponse> Deposit(
        string id,
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Deposit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountTransferResponse> Transfer(
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Transfer(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountTransferResponse> Transfer(
        string id,
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Account> UpdateStatus(
        AccountUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Account> UpdateStatus(
        string id,
        AccountUpdateStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateStatus(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountWithdrawResponse> Withdraw(
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Withdraw(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountWithdrawResponse> Withdraw(
        string id,
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Withdraw(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Account>>> List(
        AccountListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accounts = await response
                    .Deserialize<List<Account>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in accounts)
                    {
                        item.Validate();
                    }
                }
                return accounts;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountCloseParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> Close(
        string id,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Close(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountDepositResponse>> Deposit(
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountDepositParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AccountDepositResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountDepositResponse>> Deposit(
        string id,
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Deposit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountTransferResponse>> Transfer(
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountTransferParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AccountTransferResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountTransferResponse>> Transfer(
        string id,
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Account>> UpdateStatus(
        AccountUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountUpdateStatusParams> request = new()
        {
            Method = RailsClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var account = await response.Deserialize<Account>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    account.Validate();
                }
                return account;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Account>> UpdateStatus(
        string id,
        AccountUpdateStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateStatus(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountWithdrawResponse>> Withdraw(
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AccountWithdrawParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AccountWithdrawResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountWithdrawResponse>> Withdraw(
        string id,
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Withdraw(parameters with { ID = id }, cancellationToken);
    }
}
