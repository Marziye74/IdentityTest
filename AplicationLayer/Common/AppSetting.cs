namespace AplicationLayer.Common
{
    public class AppSetting
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public IdentitySettings IdentitySettings { get; set; }
        public JwtSettings JwtSettings { get; set; }
    }

    public class ConnectionStrings
    {
        public SqlServer SqlServer { get; set; }
    }

    public class SqlServer
    {
        public string Url { get; set; }
    }

    public class IdentitySettings
    {
        public bool PasswordRequireDigit { get; set; }
        public int PasswordRequiredLength { get; set; }
        public bool PasswordRequireNonAlphanumeric { get; set; }
       
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string EncryptKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
