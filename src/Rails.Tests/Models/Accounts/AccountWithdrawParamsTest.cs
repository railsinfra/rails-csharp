using System;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountWithdrawParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountWithdrawParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            Description = "description",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedDescription = "description";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountWithdrawParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AccountWithdrawParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountWithdrawParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://accounts-service-staging.up.railway.app/api/v1/accounts/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/withdraw"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountWithdrawParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            Description = "description",
        };

        AccountWithdrawParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
