using System.Data;
using Microsoft.Data.SqlClient;

namespace BankApi.Infrastructure.DatabaseConnection
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}
