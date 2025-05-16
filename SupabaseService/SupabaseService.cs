using Postgrest;
using Postgrest.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

public class User : BaseModel
{
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; }
}

public class SupabaseService
{
    private readonly Client client;

    public SupabaseService(string url, string key)
    {
        client = new Client(url, key, schema: "public");
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var result = await client.Table<User>().Get();
        return result.Models;
    }
}
