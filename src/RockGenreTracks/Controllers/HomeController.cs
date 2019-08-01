using Newtonsoft.Json;
using RockGenreTracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RockGenreTracks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITracksRepository _repository;

        public HomeController(ITracksRepository repository)
        {
            this._repository = repository;
        }
       
        public async Task<ActionResult> Display()
        {
            try
            {
                IEnumerable<TrackComposerViewModel> trackComposerViewModels = await _repository.GetTrackComposer();
                return View(trackComposerViewModels);
            }

            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Display"));
            }
           
        }
    }
}