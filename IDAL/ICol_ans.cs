using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ICol_ans
    {
        IEnumerable<Col_ans> GetColAns();
        Col_ans GetColAnsById(int? id);
        void RemoveColAns(Col_ans colAns);
        void AddColAns(Col_ans colAns);
        void EditColAns(Col_ans colAns);
    }
}
