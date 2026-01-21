using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Pet;

namespace Rails.Services;

/// <inheritdoc/>
public sealed class PetService : IPetService
{
    readonly Lazy<IPetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IRailsClient _client;

    /// <inheritdoc/>
    public IPetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PetService(this._client.WithOptions(modifier));
    }

    public PetService(IRailsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PetPet> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PetPet> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PetPet> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PetPet> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(PetDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { PetID = petID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<PetPet>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FindByStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<PetPet>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FindByTags(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task UpdateWithFormData(
        PetUpdateWithFormDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.UpdateWithFormData(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateWithFormData(
        long petID,
        PetUpdateWithFormDataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.UpdateWithFormData(parameters with { PetID = petID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PetUploadImageResponse> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadImage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PetUploadImageResponse> UploadImage(
        long petID,
        BinaryContent body,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(parameters with { PetID = petID, Body = body }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PetServiceWithRawResponse : IPetServiceWithRawResponse
{
    readonly IRailsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PetServiceWithRawResponse(IRailsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PetPet>> Create(
        PetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<PetPet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PetPet>> Retrieve(
        PetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new RailsInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<PetPet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PetPet>> Retrieve(
        long petID,
        PetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PetPet>> Update(
        PetUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PetUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pet = await response.Deserialize<PetPet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pet.Validate();
                }
                return pet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new RailsInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long petID,
        PetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<PetPet>>> FindByStatus(
        PetFindByStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PetFindByStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pets = await response.Deserialize<List<PetPet>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pets)
                    {
                        item.Validate();
                    }
                }
                return pets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<PetPet>>> FindByTags(
        PetFindByTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PetFindByTagsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pets = await response.Deserialize<List<PetPet>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pets)
                    {
                        item.Validate();
                    }
                }
                return pets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UpdateWithFormData(
        PetUpdateWithFormDataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new RailsInvalidDataException("'parameters.PetID' cannot be null");
        }

        HttpRequest<PetUpdateWithFormDataParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UpdateWithFormData(
        long petID,
        PetUpdateWithFormDataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateWithFormData(parameters with { PetID = petID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        PetUploadImageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PetID == null)
        {
            throw new RailsInvalidDataException("'parameters.PetID' cannot be null");
        }
        if (parameters.Body == null)
        {
            throw new RailsInvalidDataException("'parameters.Body' cannot be null");
        }

        HttpRequest<PetUploadImageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PetUploadImageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PetUploadImageResponse>> UploadImage(
        long petID,
        BinaryContent body,
        PetUploadImageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadImage(parameters with { PetID = petID, Body = body }, cancellationToken);
    }
}
