using System.Text;
using System.Threading.Tasks;

namespace Rails.Tests.Services;

public class PetServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var pet = await this.client.Pet.Create(
            new() { Name = "doggie", PhotoUrls = ["string"] },
            TestContext.Current.CancellationToken
        );
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var pet = await this.client.Pet.Retrieve(0, new(), TestContext.Current.CancellationToken);
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var pet = await this.client.Pet.Update(
            new() { Name = "doggie", PhotoUrls = ["string"] },
            TestContext.Current.CancellationToken
        );
        pet.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Pet.Delete(0, new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task FindByStatus_Works()
    {
        var pets = await this.client.Pet.FindByStatus(new(), TestContext.Current.CancellationToken);
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task FindByTags_Works()
    {
        var pets = await this.client.Pet.FindByTags(new(), TestContext.Current.CancellationToken);
        foreach (var item in pets)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UpdateWithFormData_Works()
    {
        await this.client.Pet.UpdateWithFormData(0, new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UploadImage_Works()
    {
        var response = await this.client.Pet.UploadImage(
            0,
            Encoding.UTF8.GetBytes("text"),
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
