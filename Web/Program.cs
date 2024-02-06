using Web;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CascadeManagementConnectionString");

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));
builder.Services.AddControllers().AddApplicationPart(Api.AssemblyReference.Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Dependencies.MapDependencies(builder.Services, connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();