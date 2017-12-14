using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BknDal.Repositories.Classes;
using BknDal.Repositories.Interfaces;
using BknService.Services.Classes;
using BknService.Services.Interfaces;
using Ninject.Modules;

namespace bknby.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Repositories
            Bind<IRealEstateObjectsRepository>().To<RealEstateObjectsRepository>();

            //Services
            Bind<IRealEstateObjectsService>().To<RealEstateObjectsService>();
        }
    }
}