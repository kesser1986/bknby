using System.Collections.Generic;
using System.Threading.Tasks;
using BknDal.Models;

namespace BknDal.Repositories.Interfaces
{
    public interface IRealEstateObjectsRepository : IRepository<RealEstateObject, long>
    {
        void ImportRealEstateObjects();
        List<RealEstateObject> GetRealEstateObjects();
    }
}
