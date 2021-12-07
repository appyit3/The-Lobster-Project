namespace Lobsterapi.Helpers
{
    public class MongoDBConfig
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string ConnectionString 
        {
            get 
            {
                return $@"mongodb://{Host}:{Port}";
            }
        }
    }
}