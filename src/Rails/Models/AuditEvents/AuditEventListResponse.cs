using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rails.Core;
using Rails.Exceptions;
using System = System;

namespace Rails.Models.AuditEvents;

[JsonConverter(typeof(JsonModelConverter<AuditEventListResponse, AuditEventListResponseFromRaw>))]
public sealed record class AuditEventListResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public AuditEventListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuditEventListResponse(AuditEventListResponse auditEventListResponse)
        : base(auditEventListResponse) { }
#pragma warning restore CS8618

    public AuditEventListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEventListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuditEventListResponseFromRaw.FromRawUnchecked"/>
    public static AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditEventListResponseFromRaw : IFromRawJson<AuditEventListResponse>
{
    /// <inheritdoc/>
    public AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuditEventListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public required Actor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Actor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    public required string CorrelationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("correlation_id");
        }
        init { this._rawData.Set("correlation_id", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, DataEnvironment> Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataEnvironment>>("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required System::DateTimeOffset OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("occurred_at");
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public required ApiEnum<string, DataOutcome> Outcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataOutcome>>("outcome");
        }
        init { this._rawData.Set("outcome", value); }
    }

    public required Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Request>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    public required ApiEnum<long, SchemaVersion> SchemaVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<long, SchemaVersion>>("schema_version");
        }
        init { this._rawData.Set("schema_version", value); }
    }

    public required ApiEnum<string, SourceService> SourceService
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceService>>("source_service");
        }
        init { this._rawData.Set("source_service", value); }
    }

    public required Target Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Target>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Action.Validate();
        this.Actor.Validate();
        _ = this.CorrelationID;
        _ = this.CreatedAt;
        this.Environment.Validate();
        _ = this.Metadata;
        _ = this.OccurredAt;
        _ = this.OrganizationID;
        this.Outcome.Validate();
        this.Request.Validate();
        this.SchemaVersion.Validate();
        this.SourceService.Validate();
        this.Target.Validate();
        _ = this.Reason;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    UsersBusinessRegister,
    UsersAuthLogin,
    UsersAuthRefresh,
    UsersAuthRevoke,
    UsersPasswordResetRequest,
    UsersPasswordResetComplete,
    UsersBetaApply,
    UsersApiKeyCreate,
    UsersApiKeyRevoke,
    AccountsAccountCreate,
    AccountsAccountUpdateStatus,
    AccountsAccountClose,
    AccountsMoneyDeposit,
    AccountsMoneyWithdraw,
    AccountsMoneyTransfer,
    LedgerTransactionPost,
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "users.business.register" => Action.UsersBusinessRegister,
            "users.auth.login" => Action.UsersAuthLogin,
            "users.auth.refresh" => Action.UsersAuthRefresh,
            "users.auth.revoke" => Action.UsersAuthRevoke,
            "users.password_reset.request" => Action.UsersPasswordResetRequest,
            "users.password_reset.complete" => Action.UsersPasswordResetComplete,
            "users.beta.apply" => Action.UsersBetaApply,
            "users.api_key.create" => Action.UsersApiKeyCreate,
            "users.api_key.revoke" => Action.UsersApiKeyRevoke,
            "accounts.account.create" => Action.AccountsAccountCreate,
            "accounts.account.update_status" => Action.AccountsAccountUpdateStatus,
            "accounts.account.close" => Action.AccountsAccountClose,
            "accounts.money.deposit" => Action.AccountsMoneyDeposit,
            "accounts.money.withdraw" => Action.AccountsMoneyWithdraw,
            "accounts.money.transfer" => Action.AccountsMoneyTransfer,
            "ledger.transaction.post" => Action.LedgerTransactionPost,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.UsersBusinessRegister => "users.business.register",
                Action.UsersAuthLogin => "users.auth.login",
                Action.UsersAuthRefresh => "users.auth.refresh",
                Action.UsersAuthRevoke => "users.auth.revoke",
                Action.UsersPasswordResetRequest => "users.password_reset.request",
                Action.UsersPasswordResetComplete => "users.password_reset.complete",
                Action.UsersBetaApply => "users.beta.apply",
                Action.UsersApiKeyCreate => "users.api_key.create",
                Action.UsersApiKeyRevoke => "users.api_key.revoke",
                Action.AccountsAccountCreate => "accounts.account.create",
                Action.AccountsAccountUpdateStatus => "accounts.account.update_status",
                Action.AccountsAccountClose => "accounts.account.close",
                Action.AccountsMoneyDeposit => "accounts.money.deposit",
                Action.AccountsMoneyWithdraw => "accounts.money.withdraw",
                Action.AccountsMoneyTransfer => "accounts.money.transfer",
                Action.LedgerTransactionPost => "ledger.transaction.post",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Actor, ActorFromRaw>))]
public sealed record class Actor : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, global::Rails.Models.AuditEvents.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Rails.Models.AuditEvents.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<string>? Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("roles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "roles",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.Roles;
    }

    public Actor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Actor(Actor actor)
        : base(actor) { }
#pragma warning restore CS8618

    public Actor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Actor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActorFromRaw.FromRawUnchecked"/>
    public static Actor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActorFromRaw : IFromRawJson<Actor>
{
    /// <inheritdoc/>
    public Actor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Actor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    User,
    ApiKey,
    InternalService,
    Anonymous,
}

sealed class TypeConverter : JsonConverter<global::Rails.Models.AuditEvents.Type>
{
    public override global::Rails.Models.AuditEvents.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => global::Rails.Models.AuditEvents.Type.User,
            "api_key" => global::Rails.Models.AuditEvents.Type.ApiKey,
            "internal_service" => global::Rails.Models.AuditEvents.Type.InternalService,
            "anonymous" => global::Rails.Models.AuditEvents.Type.Anonymous,
            _ => (global::Rails.Models.AuditEvents.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Rails.Models.AuditEvents.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Rails.Models.AuditEvents.Type.User => "user",
                global::Rails.Models.AuditEvents.Type.ApiKey => "api_key",
                global::Rails.Models.AuditEvents.Type.InternalService => "internal_service",
                global::Rails.Models.AuditEvents.Type.Anonymous => "anonymous",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataEnvironmentConverter))]
public enum DataEnvironment
{
    Sandbox,
    Production,
}

sealed class DataEnvironmentConverter : JsonConverter<DataEnvironment>
{
    public override DataEnvironment Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sandbox" => DataEnvironment.Sandbox,
            "production" => DataEnvironment.Production,
            _ => (DataEnvironment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataEnvironment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataEnvironment.Sandbox => "sandbox",
                DataEnvironment.Production => "production",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataOutcomeConverter))]
public enum DataOutcome
{
    Success,
    ClientError,
    ServerError,
}

sealed class DataOutcomeConverter : JsonConverter<DataOutcome>
{
    public override DataOutcome Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => DataOutcome.Success,
            "client_error" => DataOutcome.ClientError,
            "server_error" => DataOutcome.ServerError,
            _ => (DataOutcome)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataOutcome value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataOutcome.Success => "success",
                DataOutcome.ClientError => "client_error",
                DataOutcome.ServerError => "server_error",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip", value);
        }
    }

    public string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_agent", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Method;
        _ = this.Path;
        _ = this.IP;
        _ = this.UserAgent;
    }

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Request(Request request)
        : base(request) { }
#pragma warning restore CS8618

    public Request(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestFromRaw.FromRawUnchecked"/>
    public static Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestFromRaw : IFromRawJson<Request>
{
    /// <inheritdoc/>
    public Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Request.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SchemaVersionConverter))]
public enum SchemaVersion
{
    V1,
}

sealed class SchemaVersionConverter : JsonConverter<SchemaVersion>
{
    public override SchemaVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            1L => SchemaVersion.V1,
            _ => (SchemaVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SchemaVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SchemaVersion.V1 => 1L,
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SourceServiceConverter))]
public enum SourceService
{
    Users,
    Accounts,
    Ledger,
}

sealed class SourceServiceConverter : JsonConverter<SourceService>
{
    public override SourceService Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "users" => SourceService.Users,
            "accounts" => SourceService.Accounts,
            "ledger" => SourceService.Ledger,
            _ => (SourceService)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceService value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceService.Users => "users",
                SourceService.Accounts => "accounts",
                SourceService.Ledger => "ledger",
                _ => throw new RailsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
    }

    public Target() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Target(Target target)
        : base(target) { }
#pragma warning restore CS8618

    public Target(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Target(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetFromRaw.FromRawUnchecked"/>
    public static Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetFromRaw : IFromRawJson<Target>
{
    /// <inheritdoc/>
    public Target FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Target.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    public required long PerPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("per_page");
        }
        init { this._rawData.Set("per_page", value); }
    }

    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    public required long TotalPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_pages");
        }
        init { this._rawData.Set("total_pages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Page;
        _ = this.PerPage;
        _ = this.TotalCount;
        _ = this.TotalPages;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
