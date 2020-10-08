using Microsoft.Data.SqlClient;

namespace BankApi.Infrastructure.DatabaseConnection
{
    public interface IDatabaseConnection
    {
        SqlConnection GetConnection();
    }
}
