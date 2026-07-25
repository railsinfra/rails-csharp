using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var user = await this.client.Users.Create(
            new()
            {
                Email = "dev@stainless.com",
                FirstName = "first_name",
                LastName = "last_name",
                Password = "password",
            },
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }
}
