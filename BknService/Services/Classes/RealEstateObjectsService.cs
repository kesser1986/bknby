﻿using System;
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

        public RealEstateObjectsService(IRealEstateObjectsRepository realEstateObjectsRepository) : base(realEstateObjectsRepository)
        {
            _realEstateObjectsRepository = realEstateObjectsRepository;
        }

        public RealEstateObject GetRealEstateObject(int realEstateObjectId)
        {
            return _realEstateObjectsRepository.GetRealEstateObject(realEstateObjectId);
        }

        public List<RealEstateObjectPhoto> GetRealEstateObjectPhotos(long unid)
        {
            return _realEstateObjectsRepository.GetRealEstateObjectPhotos(unid);
        }

        public List<RealEstateObject> GetRealEstateObjects()
        {
            return _realEstateObjectsRepository.GetRealEstateObjects();
        }

        public void ImportRealEstateObjects()
        {
            _realEstateObjectsRepository.ImportRealEstateObjects();
        }
    }
}
