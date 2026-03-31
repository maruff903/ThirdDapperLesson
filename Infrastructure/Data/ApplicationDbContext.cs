using Npgsql;

namespace Infrastructure.Data;

public class ApplicationDbContext
{
    private readonly string connString = @"Host=localhost;
                                           Port=5432; 
                                           Username=postgres;
                                           Database=adonet2; 
                                           Password=maruf500507205;";
    
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connString);
    }
}
