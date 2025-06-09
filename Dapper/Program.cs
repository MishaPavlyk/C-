using System.Data;
using System.Security.Cryptography;

var clients = conn.Query<Client>("SELECT * FROM Clients WHERE SubscriptionStatus = 'Active'").ToList();

conn.Execute("RegisterToSession", new { ClientId = id, SessionId = sid }, commandType: CommandType.StoredProcedure);

using (var tran = conn.BeginTransaction())
{
    conn.Execute("RenewSubscription", new { ClientId = id }, transaction: tran, commandType: CommandType.StoredProcedure);
    conn.Execute("RegisterToSession", new { ClientId = id, SessionId = sid }, transaction: tran, commandType: CommandType.StoredProcedure);
    tran.Commit();
}
