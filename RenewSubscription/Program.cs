using System.Data;

var cmd = new SqlCommand("RenewSubscription", conn);
cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.AddWithValue("@ClientId", clientId);
cmd.ExecuteNonQuery();
