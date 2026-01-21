using System.Threading.Tasks;
using Rails.Models.Accounts;

namespace Rails.Tests.Services;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var account = await this.client.Accounts.Create(
            new()
            {
                AccountType = AccountType.Checking,
                UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var account = await this.client.Accounts.Retrieve(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var accounts = await this.client.Accounts.List(
            new() { UserID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in accounts)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Close_Works()
    {
        var response = await this.client.Accounts.Close(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Deposit_Works()
    {
        var response = await this.client.Accounts.Deposit(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Amount = "amount" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Transfer_Works()
    {
        var response = await this.client.Accounts.Transfer(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Amount = "amount", ToAccountID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateStatus_Works()
    {
        var response = await this.client.Accounts.UpdateStatus(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Withdraw_Works()
    {
        var response = await this.client.Accounts.Withdraw(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { Amount = "amount" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
