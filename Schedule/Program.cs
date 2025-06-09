var schedule = conn.Query<ScheduleView>("SELECT * FROM vw_Schedule").ToList();
