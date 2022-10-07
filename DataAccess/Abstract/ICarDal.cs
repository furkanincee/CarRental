using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Bu interface tipinde, sadece bu ürüne ait özel ihtiyaçları belirtiriz.
    public interface ICarDal :IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
