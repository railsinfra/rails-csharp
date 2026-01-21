using System;
using System.Collections.Generic;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetUpdateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetUpdateParamsStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        PetUpdateParamsCategory expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, PetUpdateParamsStatus> expectedStatus = PetUpdateParamsStatus.Available;
        List<PetUpdateParamsTag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPhotoUrls.Count, parameters.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], parameters.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PetUpdateParams { Name = "doggie", PhotoUrls = ["string"] };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetUpdateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        PetUpdateParams parameters = new() { Name = "doggie", PhotoUrls = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/pet"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetUpdateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetUpdateParamsStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        PetUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PetUpdateParamsCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PetUpdateParamsCategory { ID = 1, Name = "Dogs" };

        long expectedID = 1;
        string expectedName = "Dogs";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PetUpdateParamsCategory { ID = 1, Name = "Dogs" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetUpdateParamsCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PetUpdateParamsCategory { ID = 1, Name = "Dogs" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetUpdateParamsCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 1;
        string expectedName = "Dogs";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PetUpdateParamsCategory { ID = 1, Name = "Dogs" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PetUpdateParamsCategory { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PetUpdateParamsCategory { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PetUpdateParamsCategory
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PetUpdateParamsCategory
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }
}

public class PetUpdateParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(PetUpdateParamsStatus.Available)]
    [InlineData(PetUpdateParamsStatus.Pending)]
    [InlineData(PetUpdateParamsStatus.Sold)]
    public void Validation_Works(PetUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetUpdateParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetUpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PetUpdateParamsStatus.Available)]
    [InlineData(PetUpdateParamsStatus.Pending)]
    [InlineData(PetUpdateParamsStatus.Sold)]
    public void SerializationRoundtrip_Works(PetUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetUpdateParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetUpdateParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetUpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetUpdateParamsStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PetUpdateParamsTagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PetUpdateParamsTag { ID = 0, Name = "name" };

        long expectedID = 0;
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PetUpdateParamsTag { ID = 0, Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetUpdateParamsTag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PetUpdateParamsTag { ID = 0, Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetUpdateParamsTag>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 0;
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PetUpdateParamsTag { ID = 0, Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PetUpdateParamsTag { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PetUpdateParamsTag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PetUpdateParamsTag
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PetUpdateParamsTag
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }
}
