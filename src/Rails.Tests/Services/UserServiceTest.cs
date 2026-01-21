using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var user = await this.client.User.Create(new(), TestContext.Current.CancellationToken);
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var user = await this.client.User.Retrieve(
            "username",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.User.Update("username", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.User.Delete("username", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateWithList_Works()
    {
        var user = await this.client.User.CreateWithList(
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Login_Works()
    {
        await this.client.User.Login(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Logout_Works()
    {
        await this.client.User.Logout(new(), TestContext.Current.CancellationToken);
    }
}
