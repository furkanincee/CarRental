using Castle.DynamicProxy;
using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // Reflection çalışma anında bir şeyler yapmamızı sağlar. CreateInstance sayesinde buraya gelen validatorun bir instance'ı oluşturulur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Gelen validatorun basetypını bul (AbstractValidator), ve onun generic argümanlarından ilkini getir (yani çalıştığı veri tipini getirecek)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // Invocation metot demek, burada attribute'nin çalıştığı metodun parametrelerini alıyor ve validatorun tipine eşit olanı getir diyoruz.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); // Validation toolu kullanarak da hepsini doğruluyor.
            }
        }
    }
}
