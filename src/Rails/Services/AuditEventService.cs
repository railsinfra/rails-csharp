using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.AuditEvents;

namespace Rails.Services;

/// <inheritdoc/>
public sealed class AuditEventService : IAuditEventService
{
    readonly Lazy<IAuditEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuditEventService(this._client.WithOptions(modifier));
    }

    public AuditEventService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AuditEventServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AuditEventServiceWithRawResponse : IAuditEventServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuditEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuditEventServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuditEventListResponse>> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AuditEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var auditEvents = await response
                    .Deserialize<AuditEventListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    auditEvents.Validate();
                }
                return auditEvents;
            }
        );
    }
}
