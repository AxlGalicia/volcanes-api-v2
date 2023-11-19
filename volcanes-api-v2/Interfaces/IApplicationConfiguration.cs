namespace volcanes_api_v2.Interfaces;

public interface IApplicationConfiguration
{
    string AccessKey { get; init; }
    string SecretAccessKey { get; init; }
    string? SessionToken { get; init; }
    string BucketName { get; init; }
    string? Region { get; init; }
    string? ServiceURL { get; init; }
    string? SignatureVersion { get; init; }
}