var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure 'Yarp' as reverse proxy
builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("Yarp"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Enable mapping by reverse proxy which configured in service container
app.MapReverseProxy();

app.Run();

