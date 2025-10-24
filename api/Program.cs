
namespace AvalphaTechnologies.CommissionCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddScoped<AvalphaTechnologies.CommissionCalculator.BusinessLogic.ICommissionCalculator, AvalphaTechnologies.CommissionCalculator.BusinessLogic.CommissionCalculator>();

            // Add CORS policy for local React dev server
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000", p =>
                {
                    p.WithOrigins("http://localhost:3000")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                });
            });

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

            app.UseCors("AllowLocalhost3000");

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/problem+json";
                    await context.Response.WriteAsJsonAsync(new
                    {
                        title = "An unexpected error occurred.",
                        status = 500
                    });
                });
            });
            app.MapControllers();

            app.Run();
        }
    }
}
