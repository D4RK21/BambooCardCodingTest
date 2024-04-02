using Infrastructure;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRefitClient<IApiProvider>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["BaseApiUrl"]));

// ToDo: Move in the separate file



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
