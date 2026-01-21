using System;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.User;

namespace Rails.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task<UserUser> Create(
        UserCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get user by user name
    /// </summary>
    Task<UserUser> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<UserUser> Retrieve(
        string username,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task Update(UserUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task Update(
        string existingUsername,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This can only be done by the logged in user.
    /// </summary>
    Task Delete(UserDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task Delete(
        string username,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates list of users with given input array
    /// </summary>
    Task<UserUser> CreateWithList(
        UserCreateWithListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Logs user into the system
    /// </summary>
    Task<string> Login(
        UserLoginParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Logs out current logged in user session
    /// </summary>
    Task Logout(UserLogoutParams? parameters = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /user`, but is otherwise the
    /// same as <see cref="IUserService.Create(UserCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserUser>> Create(
        UserCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /user/{username}`, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserUser>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserUser>> Retrieve(
        string username,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /user/{username}`, but is otherwise the
    /// same as <see cref="IUserService.Update(UserUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string existingUsername,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /user/{username}`, but is otherwise the
    /// same as <see cref="IUserService.Delete(UserDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string username,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /user/createWithList`, but is otherwise the
    /// same as <see cref="IUserService.CreateWithList(UserCreateWithListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserUser>> CreateWithList(
        UserCreateWithListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /user/login`, but is otherwise the
    /// same as <see cref="IUserService.Login(UserLoginParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<string>> Login(
        UserLoginParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /user/logout`, but is otherwise the
    /// same as <see cref="IUserService.Logout(UserLogoutParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Logout(
        UserLogoutParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
