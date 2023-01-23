using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module // using eklerken Autofac ekle dikkat et ona bir de reflection diye bir şey öneriyor visual studio.
    {
        // Burada sadece bu proje ile alakalı ayarlar yapılacak. Bir de core katmanında yapılan configürasyonlar var. Orada da genel her projede kullanılacak şeyler eklenir.
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); // ICarService istendiğinde CarManager verecek, SingleInstance de add singletonun yerini tutuyor yani tek sefer örnekliyor.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            // Bunları ekledikten sonra bir yerde programa tanıtılması lazım ki kendi IoC yapılanmasını değil bunu kullansın


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); // Çalışan şeyleri al

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() // Implemente edilmiş interfaceleri bul ve onlar için AspectInterceptorSelector örnekle
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
