using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class TransactionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var transaction = await this.client.Transactions.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        transaction.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var transactions = await this.client.Transactions.List(
            new() { OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        transactions.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListByAccount_Works()
    {
        var transactions = await this.client.Transactions.ListByAccount(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in transactions)
        {
            item.Validate();
        }
    }
}
