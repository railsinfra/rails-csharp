using System;
using System.Text.Json;
using Rails.Core;
using Rails.Exceptions;
using Rails.Models.Store.Order;

namespace Rails.Tests.Models.Store.Order;

public class OrderOrderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrderOrder
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = OrderOrderStatus.Approved,
        };

        long expectedID = 10;
        bool expectedComplete = true;
        long expectedPetID = 198772;
        int expectedQuantity = 7;
        DateTimeOffset expectedShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OrderOrderStatus> expectedStatus = OrderOrderStatus.Approved;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComplete, model.Complete);
        Assert.Equal(expectedPetID, model.PetID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedShipDate, model.ShipDate);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrderOrder
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = OrderOrderStatus.Approved,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrderOrder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrderOrder
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = OrderOrderStatus.Approved,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrderOrder>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 10;
        bool expectedComplete = true;
        long expectedPetID = 198772;
        int expectedQuantity = 7;
        DateTimeOffset expectedShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, OrderOrderStatus> expectedStatus = OrderOrderStatus.Approved;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComplete, deserialized.Complete);
        Assert.Equal(expectedPetID, deserialized.PetID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedShipDate, deserialized.ShipDate);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrderOrder
        {
            ID = 10,
            Complete = true,
            PetID = 198772,
            Quantity = 7,
            ShipDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = OrderOrderStatus.Approved,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OrderOrder { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Complete);
        Assert.False(model.RawData.ContainsKey("complete"));
        Assert.Null(model.PetID);
        Assert.False(model.RawData.ContainsKey("petId"));
        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
        Assert.Null(model.ShipDate);
        Assert.False(model.RawData.ContainsKey("shipDate"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OrderOrder { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OrderOrder
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Complete = null,
            PetID = null,
            Quantity = null,
            ShipDate = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Complete);
        Assert.False(model.RawData.ContainsKey("complete"));
        Assert.Null(model.PetID);
        Assert.False(model.RawData.ContainsKey("petId"));
        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
        Assert.Null(model.ShipDate);
        Assert.False(model.RawData.ContainsKey("shipDate"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OrderOrder
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Complete = null,
            PetID = null,
            Quantity = null,
            ShipDate = null,
            Status = null,
        };

        model.Validate();
    }
}

public class OrderOrderStatusTest : TestBase
{
    [Theory]
    [InlineData(OrderOrderStatus.Placed)]
    [InlineData(OrderOrderStatus.Approved)]
    [InlineData(OrderOrderStatus.Delivered)]
    public void Validation_Works(OrderOrderStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderOrderStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderOrderStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<RailsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrderOrderStatus.Placed)]
    [InlineData(OrderOrderStatus.Approved)]
    [InlineData(OrderOrderStatus.Delivered)]
    public void SerializationRoundtrip_Works(OrderOrderStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderOrderStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderOrderStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderOrderStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderOrderStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
