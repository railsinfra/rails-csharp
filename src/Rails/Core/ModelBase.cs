using System.Text.Json;
using Rails.Exceptions;
using Rails.Models.Accounts;
using Rails.Models.Users;
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
            new ApiEnumConverter<string, XEnvironment>(),
            new ApiEnumConverter<string, AccountCreateResponseAccountType>(),
            new ApiEnumConverter<string, AccountCreateResponseStatus>(),
            new ApiEnumConverter<string, AccountRetrieveResponseAccountType>(),
            new ApiEnumConverter<string, AccountRetrieveResponseStatus>(),
            new ApiEnumConverter<string, AccountListResponseAccountType>(),
            new ApiEnumConverter<string, AccountListResponseStatus>(),
            new ApiEnumConverter<string, AccountCloseResponseAccountType>(),
            new ApiEnumConverter<string, AccountCloseResponseStatus>(),
            new ApiEnumConverter<string, AccountAccountType>(),
            new ApiEnumConverter<string, AccountStatus>(),
            new ApiEnumConverter<string, TransactionStatus>(),
            new ApiEnumConverter<string, TransactionType>(),
            new ApiEnumConverter<string, FromAccountAccountType>(),
            new ApiEnumConverter<string, FromAccountStatus>(),
            new ApiEnumConverter<string, ToAccountAccountType>(),
            new ApiEnumConverter<string, ToAccountStatus>(),
            new ApiEnumConverter<string, AccountTransferResponseTransactionStatus>(),
            new ApiEnumConverter<string, AccountTransferResponseTransactionTransactionType>(),
            new ApiEnumConverter<string, AccountUpdateStatusResponseAccountType>(),
            new ApiEnumConverter<string, AccountUpdateStatusResponseStatus>(),
            new ApiEnumConverter<string, AccountWithdrawResponseAccountAccountType>(),
            new ApiEnumConverter<string, AccountWithdrawResponseAccountStatus>(),
            new ApiEnumConverter<string, AccountWithdrawResponseTransactionStatus>(),
            new ApiEnumConverter<string, AccountWithdrawResponseTransactionTransactionType>(),
            new ApiEnumConverter<string, AccountType>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Transactions::Status>(),
            new ApiEnumConverter<string, Transactions::TransactionType>(),
            new ApiEnumConverter<string, Transactions::DataStatus>(),
            new ApiEnumConverter<string, Transactions::TransactionKind>(),
            new ApiEnumConverter<string, Transactions::TransactionListByAccountResponseStatus>(),
            new ApiEnumConverter<
                string,
                Transactions::TransactionListByAccountResponseTransactionType
            >(),
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
