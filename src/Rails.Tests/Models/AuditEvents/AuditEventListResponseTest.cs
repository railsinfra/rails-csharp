using System;
using System.Collections.Generic;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using AuditEvents = Rails.Models.AuditEvents;

namespace Rails.Tests.Models.AuditEvents;

public class AuditEventListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::AuditEventListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Action = AuditEvents::Action.UsersBusinessRegister,
                    Actor = new()
                    {
                        ID = "id",
                        Type = AuditEvents::Type.User,
                        Roles = ["string"],
                    },
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = AuditEvents::DataEnvironment.Sandbox,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Outcome = AuditEvents::DataOutcome.Success,
                    Request = new()
                    {
                        ID = "id",
                        Method = "method",
                        Path = "path",
                        IP = "ip",
                        UserAgent = "user_agent",
                    },
                    SchemaVersion = AuditEvents::SchemaVersion.V1,
                    SourceService = AuditEvents::SourceService.Users,
                    Target = new() { ID = "id", Type = "type" },
                    Reason = "reason",
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

        List<AuditEvents::Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Action = AuditEvents::Action.UsersBusinessRegister,
                Actor = new()
                {
                    ID = "id",
                    Type = AuditEvents::Type.User,
                    Roles = ["string"],
                },
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Environment = AuditEvents::DataEnvironment.Sandbox,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Outcome = AuditEvents::DataOutcome.Success,
                Request = new()
                {
                    ID = "id",
                    Method = "method",
                    Path = "path",
                    IP = "ip",
                    UserAgent = "user_agent",
                },
                SchemaVersion = AuditEvents::SchemaVersion.V1,
                SourceService = AuditEvents::SourceService.Users,
                Target = new() { ID = "id", Type = "type" },
                Reason = "reason",
            },
        ];
        AuditEvents::Pagination expectedPagination = new()
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
        var model = new AuditEvents::AuditEventListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Action = AuditEvents::Action.UsersBusinessRegister,
                    Actor = new()
                    {
                        ID = "id",
                        Type = AuditEvents::Type.User,
                        Roles = ["string"],
                    },
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = AuditEvents::DataEnvironment.Sandbox,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Outcome = AuditEvents::DataOutcome.Success,
                    Request = new()
                    {
                        ID = "id",
                        Method = "method",
                        Path = "path",
                        IP = "ip",
                        UserAgent = "user_agent",
                    },
                    SchemaVersion = AuditEvents::SchemaVersion.V1,
                    SourceService = AuditEvents::SourceService.Users,
                    Target = new() { ID = "id", Type = "type" },
                    Reason = "reason",
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
        var deserialized = JsonSerializer.Deserialize<AuditEvents::AuditEventListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::AuditEventListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Action = AuditEvents::Action.UsersBusinessRegister,
                    Actor = new()
                    {
                        ID = "id",
                        Type = AuditEvents::Type.User,
                        Roles = ["string"],
                    },
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = AuditEvents::DataEnvironment.Sandbox,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Outcome = AuditEvents::DataOutcome.Success,
                    Request = new()
                    {
                        ID = "id",
                        Method = "method",
                        Path = "path",
                        IP = "ip",
                        UserAgent = "user_agent",
                    },
                    SchemaVersion = AuditEvents::SchemaVersion.V1,
                    SourceService = AuditEvents::SourceService.Users,
                    Target = new() { ID = "id", Type = "type" },
                    Reason = "reason",
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
        var deserialized = JsonSerializer.Deserialize<AuditEvents::AuditEventListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AuditEvents::Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Action = AuditEvents::Action.UsersBusinessRegister,
                Actor = new()
                {
                    ID = "id",
                    Type = AuditEvents::Type.User,
                    Roles = ["string"],
                },
                CorrelationID = "correlation_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Environment = AuditEvents::DataEnvironment.Sandbox,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Outcome = AuditEvents::DataOutcome.Success,
                Request = new()
                {
                    ID = "id",
                    Method = "method",
                    Path = "path",
                    IP = "ip",
                    UserAgent = "user_agent",
                },
                SchemaVersion = AuditEvents::SchemaVersion.V1,
                SourceService = AuditEvents::SourceService.Users,
                Target = new() { ID = "id", Type = "type" },
                Reason = "reason",
            },
        ];
        AuditEvents::Pagination expectedPagination = new()
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
        var model = new AuditEvents::AuditEventListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Action = AuditEvents::Action.UsersBusinessRegister,
                    Actor = new()
                    {
                        ID = "id",
                        Type = AuditEvents::Type.User,
                        Roles = ["string"],
                    },
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = AuditEvents::DataEnvironment.Sandbox,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Outcome = AuditEvents::DataOutcome.Success,
                    Request = new()
                    {
                        ID = "id",
                        Method = "method",
                        Path = "path",
                        IP = "ip",
                        UserAgent = "user_agent",
                    },
                    SchemaVersion = AuditEvents::SchemaVersion.V1,
                    SourceService = AuditEvents::SourceService.Users,
                    Target = new() { ID = "id", Type = "type" },
                    Reason = "reason",
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
        var model = new AuditEvents::AuditEventListResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Action = AuditEvents::Action.UsersBusinessRegister,
                    Actor = new()
                    {
                        ID = "id",
                        Type = AuditEvents::Type.User,
                        Roles = ["string"],
                    },
                    CorrelationID = "correlation_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Environment = AuditEvents::DataEnvironment.Sandbox,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Outcome = AuditEvents::DataOutcome.Success,
                    Request = new()
                    {
                        ID = "id",
                        Method = "method",
                        Path = "path",
                        IP = "ip",
                        UserAgent = "user_agent",
                    },
                    SchemaVersion = AuditEvents::SchemaVersion.V1,
                    SourceService = AuditEvents::SourceService.Users,
                    Target = new() { ID = "id", Type = "type" },
                    Reason = "reason",
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

        AuditEvents::AuditEventListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
            Reason = "reason",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AuditEvents::Action> expectedAction =
            AuditEvents::Action.UsersBusinessRegister;
        AuditEvents::Actor expectedActor = new()
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };
        string expectedCorrelationID = "correlation_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AuditEvents::DataEnvironment> expectedEnvironment =
            AuditEvents::DataEnvironment.Sandbox;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AuditEvents::DataOutcome> expectedOutcome =
            AuditEvents::DataOutcome.Success;
        AuditEvents::Request expectedRequest = new()
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };
        ApiEnum<long, AuditEvents::SchemaVersion> expectedSchemaVersion =
            AuditEvents::SchemaVersion.V1;
        ApiEnum<string, AuditEvents::SourceService> expectedSourceService =
            AuditEvents::SourceService.Users;
        AuditEvents::Target expectedTarget = new() { ID = "id", Type = "type" };
        string expectedReason = "reason";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedCorrelationID, model.CorrelationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedOccurredAt, model.OccurredAt);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.Equal(expectedOutcome, model.Outcome);
        Assert.Equal(expectedRequest, model.Request);
        Assert.Equal(expectedSchemaVersion, model.SchemaVersion);
        Assert.Equal(expectedSourceService, model.SourceService);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
            Reason = "reason",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AuditEvents::Action> expectedAction =
            AuditEvents::Action.UsersBusinessRegister;
        AuditEvents::Actor expectedActor = new()
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };
        string expectedCorrelationID = "correlation_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AuditEvents::DataEnvironment> expectedEnvironment =
            AuditEvents::DataEnvironment.Sandbox;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedOccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AuditEvents::DataOutcome> expectedOutcome =
            AuditEvents::DataOutcome.Success;
        AuditEvents::Request expectedRequest = new()
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };
        ApiEnum<long, AuditEvents::SchemaVersion> expectedSchemaVersion =
            AuditEvents::SchemaVersion.V1;
        ApiEnum<string, AuditEvents::SourceService> expectedSourceService =
            AuditEvents::SourceService.Users;
        AuditEvents::Target expectedTarget = new() { ID = "id", Type = "type" };
        string expectedReason = "reason";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedCorrelationID, deserialized.CorrelationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedOccurredAt, deserialized.OccurredAt);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.Equal(expectedOutcome, deserialized.Outcome);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.Equal(expectedSchemaVersion, deserialized.SchemaVersion);
        Assert.Equal(expectedSourceService, deserialized.SourceService);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },

            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },

            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuditEvents::Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Action = AuditEvents::Action.UsersBusinessRegister,
            Actor = new()
            {
                ID = "id",
                Type = AuditEvents::Type.User,
                Roles = ["string"],
            },
            CorrelationID = "correlation_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Environment = AuditEvents::DataEnvironment.Sandbox,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            OccurredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Outcome = AuditEvents::DataOutcome.Success,
            Request = new()
            {
                ID = "id",
                Method = "method",
                Path = "path",
                IP = "ip",
                UserAgent = "user_agent",
            },
            SchemaVersion = AuditEvents::SchemaVersion.V1,
            SourceService = AuditEvents::SourceService.Users,
            Target = new() { ID = "id", Type = "type" },
            Reason = "reason",
        };

        AuditEvents::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::Action.UsersBusinessRegister)]
    [InlineData(AuditEvents::Action.UsersAuthLogin)]
    [InlineData(AuditEvents::Action.UsersAuthRefresh)]
    [InlineData(AuditEvents::Action.UsersAuthRevoke)]
    [InlineData(AuditEvents::Action.UsersPasswordResetRequest)]
    [InlineData(AuditEvents::Action.UsersPasswordResetComplete)]
    [InlineData(AuditEvents::Action.UsersBetaApply)]
    [InlineData(AuditEvents::Action.UsersApiKeyCreate)]
    [InlineData(AuditEvents::Action.UsersApiKeyRevoke)]
    [InlineData(AuditEvents::Action.AccountsAccountCreate)]
    [InlineData(AuditEvents::Action.AccountsAccountUpdateStatus)]
    [InlineData(AuditEvents::Action.AccountsAccountClose)]
    [InlineData(AuditEvents::Action.AccountsMoneyDeposit)]
    [InlineData(AuditEvents::Action.AccountsMoneyWithdraw)]
    [InlineData(AuditEvents::Action.AccountsMoneyTransfer)]
    [InlineData(AuditEvents::Action.LedgerTransactionPost)]
    public void Validation_Works(AuditEvents::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::Action.UsersBusinessRegister)]
    [InlineData(AuditEvents::Action.UsersAuthLogin)]
    [InlineData(AuditEvents::Action.UsersAuthRefresh)]
    [InlineData(AuditEvents::Action.UsersAuthRevoke)]
    [InlineData(AuditEvents::Action.UsersPasswordResetRequest)]
    [InlineData(AuditEvents::Action.UsersPasswordResetComplete)]
    [InlineData(AuditEvents::Action.UsersBetaApply)]
    [InlineData(AuditEvents::Action.UsersApiKeyCreate)]
    [InlineData(AuditEvents::Action.UsersApiKeyRevoke)]
    [InlineData(AuditEvents::Action.AccountsAccountCreate)]
    [InlineData(AuditEvents::Action.AccountsAccountUpdateStatus)]
    [InlineData(AuditEvents::Action.AccountsAccountClose)]
    [InlineData(AuditEvents::Action.AccountsMoneyDeposit)]
    [InlineData(AuditEvents::Action.AccountsMoneyWithdraw)]
    [InlineData(AuditEvents::Action.AccountsMoneyTransfer)]
    [InlineData(AuditEvents::Action.LedgerTransactionPost)]
    public void SerializationRoundtrip_Works(AuditEvents::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };

        string expectedID = "id";
        ApiEnum<string, AuditEvents::Type> expectedType = AuditEvents::Type.User;
        List<string> expectedRoles = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Roles);
        Assert.Equal(expectedRoles.Count, model.Roles.Count);
        for (int i = 0; i < expectedRoles.Count; i++)
        {
            Assert.Equal(expectedRoles[i], model.Roles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Actor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Actor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AuditEvents::Type> expectedType = AuditEvents::Type.User;
        List<string> expectedRoles = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Roles);
        Assert.Equal(expectedRoles.Count, deserialized.Roles.Count);
        for (int i = 0; i < expectedRoles.Count; i++)
        {
            Assert.Equal(expectedRoles[i], deserialized.Roles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuditEvents::Actor { ID = "id", Type = AuditEvents::Type.User };

        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuditEvents::Actor { ID = "id", Type = AuditEvents::Type.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,

            // Null should be interpreted as omitted for these properties
            Roles = null,
        };

        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,

            // Null should be interpreted as omitted for these properties
            Roles = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuditEvents::Actor
        {
            ID = "id",
            Type = AuditEvents::Type.User,
            Roles = ["string"],
        };

        AuditEvents::Actor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::Type.User)]
    [InlineData(AuditEvents::Type.ApiKey)]
    [InlineData(AuditEvents::Type.InternalService)]
    [InlineData(AuditEvents::Type.Anonymous)]
    public void Validation_Works(AuditEvents::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::Type.User)]
    [InlineData(AuditEvents::Type.ApiKey)]
    [InlineData(AuditEvents::Type.InternalService)]
    [InlineData(AuditEvents::Type.Anonymous)]
    public void SerializationRoundtrip_Works(AuditEvents::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::DataEnvironment.Sandbox)]
    [InlineData(AuditEvents::DataEnvironment.Production)]
    public void Validation_Works(AuditEvents::DataEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::DataEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::DataEnvironment.Sandbox)]
    [InlineData(AuditEvents::DataEnvironment.Production)]
    public void SerializationRoundtrip_Works(AuditEvents::DataEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::DataEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AuditEvents::DataEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AuditEvents::DataEnvironment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataOutcomeTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::DataOutcome.Success)]
    [InlineData(AuditEvents::DataOutcome.ClientError)]
    [InlineData(AuditEvents::DataOutcome.ServerError)]
    public void Validation_Works(AuditEvents::DataOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::DataOutcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::DataOutcome.Success)]
    [InlineData(AuditEvents::DataOutcome.ClientError)]
    [InlineData(AuditEvents::DataOutcome.ServerError)]
    public void SerializationRoundtrip_Works(AuditEvents::DataOutcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::DataOutcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataOutcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::DataOutcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };

        string expectedID = "id";
        string expectedMethod = "method";
        string expectedPath = "path";
        string expectedIP = "ip";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Request>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Request>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMethod = "method";
        string expectedPath = "path";
        string expectedIP = "ip";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
        };

        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            IP = null,
            UserAgent = null,
        };

        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.UserAgent);
        Assert.False(model.RawData.ContainsKey("user_agent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",

            // Null should be interpreted as omitted for these properties
            IP = null,
            UserAgent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuditEvents::Request
        {
            ID = "id",
            Method = "method",
            Path = "path",
            IP = "ip",
            UserAgent = "user_agent",
        };

        AuditEvents::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SchemaVersionTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::SchemaVersion.V1)]
    public void Validation_Works(AuditEvents::SchemaVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, AuditEvents::SchemaVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, AuditEvents::SchemaVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::SchemaVersion.V1)]
    public void SerializationRoundtrip_Works(AuditEvents::SchemaVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, AuditEvents::SchemaVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, AuditEvents::SchemaVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, AuditEvents::SchemaVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, AuditEvents::SchemaVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceServiceTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::SourceService.Users)]
    [InlineData(AuditEvents::SourceService.Accounts)]
    [InlineData(AuditEvents::SourceService.Ledger)]
    public void Validation_Works(AuditEvents::SourceService rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::SourceService> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::SourceService>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::SourceService.Users)]
    [InlineData(AuditEvents::SourceService.Accounts)]
    [InlineData(AuditEvents::SourceService.Ledger)]
    public void SerializationRoundtrip_Works(AuditEvents::SourceService rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::SourceService> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::SourceService>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::SourceService>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::SourceService>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::Target { ID = "id", Type = "type" };

        string expectedID = "id";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuditEvents::Target { ID = "id", Type = "type" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::Target { ID = "id", Type = "type" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuditEvents::Target { ID = "id", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuditEvents::Target { ID = "id", Type = "type" };

        AuditEvents::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvents::Pagination
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
        var model = new AuditEvents::Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvents::Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvents::Pagination>(
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
        var model = new AuditEvents::Pagination
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
        var model = new AuditEvents::Pagination
        {
            Page = 1,
            PerPage = 1,
            TotalCount = 0,
            TotalPages = 0,
        };

        AuditEvents::Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
