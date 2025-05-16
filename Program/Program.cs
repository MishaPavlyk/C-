var builder = WebApplication.CreateBuilder(args);

var supabaseUrl = builder.Configuration["https://dchhzmjfknlfimyfemys.supabase.co"];
var supabaseKey = builder.Configuration["eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImRjaGh6bWpma25sZmlteWZlbXlzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc0MjMxODUsImV4cCI6MjA2Mjk5OTE4NX0.2WclkdcdrYX3qnVQRvwbJfo66zN5souJUSnqGjPvMXw"];

builder.Services.AddSingleton(new SupabaseService(supabaseUrl, supabaseKey));
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
