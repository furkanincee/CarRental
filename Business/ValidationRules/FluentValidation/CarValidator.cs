using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Kurallar buraya yazılır Constructor içine
            RuleFor(c=>c.DailyPrice).NotEmpty().WithMessage("Fiyat Boş Olamaz"); // Bu şekilde hata mesajı da ekleyebiliyoruz
            RuleFor(c=>c.DailyPrice).GreaterThan(0); 
            // Bu şekilde hazır bir çok kural var, kendi kuralımızı da yazabiliyoruz.
            //RuleFor(c=>c.Name).Must(StartsWithA); // Must içinde bool fonksiyonumuzu veriyoruz 
            RuleFor(c=>c.Name).MinimumLength(3);
        }

        //private bool StartsWithA(string arg)
        //{
        //    return arg.StartsWith("A"); // Arabanın adı A ile başlıyosa true dönecek yani kural geçerli olacak
        //}
    }
}
