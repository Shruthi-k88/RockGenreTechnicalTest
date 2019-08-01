using RockGenreTracks.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RockGenreTracks
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here            
            container.RegisterType<ITracksRepository, TracksRepository>();
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}