using System;
using Rails.Models.Transactions;

namespace Rails.Tests.Models.Transactions;

public class TransactionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionRetrieveParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        TransactionRetrieveParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.railsinfra.com/api/v1/transactions/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransactionRetrieveParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        TransactionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
