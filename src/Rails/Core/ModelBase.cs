using System.Text.Json;
using Rails.Exceptions;
using Rails.Models.Pet;
using Order = Rails.Models.Store.Order;

namespace Rails.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, PetPetStatus>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, PetUpdateParamsStatus>(),
            new ApiEnumConverter<string, PetFindByStatusParamsStatus>(),
            new ApiEnumConverter<string, Order::OrderOrderStatus>(),
            new ApiEnumConverter<string, Order::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="RailsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
