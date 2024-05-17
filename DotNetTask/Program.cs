using DotNetTask.Services.Implementaion;
using DotNetTask.Services.Interface;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton((provider) =>
{
    var endpointUri = builder.Configuration.GetSection("AzureCosmosDBSettings")
    .GetValue<string>("EndpointUri");

    var primaryKey = builder.Configuration.GetSection("AzureCosmosDBSettings")
    .GetValue<string>("PrimaryKey");

    var databaseName = builder.Configuration.GetSection("AzureCosmosDBSettings")
    .GetValue<string>("DatabaseName");

    var cosmosClientOption = new CosmosClientOptions
    {
        ApplicationName = databaseName
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOption);

    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;

    return cosmosClient;
});

builder.Services.AddSingleton<IApplicationFormService, ApplicationFormService>();
builder.Services.AddSingleton<IDateQuestionService, DateQuestionService>();
builder.Services.AddSingleton<IDropDownQuestionService, DropDownQuestionService>();
builder.Services.AddSingleton<IMultipleChoiceQuestionService, MultipleChoiceQuestionService>();
builder.Services.AddSingleton<INumberQuestionService, NumberQuestionService>();
builder.Services.AddSingleton<IParagraphQuestionService, ParagraphQuestionService>();
builder.Services.AddSingleton<IYesNoQuestionService, YesNoQuestionService>();
builder.Services.AddSingleton<IApplicationProgramService, ApplicationProgramService>();
builder.Services.AddSingleton<IPersonalInformationService, PersonalInformationService>();


builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();


app.Run();

