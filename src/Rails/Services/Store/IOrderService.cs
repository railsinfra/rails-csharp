using System;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.Store.Order;

namespace Rails.Services.Store;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Place a new order in the store
    /// </summary>
    Task<OrderOrder> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For valid response try integer IDs with value <= 5 or > 10. Other values will
    /// generate exceptions.
    /// </summary>
    Task<OrderOrder> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrderRetrieveParams, CancellationToken)"/>
    Task<OrderOrder> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// For valid response try integer IDs with value < 1000. Anything above 1000
    /// or nonintegers will generate API errors
    /// </summary>
    Task Delete(OrderDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(OrderDeleteParams, CancellationToken)"/>
    Task Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOrderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOrderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /store/order`, but is otherwise the
    /// same as <see cref="IOrderService.Create(OrderCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrderOrder>> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /store/order/{orderId}`, but is otherwise the
    /// same as <see cref="IOrderService.Retrieve(OrderRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrderOrder>> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(OrderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<OrderOrder>> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /store/order/{orderId}`, but is otherwise the
    /// same as <see cref="IOrderService.Delete(OrderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        OrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(OrderDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
