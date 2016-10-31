using Altkom.Bicycle.Interfaces;
using Altkom.Bicycle.MockServices;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.UWPClient.ViewModels
{
    public class ViewModelLocator
    {
        

        public ViewModelLocator()
        {
            var container = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));


            container
                .RegisterType<IBikesService, MockBikesService>(new ContainerControlledLifetimeManager())
                .RegisterType<IUsersService, MockUsersService>(new ContainerControlledLifetimeManager())
                .RegisterType<IStationsService, MockStationsService>(new ContainerControlledLifetimeManager())
                ;


            ServiceLocator.Current.GetInstance<IBikesService>();
            ServiceLocator.Current.GetInstance<IUsersService>();
            ServiceLocator.Current.GetInstance<IStationsService>();

        }
    }
}
