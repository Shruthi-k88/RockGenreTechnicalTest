using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGenreTracks.Models
{
    public interface ITracksRepository
    {
        Task<IEnumerable<Tracks>> GetAllTracks();
        Task<IEnumerable<Composers>> GetAllComposers();
        Task<IEnumerable<TrackComposerViewModel>> GetTrackComposer();

    }
}
