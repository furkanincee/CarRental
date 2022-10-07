using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICarService,CarManager>(); // T�m bellekte bir tane car manager olu�turur ve ctor i�inde her ICarService �a�r�ld���nda o bellekteki car manageri verir. B�ylece s�rekli yeni yeni �rnekler olu�turmaktan ka��nm�� oluruz.
            builder.Services.AddSingleton<ICarDal, EfCarDal>();
            // Singleton�n mant��� buydu


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
        }
    }
}