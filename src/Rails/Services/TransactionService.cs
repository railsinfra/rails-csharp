using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models;
using Rails.Models.Transactions;

namespace Rails.Services;

/// <inheritdoc/>
public sealed class TransactionService : ITransactionService
{
    readonly Lazy<ITransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionService(this._client.WithOptions(modifier));
    }

    public TransactionService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TransactionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Transaction> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Transaction> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionListResponse> List(
        TransactionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<Transaction>> ListByAccount(
        TransactionListByAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<Transaction>> ListByAccount(
        string accountID,
        TransactionListByAccountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByAccount(parameters with { AccountID = accountID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TransactionServiceWithRawResponse : ITransactionServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Transaction>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new RailsInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transaction = await response
                    .Deserialize<Transaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transaction.Validate();
                }
                return transaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Transaction>> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionListResponse>> List(
        TransactionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransactionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactions = await response
                    .Deserialize<TransactionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactions.Validate();
                }
                return transactions;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Transaction>>> ListByAccount(
        TransactionListByAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountID == null)
        {
            throw new RailsInvalidDataException("'parameters.AccountID' cannot be null");
        }

        HttpRequest<TransactionListByAccountParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactions = await response
                    .Deserialize<List<Transaction>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in transactions)
                    {
                        item.Validate();
                    }
                }
                return transactions;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<Transaction>>> ListByAccount(
        string accountID,
        TransactionListByAccountParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByAccount(parameters with { AccountID = accountID }, cancellationToken);
    }
}
