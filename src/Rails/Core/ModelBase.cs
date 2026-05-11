using System.Text.Json;
using Rails.Exceptions;
using Rails.Models;
using Rails.Models.AuditEvents;
using Rails.Models.Users;
using Accounts = Rails.Models.Accounts;
using Transactions = Rails.Models.Transactions;

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
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, TransactionType>(),
            new ApiEnumConverter<string, XEnvironment>(),
            new ApiEnumConverter<string, Accounts::AccountAccountType>(),
            new ApiEnumConverter<string, Accounts::AccountStatus>(),
            new ApiEnumConverter<string, Accounts::AccountType>(),
            new ApiEnumConverter<string, Accounts::Status>(),
            new ApiEnumConverter<string, Transactions::Status>(),
            new ApiEnumConverter<string, Transactions::TransactionKind>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, DataEnvironment>(),
            new ApiEnumConverter<string, DataOutcome>(),
            new ApiEnumConverter<long, SchemaVersion>(),
            new ApiEnumConverter<string, SourceService>(),
            new ApiEnumConverter<string, Environment>(),
            new ApiEnumConverter<string, Outcome>(),
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
