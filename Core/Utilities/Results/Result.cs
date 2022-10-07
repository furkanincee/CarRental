using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // bu şekilde ayarladığımızda readonly oldu, bu şekilde ayarlanan readonly bir property yalnızca ctorda set edilebilir.
        // eğer aşağıdaki şekilde set etseydik yine readonly olur fakat bu sefer ctorda da set edilemezdi. Bu iki tür kullanımın farkı budur.
        //public bool Success
        //{
        //    get => true;
        //}
        public bool Success { get;}

        public string Message { get; }
        public Result(bool success, string message):this(success) // Bu şekilde kullandığımızda aşağıdaki ctor da çalışacak. this(success) diyerek bu classın tek parametreli halini de çalıştırmış oluyoruz.
        {         
            Message = message;
        }

        // Without any message
        public Result(bool success)
        {
            Success = success;
        }
    }
}
