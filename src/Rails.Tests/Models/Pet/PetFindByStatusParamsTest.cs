using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetFindByStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetFindByStatusParams
        {
            Status = PetFindByStatusParamsStatus.Available,
        };

        ApiEnum<string, PetFindByStatusParamsStatus> expectedStatus =
            PetFindByStatusParamsStatus.Available;

        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PetFindByStatusParams { };

        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetFindByStatusParams
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
        };

        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        PetFindByStatusParams parameters = new() { Status = PetFindByStatusParamsStatus.Available };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://petstore3.swagger.io/api/v3/pet/findByStatus?status=available"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetFindByStatusParams
        {
            Status = PetFindByStatusParamsStatus.Available,
        };

        PetFindByStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PetFindByStatusParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(PetFindByStatusParamsStatus.Available)]
    [InlineData(PetFindByStatusParamsStatus.Pending)]
    [InlineData(PetFindByStatusParamsStatus.Sold)]
    public void Validation_Works(PetFindByStatusParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetFindByStatusParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetFindByStatusParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PetFindByStatusParamsStatus.Available)]
    [InlineData(PetFindByStatusParamsStatus.Pending)]
    [InlineData(PetFindByStatusParamsStatus.Sold)]
    public void SerializationRoundtrip_Works(PetFindByStatusParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetFindByStatusParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetFindByStatusParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetFindByStatusParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetFindByStatusParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
