using System;
using System.Text;
using Rails.Core;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetUploadImageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Body = Encoding.UTF8.GetBytes("text"),
            AdditionalMetadata = "additionalMetadata",
        };

        long expectedPetID = 0;
        BinaryContent expectedBody = Encoding.UTF8.GetBytes("text");
        string expectedAdditionalMetadata = "additionalMetadata";

        Assert.Equal(expectedPetID, parameters.PetID);
        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedAdditionalMetadata, parameters.AdditionalMetadata);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Body = Encoding.UTF8.GetBytes("text"),
        };

        Assert.Null(parameters.AdditionalMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("additionalMetadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Body = Encoding.UTF8.GetBytes("text"),

            // Null should be interpreted as omitted for these properties
            AdditionalMetadata = null,
        };

        Assert.Null(parameters.AdditionalMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("additionalMetadata"));
    }

    [Fact]
    public void Url_Works()
    {
        PetUploadImageParams parameters = new()
        {
            PetID = 0,
            Body = Encoding.UTF8.GetBytes("text"),
            AdditionalMetadata = "additionalMetadata",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://petstore3.swagger.io/api/v3/pet/0/uploadImage?additionalMetadata=additionalMetadata"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Body = Encoding.UTF8.GetBytes("text"),
            AdditionalMetadata = "additionalMetadata",
        };

        PetUploadImageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
