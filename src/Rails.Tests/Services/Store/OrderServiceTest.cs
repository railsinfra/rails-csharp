using System.Threading.Tasks;

namespace Rails.Tests.Services.Store;

public class OrderServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var order = await this.client.Store.Order.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        order.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var order = await this.client.Store.Order.Retrieve(
            0,
            new(),
            TestContext.Current.CancellationToken
        );
        order.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Store.Order.Delete(0, new(), TestContext.Current.CancellationToken);
    }
}
