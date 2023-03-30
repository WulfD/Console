var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getfile", () =>
{
    var data = "";
    using (var sr = new StreamReader("Data/data.csv"))
    {
        // Read the stream as a string, and write the string to the console.
        data += sr.ReadToEnd();
    }
    return data;
})
.WithName("GetFile")
.WithOpenApi();

app.Run();
