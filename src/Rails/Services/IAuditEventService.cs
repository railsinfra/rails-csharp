using System;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.AuditEvents;

namespace Rails.Services;

/// <summary>
/// Audit events
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAuditEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuditEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List audit events
    /// </summary>
    Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAuditEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuditEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/audit/events</c>, but is otherwise the
    /// same as <see cref="IAuditEventService.List(AuditEventListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AuditEventListResponse>> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
