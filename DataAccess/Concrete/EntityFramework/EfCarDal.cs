using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext ctx = new CarRentalContext())
            {
                var result = from car in ctx.Cars
                             join brand in ctx.Brands on car.BrandId equals brand.Id
                             join color in ctx.Colors on car.ColorId equals color.Id
                             select new CarDetailDto { BrandName = brand.Name, CarName = car.Name, ColorName = color.Name, DailyPrice = car.DailyPrice };
                return result.ToList();

            }          
        }
    }
}
