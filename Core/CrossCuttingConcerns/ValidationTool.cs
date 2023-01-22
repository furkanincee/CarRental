using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns
{
    public static class ValidationTool
    {
        // Oluşturduğumuz CarValidatorün base classına gittik onun da implement ettiği IValidate Interface'ine gittik ve oradaki Validate metodunu aldık
        public static void Validate(IValidator validator, object entity) 
        {
            var context = new ValidationContext<object>(entity); // Neden T vermedi de object verdi anlamadım? Hem DTO hem Entity gelebilir dedi.
            var result = validator.Validate(context);
            
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        // Buranın nasıl kullanıldığını managerlarda görebilirsin.
    }
}
