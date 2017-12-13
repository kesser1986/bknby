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
                
            }
        }
    }
}
