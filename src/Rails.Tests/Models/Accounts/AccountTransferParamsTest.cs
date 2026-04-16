using System;
using Rails.Models.Accounts;

namespace Rails.Tests.Models.Accounts;

public class AccountTransferParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAmount = "amount";
        string expectedToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedToAccountID, parameters.ToAccountID);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountTransferParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://accounts-service-staging.up.railway.app/api/v1/accounts/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/transfer"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountTransferParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Amount = "amount",
            ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
        };

        AccountTransferParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
