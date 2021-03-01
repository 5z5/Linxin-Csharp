using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ICol_art
    {
        IEnumerable<Col_art> GetColArt();
        Col_art GetColArtById(int? id);
        void RemoveColArt(Col_art colArt);
        void AddColArt(Col_art colArt);
        void EditColArt(Col_art colArt);
    }
}
