using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Altkom.Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Altkom.Bicycle.Service.Controllers
{
    public class BikesController : ApiController
    {
        private IBikesService Service = new MockBikesService();

        public IList<Bike> Get()
        {
            return Service.GetBikes();
        }


        public Bike Get(int id)
        {
            return Service.GetBike(id);
        }


    }
}
