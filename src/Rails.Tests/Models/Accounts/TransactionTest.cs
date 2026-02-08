using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class TransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        ApiEnum<string, TransactionStatus> expectedStatus = TransactionStatus.Pending;
        ApiEnum<string, TransactionType> expectedTransactionType = TransactionType.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedExternalRecipientID = "external_recipient_id";
        string expectedRecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBalanceAfter, model.BalanceAfter);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionType, model.TransactionType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExternalRecipientID, model.ExternalRecipientID);
        Assert.Equal(expectedRecipientAccountID, model.RecipientAccountID);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedBalanceAfter = "balance_after";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        ApiEnum<string, TransactionStatus> expectedStatus = TransactionStatus.Pending;
        ApiEnum<string, TransactionType> expectedTransactionType = TransactionType.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedExternalRecipientID = "external_recipient_id";
        string expectedRecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBalanceAfter, deserialized.BalanceAfter);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionType, deserialized.TransactionType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExternalRecipientID, deserialized.ExternalRecipientID);
        Assert.Equal(expectedRecipientAccountID, deserialized.RecipientAccountID);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalRecipientID);
        Assert.False(model.RawData.ContainsKey("external_recipient_id"));
        Assert.Null(model.RecipientAccountID);
        Assert.False(model.RawData.ContainsKey("recipient_account_id"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            ExternalRecipientID = null,
            RecipientAccountID = null,
            ReferenceID = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalRecipientID);
        Assert.True(model.RawData.ContainsKey("external_recipient_id"));
        Assert.Null(model.RecipientAccountID);
        Assert.True(model.RawData.ContainsKey("recipient_account_id"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
            ExternalRecipientID = null,
            RecipientAccountID = null,
            ReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transaction
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            BalanceAfter = "balance_after",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            Status = TransactionStatus.Pending,
            TransactionType = TransactionType.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExternalRecipientID = "external_recipient_id",
            RecipientAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ReferenceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Transaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionStatusTest : TestBase
{
    [Theory]
    [InlineData(TransactionStatus.Pending)]
    [InlineData(TransactionStatus.Completed)]
    [InlineData(TransactionStatus.Failed)]
    [InlineData(TransactionStatus.Cancelled)]
    public void Validation_Works(TransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionStatus.Pending)]
    [InlineData(TransactionStatus.Completed)]
    [InlineData(TransactionStatus.Failed)]
    [InlineData(TransactionStatus.Cancelled)]
    public void SerializationRoundtrip_Works(TransactionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(TransactionType.Deposit)]
    [InlineData(TransactionType.Withdrawal)]
    [InlineData(TransactionType.Transfer)]
    [InlineData(TransactionType.RecurringPayment)]
    [InlineData(TransactionType.SavingsWithdraw)]
    public void Validation_Works(TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionType.Deposit)]
    [InlineData(TransactionType.Withdrawal)]
    [InlineData(TransactionType.Transfer)]
    [InlineData(TransactionType.RecurringPayment)]
    [InlineData(TransactionType.SavingsWithdraw)]
    public void SerializationRoundtrip_Works(TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
