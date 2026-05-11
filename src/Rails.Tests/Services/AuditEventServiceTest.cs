using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class AuditEventServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var auditEvents = await this.client.AuditEvents.List(
            new(),
            TestContext.Current.CancellationToken
        );
        auditEvents.Validate();
    }
}
