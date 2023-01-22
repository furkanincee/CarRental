using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // A�a��da da autofac kullanaca��m�z� .nete belirtiyoruz 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddSingleton<ICarService, CarManager>(); // T�m bellekte bir tane car manager olu�turur ve ctor i�inde her ICarService �a�r�ld���nda o bellekteki car manageri verir. B�ylece s�rekli yeni yeni �rnekler olu�turmaktan ka��nm�� oluruz.
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();
            // Singleton�n mant��� buydu
            // IoC konteyner� kulland�k iyi ho� fakat ��yle bir dezavantaj var, buras� �imdi apinin program.csi ama ba�ka projeler ekledi�imizde bunlar� yeniden yapmam�z gerekecek. Bunun �n�ne ge�mek i�in de business'e Autofac kurduk.
            // Burada yapt���m�z eklemeleri benzer bir �ekilde AutofacBusinessModule'de yapt�k incelemek i�in oraya git.


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