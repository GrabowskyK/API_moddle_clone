using DotEnv.Core;

class AppSettings
{
    [EnvKey("DB_CONNECTION_STRING")]
    public string? ConnectionString { get; set; }

    [EnvKey("JWT_SECRET")]
    public string? SecretKey { get; set; }
}
