using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ICollects
    {
        IEnumerable<Collects> GetCollects();
        Collects GetCollectById(int? id);
        void RemoveCollect(Collects collect);
        void AddCollect(Collects collect);
        void EditCollect(Collects collect);
    }
}
