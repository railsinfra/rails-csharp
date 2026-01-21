using System;
using Rails.Models.Store.Order;

namespace Rails.Tests.Models.Store.Order;

public class OrderDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OrderDeleteParams { OrderID = 0 };

        long expectedOrderID = 0;

        Assert.Equal(expectedOrderID, parameters.OrderID);
    }

    [Fact]
    public void Url_Works()
    {
        OrderDeleteParams parameters = new() { OrderID = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/store/order/0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OrderDeleteParams { OrderID = 0 };

        OrderDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
