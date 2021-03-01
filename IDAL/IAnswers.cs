using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IAnswers
    {
        IEnumerable<Answers> GetAnswers();
        Answers GetAnswertById(int? id);
        void RemoveAnswer(Answers answer);
        void AddAnswer(Answers answer);
        void EditAnswer(Answers answer);
    }
}
