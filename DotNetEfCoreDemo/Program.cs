using DotNetEfCoreDemo.DedpendencyInjection;
using DotNetEfCoreDemo.Services.HangfireJobs;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDIModule(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard();
    
}
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseHttpsRedirection();


app.Services.GetRequiredService<IBackgroundJobClient>().Enqueue<DisplayOrdersCountJob>((job) => job.Start());

app.Services.GetRequiredService<IRecurringJobManager>().AddOrUpdate<AddNewOrderJob>("AddNewOrderJob", (job) => job.Start(), Cron.Minutely);

app.Services.GetRequiredService<IRecurringJobManager>().AddOrUpdate<DisplayOrdersCountJob>("DisplayOrdersCountJob", (job) => job.Start(), Cron.Minutely);

app.Run();