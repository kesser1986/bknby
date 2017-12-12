using System;
using System.Threading.Tasks;
using BknDal.Models;
using BknDal.Repositories.Interfaces;

namespace BknDal.Repositories.Classes
{
    public class RealEstateObjectsRepository : BaseRepository<RealEstateObject, long>, IRealEstateObjectsRepository
    {
        public async Task ImportRealEstateObjects()
        {
            using (var db = DbContextFactory.OpenContext())
            {
                var realEstateObject = new RealEstateObject()
                {
                    Unid = 003413766957,
                    Address = "Минск, Скрыганова ул. 2",
                    Code = 766957,
                    Infosource = "база3.0",
                    Responsible = 4672
                };
                db.RealEstateObject.Add(realEstateObject);
                await db.SaveChangesAsync();
            }
        }
    }
}
