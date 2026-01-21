using System.Text.Json;
using Rails.Core;
using Rails.Models.User;

namespace Rails.Tests.Models.User;

public class UserUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserUser
        {
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        long expectedID = 10;
        string expectedEmail = "john@email.com";
        string expectedFirstName = "John";
        string expectedLastName = "James";
        string expectedPassword = "12345";
        string expectedPhone = "12345";
        string expectedUsername = "theUser";
        int expectedUserStatus = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedPassword, model.Password);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedUserStatus, model.UserStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserUser
        {
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUser>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserUser
        {
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 10;
        string expectedEmail = "john@email.com";
        string expectedFirstName = "John";
        string expectedLastName = "James";
        string expectedPassword = "12345";
        string expectedPhone = "12345";
        string expectedUsername = "theUser";
        int expectedUserStatus = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedUserStatus, deserialized.UserStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserUser
        {
            ID = 10,
            Email = "john@email.com",
            FirstName = "John",
            LastName = "James",
            Password = "12345",
            Phone = "12345",
            Username = "theUser",
            UserStatus = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserUser { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
        Assert.Null(model.UserStatus);
        Assert.False(model.RawData.ContainsKey("userStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserUser { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserUser
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Email = null,
            FirstName = null,
            LastName = null,
            Password = null,
            Phone = null,
            Username = null,
            UserStatus = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
        Assert.Null(model.UserStatus);
        Assert.False(model.RawData.ContainsKey("userStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserUser
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Email = null,
            FirstName = null,
            LastName = null,
            Password = null,
            Phone = null,
            Username = null,
            UserStatus = null,
        };

        model.Validate();
    }
}
