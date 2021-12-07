namespace Lobsterapi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        
        public string ConnectionString { get { return "mongodb://{Host}:{Port}"; } }
    }
}