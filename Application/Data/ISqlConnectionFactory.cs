using System.Data;

namespace Application.Data;

public interface ISqlConnectionFactory
{

    IDbConnection CreateConnection();

}