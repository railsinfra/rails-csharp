using System;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountRetrieveParams { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountRetrieveParams parameters = new() { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://accounts-service-staging.up.railway.app/api/v1/accounts/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountRetrieveParams { ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        AccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
