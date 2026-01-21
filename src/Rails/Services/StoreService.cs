using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.Store;
using Rails.Services.Store;

namespace Rails.Services;

/// <inheritdoc/>
public sealed class StoreService : IStoreService
{
    readonly Lazy<IStoreServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStoreServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public IStoreService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StoreService(this._client.WithOptions(modifier));
    }

    public StoreService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StoreServiceWithRawResponse(client.WithRawResponse));
        _order = new(() => new OrderService(client));
    }

    readonly Lazy<IOrderService> _order;
    public IOrderService Order
    {
        get { return _order.Value; }
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, int>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListInventory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StoreServiceWithRawResponse : IStoreServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StoreServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StoreServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;

        _order = new(() => new OrderServiceWithRawResponse(client));
    }

    readonly Lazy<IOrderServiceWithRawResponse> _order;
    public IOrderServiceWithRawResponse Order
    {
        get { return _order.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, int>>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StoreListInventoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, int>>(token)
                    .ConfigureAwait(false);
            }
        );
    }
}
