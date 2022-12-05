using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    /* Yeni bir Entity eklerken;
     * 1-Entity klasörüne gidilip class oluşturur (buradaki gibi)
     * 2-Entitynin interface'i oluşturulur (ICarDal) DataAccess\Abstract
     * 3-EntityFramework classı oluşturulur (EfCarDal) EfEntityRepositoryBase classından türer ve ICarDal'ı implement eder DataAccess\Concrete\EntityFramework
     * 4-Contextin içine DbSet eklenir
     * 5-Business Abstract içinde ICarService yazılır. Bu interface içinde dış dünyaya servis edeceğimiz metotlar bulunur.
     * 6-Business Concretede CarManager eklenir, ICarService interface'ini implement eder. İş kodları manager içinde yazılır. Dal katmanını kullanırız ve CarManager classı içinde bir ICarDal propertysi oluştururuz.
     */

    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
