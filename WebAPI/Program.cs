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
            // Aþaðýda da autofac kullanacaðýmýzý .nete belirtiyoruz 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddSingleton<ICarService, CarManager>(); // Tüm bellekte bir tane car manager oluþturur ve ctor içinde her ICarService çaðrýldýðýnda o bellekteki car manageri verir. Böylece sürekli yeni yeni örnekler oluþturmaktan kaçýnmýþ oluruz.
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();
            // Singletonýn mantýðý buydu
            // IoC konteynerý kullandýk iyi hoþ fakat þöyle bir dezavantaj var, burasý þimdi apinin program.csi ama baþka projeler eklediðimizde bunlarý yeniden yapmamýz gerekecek. Bunun önüne geçmek için de business'e Autofac kurduk.
            // Burada yaptýðýmýz eklemeleri benzer bir þekilde AutofacBusinessModule'de yaptýk incelemek için oraya git.


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