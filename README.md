# Rails C# API Library

The Rails C# SDK provides convenient access to the Rails REST API from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

## Installation

```bash
git clone git@github.com:stainless-sdks/rails-csharp.git
dotnet add reference rails-csharp/src/Rails
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Rails;
using Rails.Models.Users;

RailsClient client = new();

UserCreateParams parameters = new()
{
    Email = "dev@stainless.com",
    FirstName = "first_name",
    LastName = "last_name",
    Password = "password",
    XEnvironment = XEnvironment.Sandbox,
};

var user = await client.Users.Create(parameters);

Console.WriteLine(user);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Rails;

// Configured using the RAILS_API_KEY and RAILS_BASE_URL environment variables
RailsClient client = new();
```

Or manually:

```csharp
using Rails;

RailsClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable | Required | Default value             |
| --------- | -------------------- | -------- | ------------------------- |
| `ApiKey`  | `RAILS_API_KEY`      | true     | -                         |
| `BaseUrl` | `RAILS_BASE_URL`     | true     | `"https://api.rails.com"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var user = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Users.Create(parameters);

Console.WriteLine(user);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Rails API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Users.Create` should be called with an instance of `UserCreateParams`, and it will return an instance of `Task<UserCreateResponse>`.

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Users.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Rails.Models.Users;

var response = await client.WithRawResponse.Users.Create(parameters);
UserCreateResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `RailsApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                            |
| ------ | ------------------------------------ |
| 400    | `RailsBadRequestException`           |
| 401    | `RailsUnauthorizedException`         |
| 403    | `RailsForbiddenException`            |
| 404    | `RailsNotFoundException`             |
| 422    | `RailsUnprocessableEntityException`  |
| 429    | `RailsRateLimitException`            |
| 5xx    | `Rails5xxException`                  |
| others | `RailsUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Rails4xxException`.

false

- `RailsIOException`: I/O networking errors.

- `RailsInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `RailsException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Rails;

RailsClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var user = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Users.Create(parameters);

Console.WriteLine(user);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Rails;

RailsClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var user = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Users.Create(parameters);

Console.WriteLine(user);
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `RailsInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var user = client.Users.Create(parameters);
user.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Rails;

RailsClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var user = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Users.Create(parameters);

Console.WriteLine(user);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/rails-csharp/issues) with questions, bugs, or suggestions.
