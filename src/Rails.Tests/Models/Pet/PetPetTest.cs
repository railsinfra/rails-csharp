using System.Collections.Generic;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetPetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetPetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        PetPetCategory expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, PetPetStatus> expectedStatus = PetPetStatus.Available;
        List<PetPetTag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhotoUrls.Count, model.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], model.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetPetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetPetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        PetPetCategory expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, PetPetStatus> expectedStatus = PetPetStatus.Available;
        List<PetPetTag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhotoUrls.Count, deserialized.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], deserialized.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetPetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PetPet { Name = "doggie", PhotoUrls = ["string"] };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PetPet { Name = "doggie", PhotoUrls = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PetPet
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        model.Validate();
    }
}

public class PetPetCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PetPetCategory { ID = 1, Name = "Dogs" };

        long expectedID = 1;
        string expectedName = "Dogs";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PetPetCategory { ID = 1, Name = "Dogs" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPetCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PetPetCategory { ID = 1, Name = "Dogs" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPetCategory>(
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
        var model = new PetPetCategory { ID = 1, Name = "Dogs" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PetPetCategory { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PetPetCategory { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PetPetCategory
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
        var model = new PetPetCategory
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }
}

public class PetPetStatusTest : TestBase
{
    [Theory]
    [InlineData(PetPetStatus.Available)]
    [InlineData(PetPetStatus.Pending)]
    [InlineData(PetPetStatus.Sold)]
    public void Validation_Works(PetPetStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetPetStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetPetStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PetPetStatus.Available)]
    [InlineData(PetPetStatus.Pending)]
    [InlineData(PetPetStatus.Sold)]
    public void SerializationRoundtrip_Works(PetPetStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetPetStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetPetStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetPetStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetPetStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PetPetTagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PetPetTag { ID = 0, Name = "name" };

        long expectedID = 0;
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PetPetTag { ID = 0, Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPetTag>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PetPetTag { ID = 0, Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PetPetTag>(
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
        var model = new PetPetTag { ID = 0, Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PetPetTag { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PetPetTag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PetPetTag
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
        var model = new PetPetTag
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }
}
