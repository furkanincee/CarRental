using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    // Birşey döndürmeyen voidler için kullanılır
    public interface IResult
    {
        public bool Success { get; } // Sadece okumak için kullanacağımızdan dolayı tek getter verdik. 
        public string Message { get; }


    }
}
