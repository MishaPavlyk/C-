using (var conn = new SqlConnection(connectionString))
{
    conn.Open();
    var cmd = new SqlCommand("SELECT * FROM Clients WHERE SubscriptionStatus = 'Active'", conn);
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
    }
}
