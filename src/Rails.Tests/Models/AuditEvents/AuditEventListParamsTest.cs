using System;
using System.Net.Http;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using AuditEvents = Rails.Models.AuditEvents;

namespace Rails.Tests.Models.AuditEvents;

public class AuditEventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AuditEvents::AuditEventListParams
        {
            Action = "action",
            Environment = AuditEvents::Environment.Sandbox,
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outcome = AuditEvents::Outcome.Success,
            Page = 1,
            PerPage = 1,
            TargetID = "target_id",
            TargetType = "target_type",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XEnvironment = AuditEvents::XEnvironment.Sandbox,
        };

        string expectedAction = "action";
        ApiEnum<string, AuditEvents::Environment> expectedEnvironment =
            AuditEvents::Environment.Sandbox;
        DateTimeOffset expectedFrom = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AuditEvents::Outcome> expectedOutcome = AuditEvents::Outcome.Success;
        long expectedPage = 1;
        long expectedPerPage = 1;
        string expectedTargetID = "target_id";
        string expectedTargetType = "target_type";
        DateTimeOffset expectedTo = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, AuditEvents::XEnvironment> expectedXEnvironment =
            AuditEvents::XEnvironment.Sandbox;

        Assert.Equal(expectedAction, parameters.Action);
        Assert.Equal(expectedEnvironment, parameters.Environment);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedOutcome, parameters.Outcome);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPerPage, parameters.PerPage);
        Assert.Equal(expectedTargetID, parameters.TargetID);
        Assert.Equal(expectedTargetType, parameters.TargetType);
        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedXEnvironment, parameters.XEnvironment);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AuditEvents::AuditEventListParams { };

        Assert.Null(parameters.Action);
        Assert.False(parameters.RawQueryData.ContainsKey("action"));
        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawQueryData.ContainsKey("environment"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Outcome);
        Assert.False(parameters.RawQueryData.ContainsKey("outcome"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PerPage);
        Assert.False(parameters.RawQueryData.ContainsKey("per_page"));
        Assert.Null(parameters.TargetID);
        Assert.False(parameters.RawQueryData.ContainsKey("target_id"));
        Assert.Null(parameters.TargetType);
        Assert.False(parameters.RawQueryData.ContainsKey("target_type"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AuditEvents::AuditEventListParams
        {
            // Null should be interpreted as omitted for these properties
            Action = null,
            Environment = null,
            From = null,
            Outcome = null,
            Page = null,
            PerPage = null,
            TargetID = null,
            TargetType = null,
            To = null,
            XEnvironment = null,
        };

        Assert.Null(parameters.Action);
        Assert.False(parameters.RawQueryData.ContainsKey("action"));
        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawQueryData.ContainsKey("environment"));
        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.Outcome);
        Assert.False(parameters.RawQueryData.ContainsKey("outcome"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.PerPage);
        Assert.False(parameters.RawQueryData.ContainsKey("per_page"));
        Assert.Null(parameters.TargetID);
        Assert.False(parameters.RawQueryData.ContainsKey("target_id"));
        Assert.Null(parameters.TargetType);
        Assert.False(parameters.RawQueryData.ContainsKey("target_type"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
        Assert.Null(parameters.XEnvironment);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Environment"));
    }

    [Fact]
    public void Url_Works()
    {
        AuditEvents::AuditEventListParams parameters = new()
        {
            Action = "action",
            Environment = AuditEvents::Environment.Sandbox,
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Outcome = AuditEvents::Outcome.Success,
            Page = 1,
            PerPage = 1,
            TargetID = "target_id",
            TargetType = "target_type",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://www.api.railsinfra.com/api/v1/audit/events?action=action&environment=sandbox&from=2019-12-27T18%3a11%3a19.117%2b00%3a00&outcome=success&page=1&per_page=1&target_id=target_id&target_type=target_type&to=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AuditEvents::AuditEventListParams parameters = new()
        {
            XEnvironment = AuditEvents::XEnvironment.Sandbox,
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sandbox"], requestMessage.Headers.GetValues("X-Environment"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AuditEvents::AuditEventListParams
        {
            Action = "action",
            Environment = AuditEvents::Environment.Sandbox,
            From = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outcome = AuditEvents::Outcome.Success,
            Page = 1,
            PerPage = 1,
            TargetID = "target_id",
            TargetType = "target_type",
            To = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            XEnvironment = AuditEvents::XEnvironment.Sandbox,
        };

        AuditEvents::AuditEventListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::Environment.Sandbox)]
    [InlineData(AuditEvents::Environment.Production)]
    public void Validation_Works(AuditEvents::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Environment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::Environment.Sandbox)]
    [InlineData(AuditEvents::Environment.Production)]
    public void SerializationRoundtrip_Works(AuditEvents::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Environment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OutcomeTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::Outcome.Success)]
    [InlineData(AuditEvents::Outcome.ClientError)]
    [InlineData(AuditEvents::Outcome.ServerError)]
    public void Validation_Works(AuditEvents::Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Outcome> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::Outcome.Success)]
    [InlineData(AuditEvents::Outcome.ClientError)]
    [InlineData(AuditEvents::Outcome.ServerError)]
    public void SerializationRoundtrip_Works(AuditEvents::Outcome rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::Outcome> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Outcome>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::Outcome>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class XEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(AuditEvents::XEnvironment.Sandbox)]
    [InlineData(AuditEvents::XEnvironment.Production)]
    public void Validation_Works(AuditEvents::XEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::XEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::XEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuditEvents::XEnvironment.Sandbox)]
    [InlineData(AuditEvents::XEnvironment.Production)]
    public void SerializationRoundtrip_Works(AuditEvents::XEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuditEvents::XEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::XEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::XEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuditEvents::XEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
