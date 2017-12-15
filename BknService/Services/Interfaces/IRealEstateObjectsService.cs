using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BknDal.Models;

namespace BknService.Services.Interfaces
{
    public interface IRealEstateObjectsService : IService<RealEstateObject, long>
    {
        void ImportRealEstateObjects();
        List<RealEstateObject> GetRealEstateObjects();
    }

    
}
