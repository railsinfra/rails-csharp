using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class StoreServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListInventory_Works()
    {
        await this.client.Store.ListInventory(new(), TestContext.Current.CancellationToken);
    }
}
