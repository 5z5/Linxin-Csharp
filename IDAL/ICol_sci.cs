using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ICol_sci
    {
        IEnumerable<Col_sci> GetColSci();
        Col_sci GetColSciById(int? id);
        void RemoveColSci(Col_sci colSci);
        void AddColSci(Col_sci colSci);
        void EditColSci(Col_sci colSci);
    }
}
