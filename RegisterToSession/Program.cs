using System.Data;

var cmd = new SqlCommand("RegisterToSession", conn);
cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.AddWithValue("@ClientId", clientId);
cmd.Parameters.AddWithValue("@SessionId", sessionId);
try
{
    cmd.ExecuteNonQuery();
}
catch (SqlException ex)
{
    if (ex.Message.Contains("Inactive subscription"))
    {
    }
}
