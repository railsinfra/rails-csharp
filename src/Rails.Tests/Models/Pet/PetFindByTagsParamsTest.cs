using System;
using System.Collections.Generic;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetFindByTagsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetFindByTagsParams { Tags = ["string"] };

        List<string> expectedTags = ["string"];

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
        var parameters = new PetFindByTagsParams { };

        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetFindByTagsParams
        {
            // Null should be interpreted as omitted for these properties
            Tags = null,
        };

        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        PetFindByTagsParams parameters = new() { Tags = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://petstore3.swagger.io/api/v3/pet/findByTags?tags=string"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetFindByTagsParams { Tags = ["string"] };

        PetFindByTagsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
