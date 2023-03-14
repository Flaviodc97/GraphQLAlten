using ProgrammingLanguageGraphQL.Data;
using ProgrammingLanguageGraphQL.Interface;
using ProgrammingLanguageGraphQL.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProgrammingLanguageGraphQL.NewFolder;
using ProgrammingLanguageGraphQL.ViewModels;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
builder.Services.AddScoped<ITypeLanguageRepository, TypeLanguageRepository>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType <Mutation>()
    .AddType<ProgrammingLanguageInput>()
    .AddType<TypeLanguageInput>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddAutoMapper(typeof(ProgrammingLanguageMappingProfile));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ProgrammingLanguageMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<ProgrammingLanguageDbContext>(
  options => options.UseSqlServer(
     builder.Configuration.GetConnectionString("DbConn")
  )
);

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

app.MapGraphQL("/graphql");

app.Run();
