using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.Accounts;
using Rails.Models.Transactions;

namespace Rails.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve transaction
    /// </summary>
    Task<Transaction> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<Transaction> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List transactions by organization
    /// </summary>
    Task<TransactionListResponse> List(
        TransactionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List account transactions
    /// </summary>
    Task<List<Transaction>> ListByAccount(
        TransactionListByAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByAccount(TransactionListByAccountParams, CancellationToken)"/>
    Task<List<Transaction>> ListByAccount(
        string accountID,
        TransactionListByAccountParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/transactions/{id}`, but is otherwise the
    /// same as <see cref="ITransactionService.Retrieve(TransactionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Transaction>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Transaction>> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/transactions`, but is otherwise the
    /// same as <see cref="ITransactionService.List(TransactionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionListResponse>> List(
        TransactionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/accounts/{account_id}/transactions`, but is otherwise the
    /// same as <see cref="ITransactionService.ListByAccount(TransactionListByAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Transaction>>> ListByAccount(
        TransactionListByAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByAccount(TransactionListByAccountParams, CancellationToken)"/>
    Task<HttpResponse<List<Transaction>>> ListByAccount(
        string accountID,
        TransactionListByAccountParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
