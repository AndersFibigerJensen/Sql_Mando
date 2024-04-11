namespace Sql_Mando
{
    public class ConnectionString
    {
        private string _connection= "server=localhost;database=IMDB;User ID=imdbuser;password=superSecret;TrustServerCertificate=True)";


        public IConfiguration Configuration { get; }

        public ConnectionString(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string Connection { get { return _connection; } }


    }
}
