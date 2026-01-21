using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Models.Pet;

namespace Rails.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new pet to the store
    /// </summary>
    Task<PetPet> Create(PetCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single pet
    /// </summary>
    Task<PetPet> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PetRetrieveParams, CancellationToken)"/>
    Task<PetPet> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing pet by Id
    /// </summary>
    Task<PetPet> Update(PetUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// delete a pet
    /// </summary>
    Task Delete(PetDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(PetDeleteParams, CancellationToken)"/>
    Task Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Multiple status values can be provided with comma separated strings
    /// </summary>
    Task<List<PetPet>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Multiple tags can be provided with comma separated strings. Use tag1, tag2,
    /// tag3 for testing.
    /// </summary>
    Task<List<PetPet>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a pet in the store with form data
    /// </summary>
    Task UpdateWithFormData(
        PetUpdateWithFormDataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateWithFormData(PetUpdateWithFormDataParams, CancellationToken)"/>
    Task UpdateWithFormData(
        long petID,
        PetUpdateWithFormDataParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// uploads an image
    /// </summary>
    Task<PetUploadImageResponse> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PetUploadImageParams, CancellationToken)"/>
    Task<PetUploadImageResponse> UploadImage(
        long petID,
        BinaryContent body,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /pet`, but is otherwise the
    /// same as <see cref="IPetService.Create(PetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PetPet>> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /pet/{petId}`, but is otherwise the
    /// same as <see cref="IPetService.Retrieve(PetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PetPet>> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PetPet>> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /pet`, but is otherwise the
    /// same as <see cref="IPetService.Update(PetUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PetPet>> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /pet/{petId}`, but is otherwise the
    /// same as <see cref="IPetService.Delete(PetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        PetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PetDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /pet/findByStatus`, but is otherwise the
    /// same as <see cref="IPetService.FindByStatus(PetFindByStatusParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<PetPet>>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /pet/findByTags`, but is otherwise the
    /// same as <see cref="IPetService.FindByTags(PetFindByTagsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<PetPet>>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /pet/{petId}`, but is otherwise the
    /// same as <see cref="IPetService.UpdateWithFormData(PetUpdateWithFormDataParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> UpdateWithFormData(
        PetUpdateWithFormDataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateWithFormData(PetUpdateWithFormDataParams, CancellationToken)"/>
    Task<HttpResponse> UpdateWithFormData(
        long petID,
        PetUpdateWithFormDataParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /pet/{petId}/uploadImage`, but is otherwise the
    /// same as <see cref="IPetService.UploadImage(PetUploadImageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadImage(PetUploadImageParams, CancellationToken)"/>
    Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        long petID,
        BinaryContent body,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
