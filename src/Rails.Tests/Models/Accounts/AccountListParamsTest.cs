using System;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountListParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string expectedUserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountListParams parameters = new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.railsinfra.com/api/v1/accounts?user_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountListParams { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        AccountListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
