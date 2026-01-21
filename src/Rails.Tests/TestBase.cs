using System;
using Rails;

namespace Rails.Tests;

public class TestBase
{
    protected IRailsClient client;

    public TestBase()
    {
        client = new RailsClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
