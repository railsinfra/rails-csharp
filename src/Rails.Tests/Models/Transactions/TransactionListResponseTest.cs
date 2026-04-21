using System;
using System.Collections.Generic;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Transactions;

namespace Rails.Tests.Models.Transactions;

public class TransactionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = Status.Pending,
                    ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TransactionKind = TransactionKind.Deposit,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = "environment",
                    FailureReason = "failure_reason",
                    IdempotencyKey = "idempotency_key",
                },
            ],
            Pagination = new()
            {
                Page = 1,
                PerPage = 1,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Status = Status.Pending,
                ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TransactionKind = TransactionKind.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Environment = "environment",
                FailureReason = "failure_reason",
                IdempotencyKey = "idempotency_key",
            },
        ];
        Pagination expectedPagination = new()
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = Status.Pending,
                    ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TransactionKind = TransactionKind.Deposit,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = "environment",
                    FailureReason = "failure_reason",
                    IdempotencyKey = "idempotency_key",
                },
            ],
            Pagination = new()
            {
                Page = 1,
                PerPage = 1,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = Status.Pending,
                    ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TransactionKind = TransactionKind.Deposit,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = "environment",
                    FailureReason = "failure_reason",
                    IdempotencyKey = "idempotency_key",
                },
            ],
            Pagination = new()
            {
                Page = 1,
                PerPage = 1,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Status = Status.Pending,
                ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                TransactionKind = TransactionKind.Deposit,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Environment = "environment",
                FailureReason = "failure_reason",
                IdempotencyKey = "idempotency_key",
            },
        ];
        Pagination expectedPagination = new()
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = Status.Pending,
                    ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TransactionKind = TransactionKind.Deposit,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = "environment",
                    FailureReason = "failure_reason",
                    IdempotencyKey = "idempotency_key",
                },
            ],
            Pagination = new()
            {
                Page = 1,
                PerPage = 1,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Amount = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = Status.Pending,
                    ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    TransactionKind = TransactionKind.Deposit,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = "environment",
                    FailureReason = "failure_reason",
                    IdempotencyKey = "idempotency_key",
                },
            ],
            Pagination = new()
            {
                Page = 1,
                PerPage = 1,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        TransactionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
            IdempotencyKey = "idempotency_key",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedFromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TransactionKind> expectedTransactionKind = TransactionKind.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEnvironment = "environment";
        string expectedFailureReason = "failure_reason";
        string expectedIdempotencyKey = "idempotency_key";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFromAccountID, model.FromAccountID);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedToAccountID, model.ToAccountID);
        Assert.Equal(expectedTransactionKind, model.TransactionKind);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
            IdempotencyKey = "idempotency_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
            IdempotencyKey = "idempotency_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        string expectedFromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TransactionKind> expectedTransactionKind = TransactionKind.Deposit;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEnvironment = "environment";
        string expectedFailureReason = "failure_reason";
        string expectedIdempotencyKey = "idempotency_key";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFromAccountID, deserialized.FromAccountID);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedToAccountID, deserialized.ToAccountID);
        Assert.Equal(expectedTransactionKind, deserialized.TransactionKind);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
            IdempotencyKey = "idempotency_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
        };

        Assert.Null(model.IdempotencyKey);
        Assert.False(model.RawData.ContainsKey("idempotency_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
        };

        Assert.Null(model.IdempotencyKey);
        Assert.False(model.RawData.ContainsKey("idempotency_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",
        };

        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failure_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",

            Environment = null,
            FailureReason = null,
        };

        Assert.Null(model.Environment);
        Assert.True(model.RawData.ContainsKey("environment"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failure_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IdempotencyKey = "idempotency_key",

            Environment = null,
            FailureReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            FromAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = Status.Pending,
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TransactionKind = TransactionKind.Deposit,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = "environment",
            FailureReason = "failure_reason",
            IdempotencyKey = "idempotency_key",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Posted)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Posted)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransactionKindTest : TestBase
{
    [Theory]
    [InlineData(TransactionKind.Deposit)]
    [InlineData(TransactionKind.Withdraw)]
    [InlineData(TransactionKind.Transfer)]
    public void Validation_Works(TransactionKind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionKind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionKind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionKind.Deposit)]
    [InlineData(TransactionKind.Withdraw)]
    [InlineData(TransactionKind.Transfer)]
    public void SerializationRoundtrip_Works(TransactionKind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionKind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionKind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionKind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionKind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        long expectedPage = 1;
        long expectedPerPage = 1;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPerPage, model.PerPage);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedTotalPages, model.TotalPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPage = 1;
        long expectedPerPage = 1;
        long expectedTotalCount = 0;
        long expectedTotalPages = 0;

        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPerPage, deserialized.PerPage);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedTotalPages, deserialized.TotalPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
