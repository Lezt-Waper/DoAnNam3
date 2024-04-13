namespace Repository
{
    public class Config
    {
        public string ConnectionString { get; set; }

        public Config(string connetionString)
        {
            ConnectionString = connetionString;
        }
    }
}
