using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Store.Order;

namespace Rails.Services.Store;

/// <inheritdoc/>
public sealed class OrderService : IOrderService
{
    readonly Lazy<IOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public IOrderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrderService(this._client.WithOptions(modifier));
    }

    public OrderService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OrderServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OrderOrder> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OrderOrder> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OrderOrder> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { OrderID = orderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(OrderDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { OrderID = orderID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OrderServiceWithRawResponse : IOrderServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOrderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OrderServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrderOrder>> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var order = await response.Deserialize<OrderOrder>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    order.Validate();
                }
                return order;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrderOrder>> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new RailsInvalidDataException("'parameters.OrderID' cannot be null");
        }

        HttpRequest<OrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var order = await response.Deserialize<OrderOrder>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    order.Validate();
                }
                return order;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OrderOrder>> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { OrderID = orderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        OrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new RailsInvalidDataException("'parameters.OrderID' cannot be null");
        }

        HttpRequest<OrderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { OrderID = orderID }, cancellationToken);
    }
}
