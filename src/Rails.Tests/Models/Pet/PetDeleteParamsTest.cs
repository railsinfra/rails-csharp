using System;
using Rails.Models.Pet;

namespace Rails.Tests.Models.Pet;

public class PetDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetDeleteParams { PetID = 0 };

        long expectedPetID = 0;

        Assert.Equal(expectedPetID, parameters.PetID);
    }

    [Fact]
    public void Url_Works()
    {
        PetDeleteParams parameters = new() { PetID = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/pet/0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetDeleteParams { PetID = 0 };

        PetDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
