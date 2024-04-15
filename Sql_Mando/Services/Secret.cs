namespace Sql_Mando.Services
{
    public static class Secret
    {
        private static string _connection = "server=localhost;database=CustomerProductOrderDB;user id=MovieRole;password=Anders120599;TrustServerCertificate=True;";

        public static string Connection { get { return _connection; } }
    }
}
