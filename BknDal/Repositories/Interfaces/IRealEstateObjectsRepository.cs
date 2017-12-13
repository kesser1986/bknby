using System.Threading.Tasks;
using BknDal.Models;

namespace BknDal.Repositories.Interfaces
{
    public interface IRealEstateObjectsRepository : IRepository<RealEstateObject, long>
    {
        Task ImportRealEstateObjects();
    }
}
