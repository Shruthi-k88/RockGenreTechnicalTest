using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RockGenreTracks.Models
{
    public class TracksRepository : ITracksRepository
    {        
        private const string BASE_URL = "https://private-anon-7e8d7830de-audionetworkrecruitment.apiary-mock.com/";

        /// <summary>
        /// To get all Tracks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tracks>> GetAllTracks()
        {
            var baseAddress = new Uri(BASE_URL);
            string responseData;
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("tracks"))
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }
            var trackList = JsonConvert.DeserializeObject<IEnumerable<Tracks>>(responseData);            
            return trackList;
        }

        /// <summary>
        /// To get all Composers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Composers>> GetAllComposers()
        {
            var baseAddress = new Uri(BASE_URL);
            string responseData;           

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("composers"))
                {

                   responseData = await response.Content.ReadAsStringAsync();
                }
            }

            var composerList = JsonConvert.DeserializeObject<IEnumerable<Composers>>(responseData);
            return composerList;
        }

        /// <summary>
        /// To get Rock Genre tracks and its composers
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<TrackComposerViewModel>> GetTrackComposer()
        {
            IEnumerable<TrackComposerViewModel> trackComposer = new List<TrackComposerViewModel>();
            IEnumerable<Tracks> trackList = await GetAllTracks();
            IEnumerable<Composers> composerList = await GetAllComposers();

            trackComposer = composerList.Join(
                            trackList,
                            c => c.Id,
                            t => t.ComposerId,
                            (c, t) => new TrackComposerViewModel
                            {
                                Tracks = t.Title,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Genre = t.Genre
                            }).Where(ct => ct.Genre =="rock")
                            .OrderBy(ct => ct.Tracks);

                return trackComposer;
        }

        

    }
}