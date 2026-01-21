using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.Accounts;

namespace Rails.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create account
    /// </summary>
    Task<AccountCreateResponse> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve account
    /// </summary>
    Task<AccountRetrieveResponse> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<AccountRetrieveResponse> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List accounts
    /// </summary>
    Task<List<AccountListResponse>> List(
        AccountListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Close account
    /// </summary>
    Task<AccountCloseResponse> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Close(AccountCloseParams, CancellationToken)"/>
    Task<AccountCloseResponse> Close(
        string id,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deposit into account
    /// </summary>
    Task<AccountDepositResponse> Deposit(
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deposit(AccountDepositParams, CancellationToken)"/>
    Task<AccountDepositResponse> Deposit(
        string id,
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transfer between accounts
    /// </summary>
    Task<AccountTransferResponse> Transfer(
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Transfer(AccountTransferParams, CancellationToken)"/>
    Task<AccountTransferResponse> Transfer(
        string id,
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update account status
    /// </summary>
    Task<AccountUpdateStatusResponse> UpdateStatus(
        AccountUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateStatus(AccountUpdateStatusParams, CancellationToken)"/>
    Task<AccountUpdateStatusResponse> UpdateStatus(
        string id,
        AccountUpdateStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Withdraw from account
    /// </summary>
    Task<AccountWithdrawResponse> Withdraw(
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Withdraw(AccountWithdrawParams, CancellationToken)"/>
    Task<AccountWithdrawResponse> Withdraw(
        string id,
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/accounts`, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountCreateResponse>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/accounts/{id}`, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountRetrieveResponse>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountRetrieveResponse>> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/accounts`, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AccountListResponse>>> List(
        AccountListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/accounts/{id}`, but is otherwise the
    /// same as <see cref="IAccountService.Close(AccountCloseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountCloseResponse>> Close(
        AccountCloseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Close(AccountCloseParams, CancellationToken)"/>
    Task<HttpResponse<AccountCloseResponse>> Close(
        string id,
        AccountCloseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/accounts/{id}/deposit`, but is otherwise the
    /// same as <see cref="IAccountService.Deposit(AccountDepositParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountDepositResponse>> Deposit(
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deposit(AccountDepositParams, CancellationToken)"/>
    Task<HttpResponse<AccountDepositResponse>> Deposit(
        string id,
        AccountDepositParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/accounts/{id}/transfer`, but is otherwise the
    /// same as <see cref="IAccountService.Transfer(AccountTransferParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountTransferResponse>> Transfer(
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Transfer(AccountTransferParams, CancellationToken)"/>
    Task<HttpResponse<AccountTransferResponse>> Transfer(
        string id,
        AccountTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/accounts/{id}`, but is otherwise the
    /// same as <see cref="IAccountService.UpdateStatus(AccountUpdateStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountUpdateStatusResponse>> UpdateStatus(
        AccountUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateStatus(AccountUpdateStatusParams, CancellationToken)"/>
    Task<HttpResponse<AccountUpdateStatusResponse>> UpdateStatus(
        string id,
        AccountUpdateStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/accounts/{id}/withdraw`, but is otherwise the
    /// same as <see cref="IAccountService.Withdraw(AccountWithdrawParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountWithdrawResponse>> Withdraw(
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Withdraw(AccountWithdrawParams, CancellationToken)"/>
    Task<HttpResponse<AccountWithdrawResponse>> Withdraw(
        string id,
        AccountWithdrawParams parameters,
        CancellationToken cancellationToken = default
    );
}
