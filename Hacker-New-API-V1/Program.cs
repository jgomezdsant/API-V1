using Hacker_New_API_V1.Services.Contract;
using Hacker_New_API_V1.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IHackerNewsService, HackerNewsService>();

builder.Services.AddHttpClient<IHackerNewsService, HackerNewsService>(client =>
{
    client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
});

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
