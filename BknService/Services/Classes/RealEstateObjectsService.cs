using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BknDal.Models;
using BknDal.Repositories.Interfaces;
using BknService.Services.Interfaces;

namespace BknService.Services.Classes
{
    public class RealEstateObjectsService : BaseService<RealEstateObject, long>, IRealEstateObjectsService
    {
        private readonly IRealEstateObjectsRepository _realEstateObjectsRepository;

        public RealEstateObjectsService(IRealEstateObjectsRepository jobsRepository) : base(jobsRepository)
        {
            _realEstateObjectsRepository = jobsRepository;
        }
    }
}
