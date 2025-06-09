string sql = "SELECT * FROM Sessions WHERE TrainerId = @TrainerId AND Date BETWEEN @Start AND @End";
var cmd = new SqlCommand(sql, conn);
