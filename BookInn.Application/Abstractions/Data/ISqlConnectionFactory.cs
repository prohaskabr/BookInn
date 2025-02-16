using System.Data;

namespace BookInn.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}