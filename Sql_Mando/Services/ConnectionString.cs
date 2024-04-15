namespace Sql_Mando.Services
{
    public class ConnectionString
    {
        protected string _connection;


        public IConfiguration Configuration { get; }

        public ConnectionString(IConfiguration configuration)
        {
            _connection = Secret.Connection;
            Configuration = configuration;
        }

        public ConnectionString(string connection)
        {
            _connection = connection;
        }



    }
}
