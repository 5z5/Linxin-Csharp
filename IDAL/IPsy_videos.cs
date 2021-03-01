using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IPsy_videos
    {
        IEnumerable<Psy_videos> GetPsyVideos();
        Psy_videos GetPsyVideosById(int? id);
        void RemovePsyVideos(Psy_videos psyVideos);
        void AddPsyVideos(Psy_videos psyVideos);
        void EditPsyVideos(Psy_videos psyVideos);
    }
}
