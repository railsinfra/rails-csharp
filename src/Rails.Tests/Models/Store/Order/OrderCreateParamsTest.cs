using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Store.Order;

namespace Rails.Tests.Models.Store.Order;

public class OrderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OrderCreateParams
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Approved,
        };

        long expectedID = 10;
        bool expectedComplete = true;
        long expectedPetID = 198772;
        int expectedQuantity = 7;
        DateTimeOffset expectedShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Approved;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedComplete, parameters.Complete);
        Assert.Equal(expectedPetID, parameters.PetID);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedShipDate, parameters.ShipDate);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new OrderCreateParams { };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Complete);
        Assert.False(parameters.RawBodyData.ContainsKey("complete"));
        Assert.Null(parameters.PetID);
        Assert.False(parameters.RawBodyData.ContainsKey("petId"));
        Assert.Null(parameters.Quantity);
        Assert.False(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.ShipDate);
        Assert.False(parameters.RawBodyData.ContainsKey("shipDate"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new OrderCreateParams
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Complete = null,
            PetID = null,
            Quantity = null,
            ShipDate = null,
            Status = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Complete);
        Assert.False(parameters.RawBodyData.ContainsKey("complete"));
        Assert.Null(parameters.PetID);
        Assert.False(parameters.RawBodyData.ContainsKey("petId"));
        Assert.Null(parameters.Quantity);
        Assert.False(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.ShipDate);
        Assert.False(parameters.RawBodyData.ContainsKey("shipDate"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        OrderCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://petstore3.swagger.io/api/v3/store/order"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OrderCreateParams
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Approved,
        };

        OrderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Placed)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Delivered)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Placed)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Delivered)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
