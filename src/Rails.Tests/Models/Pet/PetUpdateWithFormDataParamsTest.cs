using System;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetUpdateWithFormDataParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetUpdateWithFormDataParams
        {
            PetID = 0,
            Name = "name",
            Status = "status",
        };

        long expectedPetID = 0;
        string expectedName = "name";
        string expectedStatus = "status";

        Assert.Equal(expectedPetID, parameters.PetID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PetUpdateWithFormDataParams { PetID = 0 };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetUpdateWithFormDataParams
        {
            PetID = 0,

            // Null should be interpreted as omitted for these properties
            Name = null,
            Status = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        PetUpdateWithFormDataParams parameters = new()
        {
            PetID = 0,
            Name = "name",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://petstore3.swagger.io/api/v3/pet/0?name=name&status=status"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetUpdateWithFormDataParams
        {
            PetID = 0,
            Name = "name",
            Status = "status",
        };

        PetUpdateWithFormDataParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
