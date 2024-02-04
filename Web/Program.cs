using Web;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CascadeManagementConnectionString");

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssemblies(
        [
            Domain.AssemblyReference.Assembly,
            Application.AssemblyReference.Assembly
        ]
    ));
builder.Services.AddControllers().AddApplicationPart(Api.AssemblyReference.Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DomainDependencies.MapDependencies(builder.Services);
ApplicationDependencies.MapDependencies(builder.Services);
InfrastructureDependencies.MapDependencies(builder.Services, connectionString);
ApiDependencies.MapDependencies(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();