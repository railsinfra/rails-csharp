using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;
using System = System;

namespace Rails.Models.AuditEvents;

/// <summary>
/// List audit events
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AuditEventListParams : ParamsBase
{
    public string? Action
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("action");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("action", value);
        }
    }

    /// <summary>
    /// Environment to list audit events from. Defaults to sandbox when omitted.
    /// </summary>
    public ApiEnum<string, Environment>? Environment
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Environment>>("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("environment", value);
        }
    }

    public System::DateTimeOffset? From
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("from", value);
        }
    }

    public ApiEnum<string, Outcome>? Outcome
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Outcome>>("outcome");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("outcome", value);
        }
    }

    public long? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    public long? PerPage
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("per_page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("per_page", value);
        }
    }

    public string? TargetID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("target_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_id", value);
        }
    }

    public string? TargetType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("target_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("target_type", value);
        }
    }

    public System::DateTimeOffset? To
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("to", value);
        }
    }

    public AuditEventListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuditEventListParams(AuditEventListParams auditEventListParams)
        : base(auditEventListParams) { }
#pragma warning restore CS8618

    public AuditEventListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEventListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AuditEventListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AuditEventListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/audit/events"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Environment to list audit events from. Defaults to sandbox when omitted.
/// </summary>
[JsonConverter(typeof(EnvironmentConverter))]
public enum Environment
{
    Sandbox,
    Production,
}

sealed class EnvironmentConverter : JsonConverter<Environment>
{
    public override Environment Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sandbox" => Environment.Sandbox,
            "production" => Environment.Production,
            _ => (Environment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Environment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Environment.Sandbox => "sandbox",
                Environment.Production => "production",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OutcomeConverter))]
public enum Outcome
{
    Success,
    ClientError,
    ServerError,
}

sealed class OutcomeConverter : JsonConverter<Outcome>
{
    public override Outcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => Outcome.Success,
            "client_error" => Outcome.ClientError,
            "server_error" => Outcome.ServerError,
            _ => (Outcome)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Outcome value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Outcome.Success => "success",
                Outcome.ClientError => "client_error",
                Outcome.ServerError => "server_error",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
