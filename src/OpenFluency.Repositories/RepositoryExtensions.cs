using MySql.Data.MySqlClient;

namespace OpenFluency.Repositories
{
    public static class RepositoryExtensions
    {

        public static decimal? GetDecimalOrNull(this MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value ? null : (decimal?)reader[columnName];    
        }

        public static int? GetInt32OrNull(this MySqlDataReader reader, string name)
        {
            return reader[name] == DBNull.Value ? null : (int)reader[name];
        }
    }
}
